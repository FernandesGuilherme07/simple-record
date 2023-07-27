import React from 'react';
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TablePagination,
  TableHead,
  TableRow,
  Paper,
  Typography,
  Box,
  Button,
} from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { formatPhoneNumber, formatCPF, formatCNPJ } from '../../utils/format'; // Importe as funções utilitárias de formatação

import { GetAllPeoplesViewModel } from '../../core/ViewModels/GetAllPeoplesViewModel';

interface UserTableProps {
  data: GetAllPeoplesViewModel[];
  loading: boolean;
  onDeleteUser: (person: GetAllPeoplesViewModel) => void;
  rowsPerPage: number;
  page: number;
  onPageChange: (event: unknown, newPage: number) => void;
  onRowsPerPageChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
}

const UserTable: React.FC<UserTableProps> = ({ data, loading, onDeleteUser, rowsPerPage, page, onPageChange, onRowsPerPageChange }) => {
  const history = useNavigate();

  return (
    <Box mt={2}>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Nome</TableCell>
              <TableCell>CPF/CNPJ</TableCell>
              <TableCell>Telefone</TableCell>
              <TableCell>Email</TableCell>
              <TableCell>Endereço Residencial</TableCell>
              <TableCell>Endereço Comercial</TableCell>
              <TableCell>Ações</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {data.map((person) => (
              <TableRow key={person.id}>
                <TableCell>{person.name}</TableCell>
                <TableCell>
                  {person.type === 0
                    ? formatCPF(person.document) 
                    : formatCNPJ(person.document)}
                </TableCell>
                <TableCell>{formatPhoneNumber(person.contact)}</TableCell>
                <TableCell>{person.email}</TableCell>
                <TableCell>
                  {person.addressesResidentials?.map((address) => (
                    <>
                      <Typography key={address.id}>{address.fullAddress}.</Typography>
                      <br />
                    </>
                  ))}
                </TableCell>
                <TableCell>
                  {person.addressesCommercials?.map((address) => (
                    <>
                    <Typography key={address.id}>{address.fullAddress}.</Typography>
                    <br />
                  </>
                  ))}
                </TableCell>
                <TableCell>
                  <Box m={1} display="flex" justifyContent="space-between" gap={.5} width="150px">
                    <Button disabled={loading} onClick={() => history(`/edit/${person.id}`)} variant="contained" color="primary">
                      editar
                    </Button>
                    <Button disabled={loading} onClick={() => onDeleteUser(person)} variant="contained" color="error">
                      excluir
                    </Button>
                  </Box>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <TablePagination
        lang='PT'
        component="div"
        count={data.length}
        rowsPerPageOptions={[5, 10, 25]}
        rowsPerPage={rowsPerPage}
        page={page}
        onPageChange={onPageChange}
        onRowsPerPageChange={onRowsPerPageChange}
        labelRowsPerPage="Linhas por página:"
        labelDisplayedRows={({ from, to, count }) => `${from}-${to} de ${count !== -1 ? count : to}`}
      />
    </Box>
  );
};

export default UserTable;
