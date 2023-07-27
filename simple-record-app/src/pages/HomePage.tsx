import { toast } from 'react-toastify';
import React, { useState, useEffect } from 'react';
import { Container, Box, Typography, CircularProgress } from '@mui/material';
import 'react-toastify/dist/ReactToastify.css';

import PersonServices from '../Services/PersonServices';
import { GetAllPeoplesViewModel } from '../core/ViewModels/GetAllPeoplesViewModel';

import SearchBar from '../components/SearchBar';
import UserTable from '../components/UserTable';
import DeleteConfirmationModal from '../components/DeleteConfirmationModal';
import Header from '../components/Header';

const HomePage: React.FC = () => {
  const [searchTerm, setSearchTerm] = useState('');
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(10);
  const [data, setData] = useState<GetAllPeoplesViewModel[]>([]);
  const [selectedPerson, setSelectedPerson] = useState<GetAllPeoplesViewModel | null>(null);
  const [confirmDeleteModalOpen, setConfirmDeleteModalOpen] = useState(false);
  const [loading, setLoading] = useState(false);
  const [deleteMessage, setDeleteMessage] = useState('');

  const handleDeleteClick = (person: GetAllPeoplesViewModel) => {
    setSelectedPerson(person);
    setConfirmDeleteModalOpen(true);
  };

  const handleDeleteConfirm = async () => {
    
    if (selectedPerson) {
      setLoading(true)
      await new PersonServices().DeletePerson({id: selectedPerson.id})
      setLoading(true)
      setDeleteMessage(`Usuário Excluído com sucesso!`);
      toast.success("Usuário Excluído com sucesso!");
      setSelectedPerson(null);
    }
    setConfirmDeleteModalOpen(false);
  };

  const handleDeleteCancel = () => {
    setConfirmDeleteModalOpen(false);
  };

  const handleSearch = async () => {
    setLoading(true);
    const result = await new PersonServices().GetAllPeoples({
      searchTerm,
      type: undefined,
      pageNumber: page + 1,
      pageSize: rowsPerPage,
    });

    if (result.success) {
      setData(result.data);
    }
    setLoading(false);
  };

  useEffect(() => {
    if (deleteMessage !== '') {
      setSelectedPerson(null);
    }
    handleSearch();
  }, [page, rowsPerPage, deleteMessage]);

  const handleChangePage = (event: unknown, newPage: number) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event: React.ChangeEvent<HTMLInputElement>) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  return (
    <>
    <Header>
      SimpleCad
    </Header>
    <Container maxWidth="xl">
      {loading && (
        <Box
          display="flex"
          justifyContent="center"
          alignItems="center"
          position="fixed"
          top={0}
          left={0}
          width="100%"
          height="100%"
          bgcolor="rgba(0, 0, 0, 0.5)" // Opacidade mais escura
          zIndex={9999}
        >
          <CircularProgress size={80} color="primary" />
        </Box>
      )}
      <Box mt={"2rem"} mb={"3rem"} alignContent={"center"}>
        <Typography variant="h4" component="h1" align="left">
        </Typography>
      </Box>
      <SearchBar
        searchTerm={searchTerm}
        onSearchTermChange={setSearchTerm}
        onSearch={handleSearch}
        loading={loading}
      />
      <Typography mt={"2rem"} variant="h6" component="h2">
        Usuários
      </Typography>
      <UserTable
        data={data}
        loading={loading}
        onDeleteUser={handleDeleteClick}
        rowsPerPage={rowsPerPage}
        page={page}
        onPageChange={handleChangePage}
        onRowsPerPageChange={handleChangeRowsPerPage}
      />
      <DeleteConfirmationModal
        isOpen={confirmDeleteModalOpen}
        onCancel={handleDeleteCancel}
        onConfirm={handleDeleteConfirm}
        loading={loading}
      />
    </Container>
    </>
    
  );
};

export default HomePage;

