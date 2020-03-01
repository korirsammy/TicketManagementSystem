import React, { Component } from "react";
import { Link } from "react-router-dom";
import Table from "./common/table";


class TicketsTable extends Component {
  columns = [
    {
      path: "title",
      label: "Title",
      content: ticket => <Link to={`/tickets/${ticket.id}`}>{ticket.title}</Link>,
      
    },
    { path: "description", label: "Description" },
    { path: "city", label: "City" },
    { path: "reporter", label: "Reporter" },
    { path: "severity", label: "Severity" }
   
    
    
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
