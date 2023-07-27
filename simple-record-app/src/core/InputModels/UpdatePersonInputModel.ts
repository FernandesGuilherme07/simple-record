
export type AddressCreatePerson = {
    Type:  0 | 1;
    Street: string;
    Number: string;
    Complement: string;
    Neighborhood: string;
    ZipCode: string;
    City: string;
    State: string;
}

export type UpdatePersonInputModel = {
    id: string;
    name: string;
    document: string;
    type:  number;
    contact: string;
    email: string;
    addresses?: AddressCreatePerson[];
}