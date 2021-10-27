import axios from "axios";
import authHeader from "./auth-header";

const API_URL = "https://localhost:44373/api";

const getProducts = () => {
  return axios.get(API_URL + "/products", { headers: authHeader() });
};

const getProduct = (id) => {
  return axios.get(`/products/${id}`);
};

const createProduct = (data) => {
  return axios.post("/products", data);
};

const updateProduct = (id, data) => {
  return axios.put(`/products/${id}`, data);
};

const removeProduct = (id) => {
  return axios.delete(`/products/${id}`);
};

const removeAll = () => {
  return axios.delete(`/products`);
};

const findByTitle = (title) => {
  return axios.get(`/products?title=${title}`);
};

// eslint-disable-next-line import/no-anonymous-default-export
export default {
  getProducts,
  getProduct,
  createProduct,
  updateProduct,
  removeProduct,
  removeAll,
  findByTitle,
};
