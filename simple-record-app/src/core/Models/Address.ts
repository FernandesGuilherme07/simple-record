
export type Address = {
    personId: string;
    id: string
    type:  0 | 1;
    street: string;
    number: string;
    complement: string;
    neighborhood: string;
    zipCode: string;
    city: string;
    state: string;
    fullAddress: string;
}