
import { Address } from "../Models/Address";

export type GetAllPeoplesViewModel = {
    id: string;
    name: string;
    document: string;
    type:  0 | 1;
    contact: string;
    email?: string; 
    addressesResidentials?: Address[];
    addressesCommercials?: Address[];
}