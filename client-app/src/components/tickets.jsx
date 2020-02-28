import React, { Component } from "react";
import { Link } from "react-router-dom";
import { toast } from "react-toastify";
import TicketsTable from "./ticketsTable";
import Pagination from "./common/pagination";
import { getTickets, deleteTicket } from "../services/ticketService";

import { paginate } from "../utils/paginate";
import _ from "lodash";
import SearchBox from "./searchBox";

class Tickets extends Component {
  state = {
    tickets: [],    
    currentPage: 1,
    pageSize: 4,
    searchQuery: "",
    selectedGenre: null,
    sortColumn: { path: "title", order: "asc" }
  };

  async componentDidMount() {   

    const { data: tickets } = await getTickets();
    this.setState({ tickets });
  }

  handleDelete = async ticket => {
    const originalTickets = this.state.tickets;
    const tickets = originalTickets.filter(m => m.id !== ticket.id);
    this.setState({ tickets });

    try {
      await deleteTicket(ticket.id);
    } catch (ex) {
      if (ex.response && ex.response.status === 404)
        toast.error("This ticket has already been deleted.");

      this.setState({ tickets: originalTickets });
    }
  };

  

  handlePageChange = page => {
    this.setState({ currentPage: page });
  };

 

  handleSearch = query => {
    this.setState({ searchQuery: query, selectedGenre: null, currentPage: 1 });
  };

  handleSort = sortColumn => {
    this.setState({ sortColumn });
  };

  getPagedData = () => {
    const {
      pageSize,
      currentPage,
      sortColumn,     
      searchQuery,
      tickets: allTickets
    } = this.state;

    let filtered = allTickets;
    if (searchQuery)
      filtered = allTickets.filter(m =>
        m.title.toLowerCase().startsWith(searchQuery.toLowerCase())
      );
    

    const sorted = _.orderBy(filtered, [sortColumn.path], [sortColumn.order]);

    const tickets = paginate(sorted, currentPage, pageSize);

    return { totalCount: filtered.length, data: tickets };
  };

  render() {
    const { length: count } = this.state.tickets;
    const { pageSize, currentPage, sortColumn, searchQuery } = this.state;
    const { user } = this.props;

    if (count === 0) return <p>There are no tickets in the database.</p>;

    const { totalCount, data: tickets } = this.getPagedData();

    return (
      <div className="row">
        <div className="col-3">
        
        </div>
        <div className="col">
          { (
            <Link
              to="/tickets/new"
              className="btn btn-primary"
              style={{ marginBottom: 20 }}
            >
              New Ticket
            </Link>
          )}
          <p>Showing {totalCount} tickets in the database.</p>
          <SearchBox value={searchQuery} onChange={this.handleSearch} />
          <TicketsTable
            tickets={tickets}
            sortColumn={sortColumn}           
            onDelete={this.handleDelete}
            onSort={this.handleSort}
          />
          <Pagination
            itemsCount={totalCount}
            pageSize={pageSize}
            currentPage={currentPage}
            onPageChange={this.handlePageChange}
          />
        </div>
      </div>
    );
  }
}

export default Tickets;
