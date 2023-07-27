import { CreateAddressPersonInputModel } from "../InputModels/CreateAddressPersonInputModel";
import { DeleteAddressPersonInputModel } from "../InputModels/DeleteAddressPersonInputModel";
import { GenericServiceResult } from "../ViewModels/GenericServiceResult";

export interface IAddressPersonService {
    CreateAddressPerson(data: CreateAddressPersonInputModel): Promise<GenericServiceResult>;
    DeleteAddressPerson(data: DeleteAddressPersonInputModel): Promise<GenericServiceResult>;
}