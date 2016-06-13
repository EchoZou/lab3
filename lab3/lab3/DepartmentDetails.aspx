﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentDetails.aspx.cs" Inherits="lab3.DepartmentDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>Department Details</h1>
                <h5>All Fields are Required</h5>
                <br />
                <div class="form-group">
                    <label class="control-label" for="DepartmentNameTextBox">Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="DepartmentNameTextBox" placeholder="Department Name" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="BudgetTextBox"> </label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="BudgetTextBox" placeholder="Budget" required="true"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Invalid number!" ControlToValidate="BudgetTextBox" MinimumValue="0" 
                        Type="Double" Display="Dynamic" BackColor="Red" ForeColor="White" Font-Size="Large"></asp:RangeValidator>
                </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" 
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>
