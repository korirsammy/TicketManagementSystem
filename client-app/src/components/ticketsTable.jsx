import React, { Component } from "react";
import auth from "../services/authService";
import { Link } from "react-router-dom";
import Table from "./common/table";


class TicketsTable extends Component {
  columns = [
    {
      path: "title",
      label: "Title",
      content: ticket => <Link to={`/tickets/${ticket.id}`}>{ticket.title}</Link>
    },
    { path: "genre.description", label: "Description" }
    
    
  ];

  deleteColumn = {
    key: "delete",
    content: ticket => (
      <button
        onClick={() => this.props.onDelete(ticket)}
        className="btn btn-danger btn-sm"
      >
        Delete
      </button>
    )
  };

  constructor() {
    super();
    const user = auth.getCurrentUser();
    //if (user && user.isAdmin) this.columns.push(this.deleteColumn);
    this.columns.push(this.deleteColumn);
  }

  render() {
    const { tickets, onSort, sortColumn } = this.props;

    return (
      <Table
        columns={this.columns}
        data={tickets}
        sortColumn={sortColumn}
        onSort={onSort}
      />
    );
  }
}

export default TicketsTable;
