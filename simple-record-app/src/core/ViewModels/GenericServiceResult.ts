export type GenericServiceResult<T = any> = {
    message: string;
    success: boolean;
    data: T;
}