import axios from "axios";
import authHeader from "./auth-header";

const API_URL = "https://localhost:44373/api";

const getProducts = () => {
  return axios.get(API_URL + "/products", { headers: authHeader() });
};

const getProduct = (id) => {
  return axios.get(API_URL + `/products/${id}`, { headers: authHeader() });
};

const createProduct = (data) => {
  return axios.post(API_URL + "/products", data, { headers: authHeader() });
};

const updateProduct = (id, data) => {
  console.log(id);
  return axios.put(API_URL + `/products/${id}`, data, {
    headers: authHeader(),
  });
};

const removeProduct = (id) => {
  return axios.delete(API_URL + `/products/${id}`, { headers: authHeader() });
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
