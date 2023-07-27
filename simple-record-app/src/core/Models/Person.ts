import { Address } from "./Address";

export type Person = {
    id: string;
    name: string;
    document: string;
    type:  0 | 1;
    contact: string;
    email?: string;
    addresses: Address[]
}