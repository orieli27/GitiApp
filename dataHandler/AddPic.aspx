<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPic.aspx.cs" Inherits="dataHandler.AddPic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <script>
        function playclip() {
            var audio = document.getElementsByTagName("audio");
            audio.play();
        }
    </script>
    <style type="text/css">
        .itemImage {
            width: 200px;
            height: 200px;
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

        /*.item {
            width: 20em;
            height: 20em;
            font-size: smaller;
            font-weight: bold;
            border: double;
        }*/

        /*.item div {
            background-color: #00ffff;
        }*/

        /*span {
            padding: 2em;
            text-align: center;
        }*/
    </style>

    <div class="container-fluid" style="background-color: #d9e1e8; padding: 72px 0;">
        <div class="container">
            <asp:Panel ID="Panel1" BackImageUrl="~/Content/back.jpeg" runat="server">
                <h2>Welcome! Please Create your Word Or import From Gallery</h2>

                <!--<asp:Label ID="Name" runat="server" Text="Please Enter Picture Name:"></asp:Label>-->
                <div class="form-group">
                    <label>Image Title</label>
                    <asp:TextBox ID="NameBox" CssClass="form-control input-lg" runat="server"></asp:TextBox>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <div class="form-group">
                            <label>Main Category</label>
                            <asp:DropDownList ID="mainCategory"
                                AutoPostBack="True"
                                CssClass="drop form-control input-lg"
                                Style="min-width: 250px;"
                                OnSelectedIndexChanged="mainCategory_SelectedIndexChanged"
                                runat="server">

                                <asp:ListItem Value="Food"> Food </asp:ListItem>
                                <asp:ListItem Value="Transportation"> Transportation </asp:ListItem>
                                <asp:ListItem Value="Animales"> Animales </asp:ListItem>
                                <asp:ListItem Value="Feelings"> Feelings </asp:ListItem>
                                <asp:ListItem Selected="True" Value="General"> General </asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <div class="form-group">
                            <label>Sub-Category</label>
                            <asp:DropDownList ID="secondery" CssClass="drop form-control input-lg" Style="min-width: 250px;" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <div class="form-group">
                            <label>Image File</label>
                            <asp:FileUpload ID="FileUp" runat="server" />
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <div class="form-group">
                            <label>Sound File</label>
                            <asp:FileUpload ID="FileUp1" runat="server" />
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" id="rd_check" data-style="btn-group-justified" runat="server">
                                    <span>Public</span>
                                </label>
                            </div>

                        </div>
                    </div>
                </div>

                <%--<asp:Button ID="UploagSnd" runat="server" Text="Upload Sound" OnClick="UploagSnd_Click" CssClass="myButton" />--%>
                <br />
                <asp:Button ID="UploadImg" runat="server" Text="Upload Image" OnClick="Upload_Click" CssClass="btn btn-success btn-lg" />

                <asp:Label ID="status" runat="server"></asp:Label>

                <br />
                <br />
            </asp:Panel>

        </div>
    </div>
    <div class="container-fluid" style="background-color: #004e66; padding: 72px 0;">
        <div class="container">
            <h2 style="color: #e1eef6">Your Gallery</h2>
            <asp:ListView ID="list" runat="server" OnItemDeleting="OnListItemDeleting"
                OnItemDataBound="OnBlobDataBound">
                <LayoutTemplate>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="flex-container" style="display: flex;">
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </div>
                        </div>
                    </div>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <h4 class="text-center" style="color: #e1eef6;">no images to show</h4>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div class="flex-item" style="margin: 10px; padding: 20px; background-color: white; border-radius: 10px; display: inline-block;">

                        <div class="item-wrapper">
                            <asp:LinkButton ID="deleteBlob"
                                OnClientClick="return confirm('Delete image?');"
                                CommandName="Delete"
                                CommandArgument='<%# Eval("Name")%>'
                                Style="float: right"
                                runat="server" Text="<span class='glyphicon glyphicon-trash'></span>" OnCommand="OnDeleteImage" />
                            <br />
                            <asp:ImageButton ID="img" ImageUrl='<%# Eval("Uri")%>' CssClass="itemImage" runat="server" />
                            <%--<img src="<%# Eval("Uri") %>" alt="<%# Eval("Uri") %>"  style="margin-left: 4em" />--%>
                            <asp:Repeater ID="blobMetadata" runat="server">
                                <ItemTemplate>
                                    <div class="text-center"><%# Eval("Text") %><span><%# Eval("Rating") %></span></div>

                                </ItemTemplate>
                            </asp:Repeater>



                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>

    </div>

</asp:Content>

