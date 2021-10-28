import axios from "axios";
import authHeader from "./auth-header";

const API_URL = "https://localhost:44373/api/";

const getCategories = () => {
  return axios.get(API_URL + "categories", { headers: authHeader() });
};

const getCategory = (id) => {
  return axios.get(API_URL + `categories/${id}`, { headers: authHeader() });
};

const createCategory = (data) => {
  return axios.post(API_URL + "categories", data, { headers: authHeader() });
};

const updateCategory = (id, data) => {
  return axios.put(API_URL + `categories/${id}`, data, {
    headers: authHeader(),
  });
};

const removeCategory = (id) => {
  return axios.delete(API_URL + `categories/${id}`, { headers: authHeader() });
};

const removeAll = () => {
  return axios.delete(`categories`);
};

const findByTitle = (title) => {
  return axios.get(`categories?title=${title}`);
};

// eslint-disable-next-line import/no-anonymous-default-export
export default {
  getCategories,
  getCategory,
  createCategory,
  updateCategory,
  removeCategory,
  removeAll,
  findByTitle,
};
