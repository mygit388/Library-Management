<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="WebApplication2.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/sign-up.png" />    
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                   <h3>User SignUp</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                               <hr>                           
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                                </div>
                            
                            <div class="col-md-6">  <label>Date of Birth</label>                
                               <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>                         
                               </div>
                              </div>
                            </div>
                        <div class="row">
                            
                            <div class="col-md-6"><label>Contact No</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox3" runat="server" placeholder="Contact No"></asp:TextBox>
                                </div>
                                </div>
                            
                                
                            <div class="col-md-6"> <label>E mail</label>                 
                               <div class="form-group">
                                   <asp:TextBox class="form-control" ID="TextBox4" runat="server" placeholder="E mail"></asp:TextBox>                         
                               </div>
                              </div>
                            </div>
                        <div class="row">
                            
                            <div class="col-md-4"><label>State</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Karnataka" Value="Karnataka"/>
                                        <asp:ListItem Text="Kerala" Value="Kerala"/>
                                        <asp:ListItem Text="Tamilnadu" Value="Tamilnadu"/>
                                    </asp:DropDownList> 
                                    
                                </div>
                                </div>
                                                           
                            <div class="col-md-4"><label>City</label>                  
                               <div class="form-group">
                                   <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="City" ></asp:TextBox>                         
                               </div>
                              </div>
                            
                            <div class="col-md-4"> <label>Pin Code</label>                 
                               <div class="form-group">
                                   <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="Pin Code" ></asp:TextBox>                         
                               </div>
                              </div>
                            </div>
                        <div class="row">
                           <div class="col"> <label>Full Address</label>                 
                               <div class="form-group">
                                   <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Full Address" TextMode="MultiLine"></asp:TextBox>                         
                               </div>
                           </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>user id</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="user id"></asp:TextBox>
                                </div>
                                </div>
                            
                            <div class="col-md-6">  <label>password</label>                
                               <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>                         
                               </div>
                              </div>
                            </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                     <asp:Button class="btn btn-primary btn-block" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click"></asp:Button>
                                </div>
                             </div>
                         </div>
                        </div>
                    </div>
                <a href="homepage.aspx">Back to Home</a><br><br>
            </div>
        </div>
    </div>  
</asp:Content>
