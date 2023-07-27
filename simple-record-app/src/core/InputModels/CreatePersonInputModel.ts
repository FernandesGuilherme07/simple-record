
export type AddressCreatePerson = {
    Type: 0 | 1;
    Street: string;
    Number: string;
    Complement: string;
    Neighborhood: string;
    ZipCode: string;
    City: string;
    State: string;
}

export type CreatePersonInputModel = {
    name: string;
    document: string;
    type:  0 | 1;
    contact: string;
    email: string;
    addresses?: AddressCreatePerson[];
}