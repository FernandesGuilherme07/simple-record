import { makeAutoObservable, action, observable } from 'mobx';
import { toast } from 'react-toastify';
import PersonServices from '../Services/PersonServices';
import { AddressCreatePerson } from '../core/InputModels/CreatePersonInputModel';

export type Address = {
  id?: string;
  personId: string;
  type:  0 | 1;
  street: string;
  number: string;
  complement: string;
  neighborhood: string;
  zipCode: string;
  city: string;
  state: string;
  fullAddress: string;
};

const personServices = new PersonServices()

class UserStore {
  @observable
  name: string = '';

  @observable
  type: 0 | 1 = 0;

  @observable
  document: string = '';

  @observable
  contact: string = '';

  @observable
  email: string = '';

  @observable
  loading: boolean = false;

  @observable
  addresses: Address[] = [];

  @observable
  isModalOpen: boolean = false;

  @observable
  newAddress: Address | null = {
    personId: '',
    fullAddress: '',
    type: 0,
    street: '',
    number: '',
    complement: '',
    neighborhood: '',
    zipCode: '',
    city: '',
    state: '',
  };

  constructor() {
    makeAutoObservable(this);
  }

  @action
  async createPerson() {
    this.loading = true;

    try {
      const addressesRequest: AddressCreatePerson[] = this.addresses.map((address) => ({
        City: address.city,
        Type: address.type,
        Street: address.street,
        State: address.state,
        Complement: address.complement,
        Neighborhood: address.neighborhood,
        Number: address.number,
        ZipCode: this.removeSpecialCharactersAndSpaces(address.zipCode),
      }));

      const createPerson = await personServices.CreatePerson({
        contact: this.removeSpecialCharactersAndSpaces(this.contact),
        document: this.removeSpecialCharactersAndSpaces(this.document),
        email: this.email,
        name: this.name,
        type: this.type,
        addresses: addressesRequest,
      });

      if(createPerson.success) {
      this.resetForm();
      toast.success('Usuário adicionado com sucesso');
      }
    } catch (error) {
      toast.error('Dados inválidos!');
    }

    this.loading = false;
  }

  @action
  async getPersonById(userId: string) {
    this.loading = true;
    try {
      const { data } = await personServices.GetPersonById({ id: userId });

      this.name = data.name;
      this.type = data.type;
      this.document = data.document;
      this.contact = data.contact;
      this.email = data.email || '';
      this.addresses = data.addresses;
    } catch (error) {
      toast.error('Erro ao carregar os dados do usuário.');
    } finally {
      this.loading = false;
    }
  }

  @action
  async updatePerson(userId: string) {
    this.loading = true;

    try {
      const addressesRequest = this.addresses.map((address) => ({
        City: address.city,
        Type: address.type,
        Street: address.street,
        State: address.state,
        Complement: address.complement,
        Neighborhood: address.neighborhood,
        Number: address.number,
        ZipCode: address.zipCode,
      }));

      await personServices.UpdatePerson({
        id: userId,
        contact: this.contact,
        document: this.document,
        email: this.email,
        name: this.name,
        type: this.type, 
        addresses: addressesRequest
      });

      toast.success('Dados do usuário atualizados com sucesso.');
    } catch (error) {
      toast.error('Erro ao atualizar os dados do usuário.');
    }

    this.loading = false;
  }

  @action
  handleAddAddress() {
    this.newAddress = {
      personId: '',
      fullAddress: '',
      type: 0,
      street: '',
      number: '',
      complement: '',
      neighborhood: '',
      zipCode: '',
      city: '',
      state: '',
    };
    this.isModalOpen = true;
  }

  @action
  handleModalClose() {
    this.isModalOpen = false;
  }

  @action
  handleSaveAddress() {
    if(this.newAddress)
    this.addresses.push(this.newAddress);
    this.newAddress = {
      personId: '',
      fullAddress: '',
      type: 0,
      street: '',
      number: '',
      complement: '',
      neighborhood: '',
      zipCode: '',
      city: '',
      state: '',
    };
    this.isModalOpen = false;
  }

  @action
  handleRemoveAddress(index: number) {
    this.addresses = this.addresses.filter((_, i) => i !== index);
  }

  @action
  isFormValid() {
    return this.name.trim() !== '' && this.document.trim() !== '' && this.contact.trim() !== '';
  }

  @action
  resetForm() {
    this.name = '';
    this.type = 0;
    this.document = '';
    this.contact = '';
    this.email = '';
    this.addresses = [];
    this.newAddress = {
      personId: '',
      fullAddress: '',
      type: 0,
      street: '',
      number: '',
      complement: '',
      neighborhood: '',
      zipCode: '',
      city: '',
      state: '',
    };
  }

  removeSpecialCharactersAndSpaces(str: string): string {
    // Remove caracteres especiais (exceto letras e números) e espaços usando regex
    return str.replace(/[^a-zA-Z0-9]/g, '');
  }
}

export default UserStore;
