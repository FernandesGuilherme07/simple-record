import React from 'react';
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Typography,
  Button,
} from '@mui/material';

interface DeleteConfirmationModalProps {
  isOpen: boolean;
  onCancel: () => void;
  onConfirm: any;
  loading: boolean;
}

const DeleteConfirmationModal: React.FC<DeleteConfirmationModalProps> = ({
  isOpen,
  onCancel,
  onConfirm,
  loading,
}) => {
  return (
    <Dialog open={isOpen} onClose={onCancel}>
      <DialogTitle>Confirmar Exclusão</DialogTitle>
      <DialogContent>
        <Typography>Tem certeza que deseja excluir?</Typography>
      </DialogContent>
      <DialogActions>
        <Button disabled={loading} onClick={onConfirm} color="error">
          Excluir
        </Button>
        <Button disabled={loading} onClick={onCancel} color="primary">
          Cancelar
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default DeleteConfirmationModal;
