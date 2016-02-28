<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllData.aspx.cs" Inherits="dataHandler.WebForm1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        img, .itemImage {
            width: 10em;
            height: 10em;
        }
        .rating {
            width: 3em;
            height: 3em;
            cursor: pointer;
            background-repeat: no-repeat;
            display: block;
        }
        .emptyStar{
            background-image:url("images/rating/ratingStarEmpty.png");
                  }
        .fullStar{
            background-image:url("images/rating/ratingStarFilled.png");
                  }
        .thinkStar{
            background-image:url("images/rating/ratingStarSaved.png");
                  }
    
        .myButton {
            -moz-box-shadow: inset 0px 0px 15px 3px #23395e;
            -webkit-box-shadow: inset 0px 0px 15px 3px #23395e;
            box-shadow: inset 0px 0px 15px 3px #23395e;
            background-color: transparent;
            -moz-border-radius: 17px;
            -webkit-border-radius: 17px;
            border-radius: 17px;
            border: 1px solid #1f2f47;
            display: inline-block;
            cursor: pointer;
            color: #23395e;
            font-family: Arial;
            font-size: 15px;
            padding: 6px 13px;
            text-decoration: none;
            text-shadow: 0px 1px 0px #263666;
        }

            .myButton:hover {
                background-color: transparent;
            }

            .myButton:active {
                position: relative;
                top: 1px;
            }


        .drop {
            width: auto;
            height: 27px;
            background-color: #FFF;
            font: 400 12px/18px 'Open Sans', sans-serif;
            color: #000;
            font-weight: normal;
            border: 1px solid #ccc;
            margin: 5px 0 0 0;
            padding: 5px;
        }

        h3 {
            color: blue;
            text-shadow: black 0.1em 0.1em 0.2em;
            margin-left: 2em;
            background-color: #ffffff;
            display: grid;
            font-style: italic;
            font-weight: normal;
            width: auto;
        }

        .item {
            width: 20em;
            height: 20em;
            font-size: smaller;
            font-weight: bold;
            border: double;
        }

            .item div {
                background-color: #00ffff;
            }

        span {
            padding: 2em;
            text-align: center;
        }
    </style>
    <asp:Panel ID="Panel1" BackImageUrl="~/Content/back.jpeg" runat="server">
        <br />
        <br />
        <asp:Label ID="Name" runat="server" Text="Please Enter Picture Name:"></asp:Label>
        <br />
        <asp:TextBox ID="NameBox" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Button ID="SearchB" runat="server" Text="Search" OnClick="SearchB_Click" CssClass="btn btn-success btn-lg" />
        <br />
        <br />
        <asp:Label ID="Category" runat="server" CssClass="drop form-control" Text="OR Select Category:"></asp:Label>
        <br />
        <asp:DropDownList ID="mainCategory"
            AutoPostBack="True"
            CssClass="drop"
            OnSelectedIndexChanged="mainCategory_SelectedIndexChanged"
            runat="server">

            <asp:ListItem Value="Food"> Food </asp:ListItem>
            <asp:ListItem Value="Transportation"> Transportation </asp:ListItem>
            <asp:ListItem Value="Animales"> Animales </asp:ListItem>
            <asp:ListItem Value="Feelings"> Feelings </asp:ListItem>
            <asp:ListItem Selected="True" Value="General"> General </asp:ListItem>

        </asp:DropDownList>
        <br />
        <br />
        <asp:DropDownList ID="secondery" OnLoad="secondery_SelectedIndexChanged1"  AutoPostBack="True" CssClass="drop form-control" runat="server"></asp:DropDownList>
        <br />

        <asp:Image ID="Image1" runat="server" Height="97px" Width="118px" />
        <br />
        <br />

        <br />
        <asp:Label ID="status" runat="server"></asp:Label>
        <br />
        <br />
    </asp:Panel>


    <asp:ListView ID="list" runat="server" OnItemDeleting="OnListItemDeleting"
        OnItemDataBound="OnBlobDataBound">
        <LayoutTemplate>
            <div class="row">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </div>
        </LayoutTemplate>
        <EmptyDataTemplate>
            <h2>No Items where found matching your cratiria</h2>
        </EmptyDataTemplate>
        <ItemTemplate>
            <div style="display: inline-block">

                <div class="item">   
                   
                    <br />

                    <asp:LinkButton ID="add" Style="float: right" runat="server" OnCommand="add_Command" CommandArgument='<%# Eval("BlobName") %>'>
                         <span aria-hidden="true"  class="glyphicon glyphicon-floppy-save"></span>
                    </asp:LinkButton>
                    <asp:LinkButton ID="ban" Style="float: right" runat="server" >
                         <span aria-hidden="true" class="glyphicon glyphicon-ban-circle"></span>
                    </asp:LinkButton>
                    <h3><%# Eval("Text") %></h3>

                    <asp:ImageButton ID="img" ImageUrl='<%# Eval("PicUrl")%>' CssClass="itemImage" Style="float:right" runat="server" />
                <%--   <asp:Label ID="labelValue1" runat="server" Text=""></asp:Label> --%> 
                   
                  
                  
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>






</asp:Content>
