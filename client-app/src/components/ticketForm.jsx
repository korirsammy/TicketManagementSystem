import React from "react";
import Joi from "joi-browser";
import Form from "./common/form";
import { getTicket, saveTicket } from "../services/ticketService";




class TicketForm extends Form {
  state = {
    data: {
      title: "",
      description: "",     
      city: "",
      reporter: "",
      severity: ""
    },  
    categories: [], 
    errors: {}
  };

  schema = {
    id: Joi.string(),
    title: Joi.string()
      .required()
      .label("Title"),   
    description: Joi.string()
      .required()
      .label("Description"),   
    city: Joi.string()
      .required()
      .label("City"),
    reporter: Joi.string()
      .required()
      .label("Reporter"),
    severity: Joi.string()
      .required()
      .label("Severity")
  };

  

  async populateTicket() {
    try {
      const ticketId = this.props.match.params.id;
    
      if (ticketId === "new") return;

      const { data: ticket } = await getTicket(ticketId);     
      this.setState({ data: this.mapToViewModel(ticket) });
      
    } catch (ex) {
      if (ex.response && ex.response.status === 404)
        this.props.history.replace("/not-found");
    }
  }

  async componentDidMount() {   
   
    await this.populateTicket();
    
    
    
  }

  mapToViewModel(ticket) {
    return {
      id: ticket.id,
      title: ticket.title,
      description: ticket.description,        
      city: ticket.city,
      reporter: ticket.reporter,
      severity: ticket.severity,
    };
  }

  doSubmit = async () => {
    await saveTicket(this.state.data);

    this.props.history.push("/tickets");
  };

  render() {
    return (
      <div>
        <h1>Ticket Form</h1>
        <form onSubmit={this.handleSubmit}>
          {this.renderInput("title", "Title")}    
          {this.renderInput("description", "description")}               
          {this.renderInput("city", "city")}  
          {this.renderInput("reporter", "reporter")}  
          {this.renderInput("severity", "severity")}  
          {this.renderButton("Save")}
        </form>
      </div>
    );
  }
}

export default TicketForm;
