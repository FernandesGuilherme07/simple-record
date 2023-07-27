import axios, { AxiosInstance, AxiosResponse } from 'axios';

class HttpServer {
  private instance: AxiosInstance = axios.create({
    baseURL: "https://localhost:80/",
  });

  private handleResponse<T>(response: AxiosResponse<T>): T {
    return response.data;
  }

  private handleError(error: any): never {
    throw new Error(`HTTP Request Error: ${error.message}`);
  }

  public async get<T>(url: string, params?: any): Promise<T> {
    try {
      const response = await this.instance.get<T>(url, { params });
      return this.handleResponse<T>(response);
    } catch (error) {
      this.handleError(error);
    }
  }

  public async post<T>(url: string, data: any): Promise<T> {
    try {
      const response = await this.instance.post<T>(url, data);
      return this.handleResponse<T>(response);
    } catch (error) {
      this.handleError(error);
    }
  }

  public async put<T>(url: string, data: any): Promise<T> {
    try {
      const response = await this.instance.put<T>(url, data);
      return this.handleResponse<T>(response);
    } catch (error) {
      this.handleError(error);
    }
  }

  public async delete<T>(url: string, params?: any): Promise<T> {
    try {
      const response = await this.instance.delete<T>(url, { params });
      return this.handleResponse<T>(response);
    } catch (error) {
      this.handleError(error);
    }
  }
}

export default HttpServer;
