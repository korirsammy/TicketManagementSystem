import http from "./httpService";
import { apiUrl } from "../config.json";

const apiEndpoint = apiUrl + "/user/register";

export function register(user) {
  return http.post(apiEndpoint, {
    email: user.email,
    username:user.username,
    password: user.password,
    displayName: user.displayName
  });
}
