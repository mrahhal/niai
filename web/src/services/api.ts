import { SearchResult } from '@/models';
import { Metadata } from '@/models/metadata';
import axios from 'axios';

const API_URL = process.env.VUE_APP_API_URL;

export class Api {
  async search(q: string) {
    const params = new URLSearchParams({ q });
    const response = await axios.get<SearchResult>(`${API_URL}/api/search`, { params });
    return response.data;
  }

  async getMetadata() {
    const response = await axios.get<Metadata>(`${API_URL}/api/meta`);
    return response.data;
  }
}

export const api = new Api();
