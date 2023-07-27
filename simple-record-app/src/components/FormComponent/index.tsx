import React from 'react';
import {
  TextField,
  Button,
  Grid,
  Typography,
  MenuItem,
} from '@mui/material';
import { formatDocument, formatPhone } from '../../utils/format';

interface FormProps {
  name: string;
  setName: (name: string) => void;
  type:  0 | 1;
  setType: (type:  0 | 1 ) => void;
  document: string;
  setDocument: (document: string) => void;
  contact: string;
  setContact: (contact: string) => void;
  email: string;
  setEmail: (email: string) => void;
  isMobile: boolean;
  handleSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
  handleAddAddress: () => void;
}

const FormComponent: React.FC<FormProps> = ({
  name,
  setName,
  type,
  setType,
  document,
  setDocument,
  contact,
  setContact,
  email,
  setEmail,
  isMobile,
  handleSubmit,
  handleAddAddress,
}) => {

  return (
    <form onSubmit={handleSubmit} style={{ width: '100%' }}>
      <Grid container spacing={2}>
        <Grid item xs={12} md={6}>
          <TextField
            fullWidth
            select
            label="Tipo de pessoa"
            value={type}
            onChange={(e: any) => setType(e.target.value)}
            required
          >
            <MenuItem value={0}>Pessoa Física</MenuItem>
            <MenuItem value={1}>Pessoa Jurídica</MenuItem>
          </TextField>
        </Grid>
        <Grid item xs={12} md={6}>
          <TextField
            fullWidth
            label={type === 0 ? "Nome" : "Razão social"}
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
          />
        </Grid>
        <Grid item xs={12} md={4}>
          <TextField
            fullWidth
            label={type === 0 ? 'CPF' : 'CNPJ'}
            value={formatDocument(type, document)}
            onChange={(e) => {
              const formattedValue = formatDocument(type, e.target.value);
              setDocument(formattedValue);
            }}
            required
            inputMode="numeric"
          />
        </Grid>
        <Grid item xs={12} md={4}>
          <TextField
            fullWidth
            label="Contato (Telefone)"
            value={formatPhone(contact)}
            onChange={(e) => {
              const formattedValue = formatPhone(e.target.value);
              setContact(formattedValue);
            }}
            required
            inputMode="tel"
          />
        </Grid>
        <Grid item xs={4}>
          <TextField
            fullWidth
            label="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            type="email"
          />
        </Grid>
      </Grid>

      <Grid
        container
        justifyContent="space-between"
        alignItems="center"
        mt={4}
        sx={{ paddingX: isMobile ? '1rem' : '2rem' }}
      >
        <Typography variant="h5" component="h2" sx={{ mb: 0 }}>
          Endereços
        </Typography>

        <Button type="button" onClick={handleAddAddress} variant="contained" color="primary" size="large">
          Adicionar Endereço
        </Button>
      </Grid>
    </form>
  );
};

export default FormComponent;
