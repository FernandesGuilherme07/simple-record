import { IAddressPersonService } from '../core/Contracts/IAddressPersonService';
import { CreateAddressPersonInputModel } from '../core/InputModels/CreateAddressPersonInputModel';
import { DeleteAddressPersonInputModel } from '../core/InputModels/DeleteAddressPersonInputModel';
import { GenericServiceResult } from '../core/ViewModels/GenericServiceResult';
import HttpServer from './HttpServer';

class AddressPersonService implements IAddressPersonService {
  private http: HttpServer;

  constructor() {
    this.http = new HttpServer();
  }

  public async CreateAddressPerson(data: CreateAddressPersonInputModel): Promise<GenericServiceResult> {
    const response = await this.http.post<GenericServiceResult>('/api/AddressPerson/CreateAddressPerson', data);
    return response;
  }

  public async DeleteAddressPerson(data: DeleteAddressPersonInputModel): Promise<GenericServiceResult> {
    const response = await this.http.delete<GenericServiceResult>('/api/AddressPerson/DeleteAddressPerson', data );
    return response;
  }
}

export default AddressPersonService;
