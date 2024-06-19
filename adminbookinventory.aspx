<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="adminbookinventory.aspx.cs" Inherits="WebApplication2.adminbookinventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
        function readURL(input)
        {
            if (input.files && input.files[0])
            {
                var reader = new FileReader();
                reader.onload = function (e)
                {
                    $('#imgview').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);

            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                         <div class="row">
                            <div class="col">
                                <center>
                                   <h3>Book Details</h3>
                                </center>
                            </div>
                         </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview" width="150px" height="100px" src="book_inventory/books1.png" />     
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
                                <asp:FileUpload onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server" />                     
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                               <label>Book ID</label>                
                               <div class="form-group">
                                   <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Book ID "></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button5" runat="server" Text="Go" OnClick="Button5_Click" />
                                    </div>
                                                           
                               </div> 
                            </div>
                            <div class="col-md-8">
                                <label>Book Name</label>
                                <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Book Name"></asp:TextBox>    
                                </div>
                                
                            </div>
                            
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                               <label>Language</label>                
                               <div class="form-group">
                                   <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">                          
                                        <asp:ListItem Text="English" Value="English"/>                                                                     <asp:ListItem Text="Malayalam" Value="Malayalam"/>
                                        <asp:ListItem Text="Hindi" Value="Hindi"/>
                                    </asp:DropDownList>
                               </div> 
                            
                               <label>Publisher Name</label>                
                               <div class="form-group">
                                   <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">                          
                                        <asp:ListItem Text="Publisher 1" Value="Publisher 1"/>                                                                     <asp:ListItem Text="Malayalam" Value="Malayalam"/>
                                        <asp:ListItem Text="Publisher 2" Value="Publisher 2"/>
                                    </asp:DropDownList>
                               </div> 
                            </div>
                            <div class="col-md-4">
                                <label>Author Name</label>                
                               <div class="form-group">
                                   <asp:DropDownList class="form-control" ID="DropDownList4" runat="server">                          
                                        <asp:ListItem Text="Author 1" Value="Author 1"/>                                                                     <asp:ListItem Text="Malayalam" Value="Malayalam"/>
                                        <asp:ListItem Text="Author 2" Value="Author 2"/>
                                    </asp:DropDownList>
                               </div>
                                <label>Publish Date</label>                
                               <div class="form-group">
                                   <asp:TextBox ID="TextBox3" runat="server" TextMode="Date"></asp:TextBox>
                               </div>
                            </div>
                             <div class="col-md-4">
                                <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox class="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple">
                                        <asp:ListItem Text="Crime" Value="Crime" />
                                        <asp:ListItem Text="Horror" Value="Horror" />
                                        <asp:ListItem Text="Drama" Value="Drama" />
                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                                         
                               <label>Edition</label>                
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server"></asp:TextBox>
                               </div> 
                            </div>
                            <div class="col-md-4">
                                <label>Book contiger unit</label>                
                               <div class="form-group">
                                   <asp:TextBox  class="form-control" ID="TextBox5" runat="server"></asp:TextBox>
                            </div>
                                </div>
                             <div class="col-md-4">
                                <label>Pages</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox6" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-4">
                                                         
                               <label>Actual Stock</label>                
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server"></asp:TextBox>
                               </div> 
                            </div>
                            <div class="col-md-4">
                                <label>Current stock</label>                
                               <div class="form-group">
                                   <asp:TextBox  class="form-control" ID="TextBox8" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                                </div>
                             <div class="col-md-4">
                                <label>Issued Books</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox9" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                               <label>Book Description</label>                
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server"></asp:TextBox>                         
                               </div> 
                            </div>
                            
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                
                                    <asp:Button class="btn btn-lg btn-block btn-success" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />   
                                
                            </div>
                                                    
                            <div class="col-md-4" style="height: 40px">                  
                               
                                  <asp:Button class="btn btn-lg btn-block btn-primary" ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />                          
                              
                            </div>
                            <div class="col-md-4">                  
                               
                                  <asp:Button class="btn btn-lg btn-block btn-danger" ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" />                          
                               
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
                                    <h4> Book Inventory List</h4>  
                                </center>
                            </div>
                         </div>
                        <div class="row">
                            <div class="col"> 
                               <hr>                           
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tb]"></asp:SqlDataSource>
                            <div class="col"> 
                                <asp:GridView class= "table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="book_ID" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="book_ID" HeaderText="ID" ReadOnly="True" SortExpression="book_ID" >
                                        
                                        <ControlStyle Font-Bold="True" Font-Size="Large" />
                                        </asp:BoundField>
                                        
                                        <asp:TemplateField>
                                            
                                            <ItemTemplate>
                                               <div class="container-fluid">
                                                   <div class="row">
                                                       <div class="col-lg-10">
                                                           <div class="row">
                                                               <div class="col-12">

                                                                   <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text='<%# Eval("book_name") %>'></asp:Label>

                                                               </div>
                                                           </div>
                                                           <div class="row">
                                                               <div class="col-12">

                                                                   Author-<asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                   &nbsp;| Genre-<asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                                   &nbsp;| Language-
                                                                   <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>

                                                               </div>
                                                           </div>
                                                           <div class="row">
                                                               <div class="col-12">

                                                                   Publisher-<asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                   &nbsp;| Publish Date-<asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                   &nbsp;| Pages-<asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_page") %>'></asp:Label>
                                                                   &nbsp;| Edition-<asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>
                                                                   &nbsp;|

                                                               </div>
                                                           </div>
                                                           <div class="row">
                                                               <div class="col-12">

                                                                   Cost-<asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                   &nbsp;| Actual Stock-<asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                   &nbsp;| Availvabel-<asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("curr_stock") %>'></asp:Label>

                                                               </div>
                                                           </div>
                                                           <div class="row">
                                                               <div class="col-12">

                                                                   Description-<asp:Label ID="Label12" runat="server" Font-Bold="True" Text='<%# Eval("book_desc") %>'></asp:Label>

                                                               </div>
                                                           </div>
                                                             

                                                       </div>
                                                       <div class="col-lg-2">
                                                           <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("bool_img_link") %>' />
                                                       </div>
                                                   </div>
                                                   
                                            </ItemTemplate>
                                            
                                        </asp:TemplateField>
                                        
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
