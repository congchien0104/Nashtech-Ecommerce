import axios from "axios";
import authHeader from "./auth-header";

const API_URL = "https://localhost:44373/api/";

const getCategories = () => {
  return axios.get(API_URL + "categories", { headers: authHeader() });
};

const getCategory = (id) => {
  return axios.get(`/categories/${id}`);
};

const createCategory = (data) => {
  return axios.post("/categories", data);
};

const updateCategory = (id, data) => {
  return axios.put(`/categories/${id}`, data);
};

const removeCategory = (id) => {
  return axios.delete(`/categories/${id}`);
};

const removeAll = () => {
  return axios.delete(`/categories`);
};

const findByTitle = (title) => {
  return axios.get(`/categories?title=${title}`);
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
