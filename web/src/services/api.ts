import axios from 'axios';

const API_URL = process.env.VUE_APP_API_URL;

export class Api {
  async search(q: string) {
    const params = new URLSearchParams({ q });
    const response = await axios.get(`${API_URL}/api/search`, { params });
    return response.data;
  }
}

export const api = new Api();
