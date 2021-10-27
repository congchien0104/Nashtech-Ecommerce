import axios from "axios";
import authHeader from "./auth-header";

const API_URL = "https://localhost:44373/api/";

const getCustomers = () => {
  return axios.get(API_URL + "Customers", { headers: authHeader() });
};

// eslint-disable-next-line import/no-anonymous-default-export
export default {
  getCustomers,
};
