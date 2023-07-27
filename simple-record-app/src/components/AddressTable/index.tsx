import React, { useState } from 'react';
import { Container, Typography, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Button } from '@mui/material';
import DeleteConfirmationModal from '../DeleteConfirmationModal';
import { Address } from '../../stores/UserStore';


interface AddressTableProps {
  loading: boolean;
  addresses: Address[];
  handleRemoveAddress: (index: number) => void;
}

const AddressTable: React.FC<AddressTableProps> = ({loading, addresses, handleRemoveAddress }) => {
    
  const [confirmDeleteModalOpen, setConfirmDeleteModalOpen] = useState(false);
  const [idSelected, setIdSelected] = useState(0)

    const handleDeleteClick = (id: number) => {
        setIdSelected(id)
    setConfirmDeleteModalOpen(true);
  };

  const handlerDeleteCancell = () => {
    setConfirmDeleteModalOpen(false);
  }

  const handlerDeletConfirm = () => {
    setConfirmDeleteModalOpen(false);
    handleRemoveAddress(idSelected)
  }
  return (
    <Container component="section" sx={{ mt: 4, maxWidth: '100%' }}>
      {addresses.length > 0 ? (
        <TableContainer component={Paper} sx={{ mt: 4 }}>
          <Table aria-label="address-table" sx={{ minWidth: 650 }}>
            <TableHead>
              <TableRow>
                <TableCell>Tipo</TableCell>
                <TableCell>Endereço</TableCell>
                <TableCell>Número</TableCell>
                <TableCell>Complemento</TableCell>
                <TableCell>Bairro</TableCell>
                <TableCell>CEP</TableCell>
                <TableCell>Cidade</TableCell>
                <TableCell>Estado</TableCell>
                <TableCell>Ações</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {addresses.map((address, index) => (
                 <TableRow key={index}>
                 <TableCell>{address.type === 0 ? "Residencial" : "Comercial"}</TableCell>
                 <TableCell>{address.street}</TableCell>
                 <TableCell>{address.number}</TableCell>
                 <TableCell>{address.complement}</TableCell>
                 <TableCell>{address.neighborhood}</TableCell>
                 <TableCell>{address.zipCode}</TableCell>
                 <TableCell>{address.city}</TableCell>
                 <TableCell>{address.state}</TableCell>
                 <TableCell>
                   <Button
                     variant="contained"
                     color="error"
                     onClick={() => handleDeleteClick(index)}
                   >
                     Excluir
                   </Button>
                 </TableCell>
               </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      ) : (
        <Container component="section" sx={{ mt: 4 }}>
          <Typography sx={{ mt: 4 }} align="center">
            Não existem endereços cadastrados para esse usuário.
          </Typography>
        </Container>
      )}

        <DeleteConfirmationModal
        isOpen={confirmDeleteModalOpen}
        onCancel={handlerDeleteCancell}
        onConfirm={() => handlerDeletConfirm()}
        loading={loading}
      />
    </Container>
  );
};

export default AddressTable;
