export type CreateAddressPersonInputModel = {
    PersonId: string;
    type: 0 | 1;
    street: string;
    number: number;
    complement?: string;
    neighborhood: string;
    zipCode: string;
    city: string;
    state: string;
}