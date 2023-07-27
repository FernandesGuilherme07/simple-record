import { Modal, Paper, Grid, TextField, Button, MenuItem, Typography } from '@mui/material';
import InputMask from 'react-input-mask';
import { Address } from '../../core/Models/Address';import { formatCEP } from '../../utils/format';
;


interface AddAddressModalProps {
  isModalOpen: boolean;
  handleModalClose: () => void;
  newAddress: Omit<Address, "id">;
  setNewAddress: (address: Omit<Address, "id">) => void;
  handleSaveAddress: () => void;
}

const AddAddressModal: React.FC<AddAddressModalProps> = ({
  isModalOpen,
  handleModalClose,
  newAddress,
  setNewAddress,
  handleSaveAddress,
}) => {


  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    
    if (name === "zipCode") {
      setNewAddress({ ...newAddress, [name]: formatCEP(value) });
    } else {
      setNewAddress({ ...newAddress, [name]: value });
    }
  };


  return (
    <Modal open={isModalOpen} onClose={handleModalClose} aria-labelledby="modal-title">
      <Paper
        elevation={3}
        sx={{
          padding: 2,
          position: 'absolute',
          top: '50%',
          left: '50%',
          transform: 'translate(-50%, -50%)',
          width: '80%',
          maxWidth: 600,
        }}
      >
        <Typography variant="h6" component="h2" sx={{ mb: 2 }}>
          Adicionar Endereço
        </Typography>
        <form onSubmit={handleSaveAddress} style={{ width: '100%' }}>
        <Grid container spacing={2}>
              <Grid item xs={12} md={6}>
                <TextField
                  fullWidth
                  select
                  label="Tipo de Endereço"
                  value={newAddress.type}

                  onChange={(e) => setNewAddress({ ...newAddress, type: Number(e.target.value)  as 0 | 1}) }
                  required
                >
                  <MenuItem value={0}>Residencial</MenuItem>
                  <MenuItem value={1}>Comercial</MenuItem>
                </TextField>
              </Grid>
              <Grid item xs={12} md={6}>
                <TextField
                  fullWidth
                  label="Rua"
                  value={newAddress.street}
                  onChange={(e) => setNewAddress({ ...newAddress, street: e.target.value })}
                  required
                />
              </Grid>
              <Grid item xs={12} md={6}>
                <TextField
                  fullWidth
                  label="Número"
                  value={newAddress.number}
                  onChange={(e) => setNewAddress({ ...newAddress, number: e.target.value })}
                />
              </Grid>
              <Grid item xs={12} md={6}>
                <TextField
                  fullWidth
                  label="Complemento"
                  value={newAddress.complement}
                  onChange={(e) => setNewAddress({ ...newAddress, complement: e.target.value })}
                />
              </Grid>
              <Grid item xs={12} md={6}>
                <TextField
                  fullWidth
                  label="Bairro"
                  value={newAddress.neighborhood}
                  onChange={(e) => setNewAddress({ ...newAddress, neighborhood: e.target.value })}
                  required
                />
              </Grid>
              <Grid item xs={12} md={6}>
              <TextField
                fullWidth
                label="CEP"
                name="zipCode"
                value={newAddress.zipCode}
                onChange={handleInputChange}
                required
                InputProps={{
                  inputComponent: InputMask as any,
                  inputMode: 'numeric',
                }}
                inputMode="numeric"
              />
              </Grid>
              <Grid item xs={12} md={6}>
                <TextField
                  fullWidth
                  label="Cidade"
                  value={newAddress.city}
                  onChange={(e) => setNewAddress({ ...newAddress, city: e.target.value })}
                  required
                />
              </Grid>
              <Grid item xs={12} md={6}>
                <TextField
                  fullWidth
                  label="Estado"
                  value={newAddress.state}
                  onChange={(e) => setNewAddress({ ...newAddress, state: e.target.value })}
                  required
                />
              </Grid>
            </Grid>
          <Button type="submit" variant="contained" color="primary" sx={{ mt: 2 }} fullWidth>
            Adicionar Endereço
          </Button>
        </form>
      </Paper>
    </Modal>
  );
};

export default AddAddressModal;
