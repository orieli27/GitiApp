<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="dataHandler._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div data-ng-app="gitiApp" data-ng-controller="homeController">
        <div class="container-fluid" style="background-color: #47b8e0;">
            <div class="container">
                <div class="row" style="padding: 36px 0;">
                    <div class="col-sm-12">
                        <h1 style="color: #ffffff;">
                            <span style="font-weight: bold;">Giti Project: </span>
                            <span>Graphical Interactive Touch Interface</span>
                        </h1>
                        <br />
                        <p class="lead" style="color: #e1eef6;">
                            The easiest way for people with speech disorders to communicate and take part in everyday conversations!
                        <br />
                            A platform for everyone to take part and help enrich the vocabulary, support and imprase the speech disorder community
                        </p>
                    </div>
                </div>

                <div class="row steps" style="padding: 36px 0 72px 0;">
                    <div class="col-xs-12 col-sm-4" ng-mouseover="selectedStep = 1">
                        <div class="step text-center" data-ng-class="{ 'selected' : selectedStep == 1}">
                            <div class="icon" style="font-size: 108px;">
                                <span class="glyphicon glyphicon-pencil"></span>
                            </div>
                            <div class="text" style="font-size: 24px;">
                                <b>1. </b><span>Login or register</span>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4" ng-mouseover="selectedStep = 2">
                        <div class="step text-center" data-ng-class="{ 'selected' : selectedStep == 2}">
                            <div class="icon" style="font-size: 108px;">
                                <span class="glyphicon glyphicon-picture"></span>
                            </div>
                            <div class="text" style="font-size: 24px;">
                                <b>2. </b><span>Upload & select images</span>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4" ng-mouseover="selectedStep = 3">
                        <div class="step text-center" data-ng-class="{ 'selected' : selectedStep == 3}">
                            <div class="icon" style="font-size: 108px;">
                                <span class="glyphicon glyphicon-thumbs-up"></span>
                            </div>
                            <div class="text" style="font-size: 24px;">
                                <b>3. </b><span>Start learning!</span>
                            </div>
                        </div>
                    </div>

                    <div class="hidden-xs col-sm-1"></div>
                    <div class="col-xs-12 col-sm-10" style="color: white; padding: 36px 0 0 0; font-size: 18px;">
                        <div data-ng-show="selectedStep == 1">
                            <b>Explanation about step 1</b>.Register Or Login with your cridentials will allow you to add your own items. You can add user under your user name and manage them from one place. registering will also allow you to rate items and help by taking part building first ever image languge.
                        </div>
                        <div data-ng-show="selectedStep == 2">
                            <b>Explanation about step 2</b>.Adding images from diffrent sources and formats (jpg,bmp,png & jpeg), please refrane frome adding offensive images or images under copy rights, as a user you can take part by enrich the vocebulary of people that are speech impaired.
                        </div>
                        <div data-ng-show="selectedStep == 3">
                            <b>Explanation about step 3</b> .Anyone can now use the resources of this site to help and educate speech impaired people free of chargh.
                        </div>
                    </div>
                    <div class="hidden-xs col-sm-1"></div>
                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div class="container" style="padding: 72px 0;">

                <div class="row">
                    <div class="col-md-6 text-center">
                        <img src="https://s-media-cache-ak0.pinimg.com/236x/e9/87/25/e98725d6a3adce05487192c764162232.jpg" alt="bla" style="width: 278px; height: 228px;">
                    </div>
                    <div class="col-md-6 text-center">
                        <img src="http://theautismprogram.org/wp-content/uploads/pec.png" alt="bla2" style="width: 304px; height: 228px;">
                    </div>
                </div>
                <div class="row" style="margin-top: 72px;">
                    <div class="col-md-6 text-center">
                        <img src="https://s-media-cache-ak0.pinimg.com/originals/6b/98/f7/6b98f7244f953a3ef685244a3e9150cd.gif" alt="bla1" style="width: 304px; height: 228px;">
                    </div>
                    <div class="col-md-6 text-center">
                        <img src="http://a4.mzstatic.com/us/r30/Purple/v4/64/0e/6a/640e6a46-7aba-15d8-df6a-5f3b974dcacf/screen480x480.jpeg" alt="bla3" style="width: 230px; height: 228px;">
                    </div>
                </div>
            </div>
        </div>

        <div class="container-fluid" style="background-color: #d9e1e8;">
            <div class="container" style="padding: 72px 0;">
                <h2>Who are we</h2>
                <p>
                    We are 3 students that want to help connect those who have a hard time to connect.
                    <br />
                    Everyone deserves a fair chance to say and even broadcast what is on their mind, we are here to give them that chance!
                </p>
            </div>
        </div>
    </div>
</asp:Content>
