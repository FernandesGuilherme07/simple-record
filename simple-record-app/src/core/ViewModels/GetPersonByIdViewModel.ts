
import { Address } from "../Models/Address";

export type GetPersonByIdViewModel = {
    id: string;
    name: string;
    document: string;
    type:  0 | 1;
    contact: string;
    email?: string;
    addresses: Address[]
}