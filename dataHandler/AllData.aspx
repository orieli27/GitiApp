<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllData.aspx.cs" Inherits="dataHandler.WebForm1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .itemImage {
            width: 200px;
            height: 200px;
        }

        .rating {
            width: 3em;
            height: 3em;
            cursor: pointer;
            background-repeat: no-repeat;
            display: block;
        }

        .emptyStar {
            background-image: url("images/rating/ratingStarEmpty.png");
        }

        .fullStar {
            background-image: url("images/rating/ratingStarFilled.png");
        }

        .thinkStar {
            background-image: url("images/rating/ratingStarSaved.png");
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

        .flex-item {
            margin: 10px 40px 30px 0;
            padding: 20px;
            background-color: white;
            border-radius: 10px;
            display: inline-block;
        }

        .item-image {
            width: 200px;
            height: 150px;
            background-size: cover;
            border-radius: 5px;
        }

        .item-title {
            color: #383838;
            font-weight: bold;
        }

        /*.item {
            width: 20em;
            height: 20em;
            font-size: smaller;
            font-weight: bold;
            border: double;
        }*/

        .item div {
            background-color: #00ffff;
        }

        /*span {
            padding: 2em;
            text-align: center;
        }*/
    </style>



    <div class="container-fluid" style="background-color: #d9e1e8; padding: 72px 0;">
        <div class="container">
            <h2>Browse all images</h2>

            <asp:Panel ID="Panel1" BackImageUrl="~/Content/back.jpeg" runat="server">
                <div class="row">
                    <div class="col-xs-12 col-sm-6">
                        <div class="form-group">
                            <label id="Name">Please Enter Picture Name:</label>
                            <asp:TextBox ID="NameBox" CssClass="form-control input-lg" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="SearchB" runat="server" Text="Search" OnClick="SearchB_Click" CssClass="btn btn-success btn-lg" />
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6">
                        <div class="form-group">
                            <label><i>OR</i> Select category</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="mainCategory"
                                AutoPostBack="True"
                                CssClass="drop form-control input-lg"
                                OnSelectedIndexChanged="mainCategory_SelectedIndexChanged"
                                runat="server">

                                <asp:ListItem Value="Food"> Food </asp:ListItem>
                                <asp:ListItem Value="Transportation"> Transportation </asp:ListItem>
                                <asp:ListItem Value="Animales"> Animales </asp:ListItem>
                                <asp:ListItem Value="Feelings"> Feelings </asp:ListItem>
                                <asp:ListItem Selected="True" Value="General"> General </asp:ListItem>

                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="secondery" OnSelectedIndexChanged="secondery_SelectedIndexChanged1"
                                AutoPostBack="True" CssClass="drop form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <%--<asp:Image ID="Image1" runat="server" Height="97px" Width="118px" />
                <br />
                <br />

                <br />
                <asp:Label ID="status" runat="server"></asp:Label>
                <br />
                <br />--%>
            </asp:Panel>

        </div>
    </div>


    <div class="container-fluid" style="background-color: #004e66; padding: 72px 0;">
        <div class="container">
            <h2 style="color: #e1eef6;">Gallery</h2>

            <div>
                <div>
                    <asp:ListView ID="list" runat="server" OnItemDeleting="OnListItemDeleting"
                        OnItemDataBound="OnBlobDataBound">
                        <LayoutTemplate>
                            <div>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </div>
                        </LayoutTemplate>
                        <EmptyDataTemplate>
                            <h4 style="color: #e1eef6;">No Items where found matching your cratiria</h4>
                        </EmptyDataTemplate>
                        <ItemTemplate>
                            <div class="flex-item">
                                <div class="item-wrapper">
                                    <div>
                                        <asp:LinkButton ID="SaveToGallery"
                                            OnClientClick="return confirm('Add image to your gallery?');"
                                            CommandName="AddToGallery"
                                            CommandArgument='<%# Eval("BlobName") %>'
                                            OnCommand="add_Command"
                                            Style="float: right"
                                            runat="server">
                                        <span class="glyphicon glyphicon-floppy-save"></span>
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="ban" Style="float: right" runat="server">
                                        <span aria-hidden="true" class="glyphicon glyphicon-ban-circle"></span>
                                        </asp:LinkButton>
                                    </div>
                                    <a target="_blank" href='<%# Eval("PicUrl")%>'>
                                        <div class="item-image" style="background-image: url('<%# Eval("PicUrl")%>');"></div>
                                    </a>
                                    <div style="color: #383838; font-weight: bold;" class="text-center"><%# Eval("Text") %></div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
