import React, {useMemo} from 'react';
import { toast } from 'react-toastify';
import { Container, Paper, Button, Grid, useMediaQuery, useTheme, Box, CircularProgress, Typography } from '@mui/material';
import { useNavigate } from 'react-router-dom'
import { observer } from 'mobx-react-lite';


import FormComponent from '../components/FormComponent';
import AddressTable from '../components/AddressTable';
import AddAddressModal from '../components/AddAddressModal';
import UserStore from '../stores/UserStore'; // Importar a classe UserStore
import Header from '../components/Header';

const CreateUserPage: React.FC = observer(() => {

  const userStore = useMemo(() => new UserStore(), []);
  const history = useNavigate();
  const theme = useTheme();
  const isMobile = useMediaQuery(theme.breakpoints.down('sm'));

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    try {
      if (userStore.isFormValid()) {
        await userStore.createPerson();
        toast.success('Usuário adicionado com sucesso');
        history(`/`);
      } else {
        toast.warning('Por favor, preencha todos os campos obrigatórios antes de cadastrar o usuário.');
      }
    } catch (error) {
      toast.error('Dados inválidos!');
    }
  };

  return (
    <>
      <Header>
        <Button
          variant="contained"
          color="primary"
          size="large"
          sx={{ backgroundColor: '#fff', color: '#333', '&:hover': { backgroundColor: '#f0f0f0' } }}
        >
          Voltar
        </Button>
      </Header>
      <Container
        component="main"
        maxWidth="xl"
        sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', minHeight: '100vh' }}
      >
        {userStore.loading && (
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
        <Paper
          elevation={3}
          sx={{
            padding: 6,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
            width: isMobile ? '100%' : '80%',
          }}
        >
          <Typography component="h1" variant="h5" sx={{ mb: 4 }}>
            Cadastro de Usuário
          </Typography>
          <FormComponent
            name={userStore.name}
            setName={(name) => (userStore.name = name)}
            type={userStore.type}
            setType={(type) => (userStore.type = type)}
            document={userStore.document}
            setDocument={(document) => (userStore.document = document)}
            contact={userStore.contact}
            setContact={(contact) => (userStore.contact = contact)}
            email={userStore.email}
            setEmail={(email) => (userStore.email = email)}
            isMobile={isMobile}
            handleSubmit={handleSubmit}
            handleAddAddress={() => userStore.handleAddAddress()}
          />
          <AddressTable
            loading={userStore.loading}
            addresses={userStore.addresses}
            handleRemoveAddress={(index) => userStore.handleRemoveAddress(index)}
          />
          <AddAddressModal
            isModalOpen={userStore.isModalOpen}
            handleModalClose={() => userStore.handleModalClose()}
            newAddress={userStore.newAddress!}
            setNewAddress={(address) => (userStore.newAddress = address)}
            handleSaveAddress={() => userStore.handleSaveAddress()}
          />
          <Grid
            container
            justifyContent="center"
            alignItems="center"
            sx={{ mt: 4, marginBottom: '1rem' }}
          >
            <Button
              onClick={(e: any) => handleSubmit(e)}
              variant="contained"
              color="primary"
              size="large"
            >
              Cadastrar Usuário
            </Button>
          </Grid>
        </Paper>
      </Container>
    </>
  );
});

export default CreateUserPage;
