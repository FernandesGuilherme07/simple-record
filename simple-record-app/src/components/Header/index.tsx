import { useNavigate } from 'react-router-dom';

import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';

type Props = {
    children: React.ReactNode
}

const Header = ({ children }: Props) => {
const history = useNavigate();

  return (
    <AppBar position="static" style={{height: '80px', display: 'flex', justifyContent: 'center'}}>
    <Toolbar variant="dense">
      <IconButton edge="start" onClick={() => history("/")} color="inherit" aria-label="LogoApp" sx={{ mr: 2 }}>
         {children}
      </IconButton>
    </Toolbar>
  </AppBar>
  );
};

export default Header;


