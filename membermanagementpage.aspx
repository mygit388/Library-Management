<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="membermanagementpage.aspx.cs" Inherits="WebApplication2.membermanagementpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });
   </script>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                         <div class="row">
                            <div class="col">
                                <center>
                                   <h3>Member Details</h3>
                                </center>
                            </div>
                         </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/generaluser.png" />     
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col"> 
                               <hr>                           
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                               <label>Member ID</label>                
                               <div class="form-group">
                                   <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Member ID "></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button5" runat="server" Text="Go" OnClick="Button5_Click" />
                                    </div>
                                                           
                               </div> 
                            </div>
                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Full Name" ReadOnly="True"></asp:TextBox>    
                                </div>
                                
                            </div>
                            <div class="col-md-5">
                               <label>Account Status</label>                
                               <div class="form-group">
                                   <div class="input-group">
                                     <asp:TextBox CssClass="form-control mr-1" ID="TextBox3" runat="server" placeholder="Accout Status" ReadOnly="True"></asp:TextBox> 
                                     <asp:LinkButton class="btn btn-success mr-1" ID="Button1" runat="server" Text="A" OnClick="Button1_Click"> <i class="fas fa-check-circle"></i></asp:LinkButton>
                                     <asp:LinkButton class="btn btn-warning mr-1" ID="Button2" runat="server" Text="P" OnClick="Button2_Click"> <i class="fas fa-pause-circle"></i></asp:LinkButton>
                                     <asp:LinkButton class="btn btn-danger mr-1" ID="Button3" runat="server" Text="D" OnClick="Button3_Click" > <i class="fas fa-times-circle"></i></asp:LinkButton>
                                   </div>
                               </div> 
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                               <label>DOB</label>                
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="DOB" TextMode="Date" ReadOnly="True"></asp:TextBox>                         
                               </div> 
                            </div>
                            <div class="col-md-4">
                                <label>Contact No</label>
                                <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Contact No " ReadOnly="True" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-5">
                                <label>Email</label>
                                <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Email " ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                               <label>State</label>                
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Sate"  ReadOnly="True"></asp:TextBox>                         
                               </div> 
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="City " ReadOnly="True" ></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-5">
                                <label>Pin Code</label>
                                <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Pin Code " ReadOnly="True" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                               <label>Full Postal Address</label>                
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Address" ReadOnly="True"></asp:TextBox>                         
                               </div> 
                            </div>
                            
                        </div>
                        <div class="row">
                            <div class="col">

                                <asp:Button class="btn btn-lg btn-block btn-danger" ID="Button6" runat="server" Text="Delete User Permanently" OnClick="Button6_Click" />

                            </div>
                                                    
                       </div>
                        </div>
                    </div>
                <a href="homepage.aspx">Back to Home</a><br><br>
            </div>
              
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Members List</h4>  
                                </center>
                            </div>
                         </div>
                        <div class="row">
                            <div class="col"> 
                               <hr>                           
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col"> 
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [member_master_tb]"></asp:SqlDataSource>
                                <asp:GridView class= "table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="memb_ID" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="full_name" HeaderText="full_name" SortExpression="full_name" />
                                        <asp:BoundField DataField="dob" HeaderText="dob" SortExpression="dob" />
                                        <asp:BoundField DataField="contact_no" HeaderText="contact_no" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="state" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                                        <asp:BoundField DataField="pincode" HeaderText="pincode" SortExpression="pincode" />
                                        <asp:BoundField DataField="full_address" HeaderText="full_address" SortExpression="full_address" />
                                        <asp:BoundField DataField="memb_ID" HeaderText="memb_ID" ReadOnly="True" SortExpression="memb_ID" />
                                        <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                                        <asp:BoundField DataField="acct_status" HeaderText="acct_status" SortExpression="acct_status" />
                                    </Columns>
                                </asp:GridView>                           
                            </div>
                        </div>
                  </div>
                </div>
            </div>
        </div>
        </div>
</asp:Content>
