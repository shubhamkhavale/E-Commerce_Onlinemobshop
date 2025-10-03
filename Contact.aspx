<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="VariableMobileShop.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <style>
        .con {
            margin-bottom: 20px;
            padding-top: 30px;
            text-align: center;
            text-transform: uppercase;
        }

        .map-container {
            overflow: hidden;
            padding-bottom: 56.25%;
            position: relative;
            height: 0;
        }

        .map-container iframe {
            left: 0;
            top: 0;
            height: 100%;
            width: 100%;
            position: absolute;
        }

        .star {

            color: #e02b27;
            font-size: 1.2rem;
            margin: 0 0 0 5px;
        }
       label{
           margin-bottom:0.5rem;
       }
       .form-group{
           margin-bottom:1rem;
       }
       .in{
           max-width:500px;

       }
    </style>
    </header>

    
    <div class="container">
        <div class="con">
            <h1>Contact us</h1>
        </div>
    </div>
       <div class="container">
        <div class="row">
            <div class="col-lg-6 shadow p-3 mb-5 bg-body rounded"  >
                <h2 class="mb-4">WRITE US</h2>
                <form id="contactForm" method="post" action="#">
                    <div class="form-group">
                        <label for="name">Name <span class="star">*</span></label>
                        <asp:TextBox ID="name" name="name" CssClass="form-control in"  runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="Namevalidater" runat="server" ErrorMessage="Please Enter Name" SetFocusOnError="True" Display="Dynamic" ControlToValidate="name" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="email">Email <span class="star">*</span></label>
                        <asp:TextBox ID="email" name="email" CssClass="form-control in" runat="server" TextMode="Email" ViewStateMode="Disabled"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="EmailFieldValidator" runat="server" ErrorMessage="Please Enter Email" ControlToValidate="email" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="EmailRegularvalidetor" runat="server" ErrorMessage="Invalid Email Format" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email" SetFocusOnError="True"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label for="mobile">Mobile <span class="star">*</span></label>
                        <asp:TextBox ID="mobile" Font-Names="" CssClass="form-control in"   runat="server" TextMode="Phone" MaxLength="10" onkeypress="return(event.charCode >=48 && event.charCode<=57 || (event.charCode==8))"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="mobileFieldValidator" runat="server" ErrorMessage="Please Enter Mobile Number" Display="Dynamic" ControlToValidate="mobile" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="mobileRegularValidator" runat="server" ErrorMessage="Please Enter a Valid Mobile Number." Display="Dynamic" ForeColor="Red" ControlToValidate="mobile" ValidationExpression="^[0-9]{9,10}$" SetFocusOnError="True"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label for="message">What’s on your mind?</label>
                        <asp:TextBox ID="message" name="message" CssClass="form-control in"  runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>

                    </div>
                    <asp:Button ID="submit" CssClass="btn btn-primary" runat="server" Text="Submit" ValidateRequestMode="Enabled" OnClick="submit_Click" />
                </form>
            </div>
            </div>

        </div>
    </div>

</asp:Content>
