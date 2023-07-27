import React from 'react';
import { Link } from 'react-router-dom'
import {
  TextField,
  Button,
  Grid,
  InputAdornment,
} from '@mui/material';
import SearchIcon from '@mui/icons-material/Search';
import CreateUserPage from '../../pages/CreateUserPage';

interface SearchBarProps {
  searchTerm: string;
  onSearchTermChange: (term: string) => void;
  onSearch: () => void;
  loading: boolean;
}

const SearchBar: React.FC<SearchBarProps> = ({ searchTerm, onSearchTermChange, onSearch, loading }) => {

  return (
    <Grid container spacing={1} alignItems="center">
      <Grid item xs={12} md={4}>
        <TextField
          size='small'
          placeholder='Pesquisar por nome ou documento...'
          value={searchTerm}
          onChange={(e) => onSearchTermChange(e.target.value)}
          fullWidth
          InputProps={{
            startAdornment: (
              <InputAdornment position="start">
                <SearchIcon />
              </InputAdornment>
            ),
          }}
        />
      </Grid>
      <Grid item xs={12} md={2}>
        <Button disabled={loading} variant="contained" color="primary" onClick={onSearch} fullWidth>
          Pesquisar
        </Button>
      </Grid>
      <Grid item xs={12} md={4} />

      <Grid item xs={12} md={2} justifyContent="flex-end">
        <Link to={"/create"}>
          <Button disabled={loading} variant="contained" color="primary" fullWidth style={{ whiteSpace: 'nowrap' }}>
            + Novo usuário
          </Button>
        </Link> 
      </Grid>
    </Grid>
  );
};

export default SearchBar;
