import http from "./httpService";
import { apiUrl } from "../config.json";

const apiEndpoint = apiUrl + "/tickets";

function ticketUrl(id) {
  return `${apiEndpoint}/${id}`;
}

export function getTickets() {
  return http.get(apiEndpoint);
 
}

export function getTicket(ticketId) {
  return http.get(ticketUrl(ticketId));
}

export function saveTicket(ticket) {
  if (ticket.id) {
    const body = { ...ticket };
    delete body.id;
    
    return http.put(ticketUrl(ticket.id), body);

  }

  return http.post(apiEndpoint, ticket);
}

export function deleteTicket(ticketId) {
  return http.delete(ticketUrl(ticketId));
}
