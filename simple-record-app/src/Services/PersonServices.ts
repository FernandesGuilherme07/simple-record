import { IPersonServices } from '../core/Contracts/IPersonServices';
import { CreatePersonInputModel } from '../core/InputModels/CreatePersonInputModel';
import { DeletePersonInputModel } from '../core/InputModels/DeletePersonInputModel';
import { GetAllPeoplesInputModel } from '../core/InputModels/GetAllPeoplesInputModel';
import { GetPersonByIdInputModel } from '../core/InputModels/GetPersonByIdInputModel';
import { UpdatePersonInputModel } from '../core/InputModels/UpdatePersonInputModel';
import { GenericServiceResult } from '../core/ViewModels/GenericServiceResult';
import { GetAllPeoplesViewModel } from '../core/ViewModels/GetAllPeoplesViewModel';
import { GetPersonByIdViewModel } from '../core/ViewModels/GetPersonByIdViewModel';
import HttpServer from './HttpServer';
class PersonServices implements IPersonServices {
  private http: HttpServer;

  constructor() {
    this.http = new HttpServer();
  }

  public async CreatePerson(data: CreatePersonInputModel): Promise<GenericServiceResult> {
    const response = await this.http.post<GenericServiceResult>('/api/Person/CreatePerson', data);
    return response;
  }

  public async GetAllPeoples(data: GetAllPeoplesInputModel): Promise<GenericServiceResult<GetAllPeoplesViewModel[]>> {
    const response = await this.http.get<GenericServiceResult>('/api/Person/GetAllPeoples', data);
    return response;
  }

  public async GetPersonById(data: GetPersonByIdInputModel): Promise<GenericServiceResult<GetPersonByIdViewModel>> {
    const response = await this.http.get<GenericServiceResult>('/api/Person/GetPersonById', data);
    return response;
  }

  public async UpdatePerson(data: UpdatePersonInputModel): Promise<GenericServiceResult> {
    const response = await this.http.put<GenericServiceResult>('/api/Person/UpdatePerson', data);
    return response;
  }

  public async DeletePerson(data: DeletePersonInputModel): Promise<GenericServiceResult> {
    const response = await this.http.delete<GenericServiceResult>('/api/Person/DeletePerson', data);
    return response;
  }
}

export default PersonServices;
