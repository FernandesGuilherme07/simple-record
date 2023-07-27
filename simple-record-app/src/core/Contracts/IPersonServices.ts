import { CreatePersonInputModel } from "../InputModels/CreatePersonInputModel";
import { DeletePersonInputModel } from "../InputModels/DeletePersonInputModel";
import { GetAllPeoplesInputModel } from "../InputModels/GetAllPeoplesInputModel";
import { GetPersonByIdInputModel } from "../InputModels/GetPersonByIdInputModel";
import { UpdatePersonInputModel } from "../InputModels/UpdatePersonInputModel";
import { GenericServiceResult } from "../ViewModels/GenericServiceResult";

export interface IPersonServices {
    CreatePerson(data: CreatePersonInputModel): Promise<GenericServiceResult>
    GetAllPeoples(data: GetAllPeoplesInputModel): Promise<GenericServiceResult>
    GetPersonById(data: GetPersonByIdInputModel): Promise<GenericServiceResult>
    UpdatePerson(data: UpdatePersonInputModel): Promise<GenericServiceResult>
    DeletePerson(data: DeletePersonInputModel): Promise<GenericServiceResult>
}