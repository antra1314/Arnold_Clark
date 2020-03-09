<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ArnoldClark._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   

    <div class="row">
        <div class="col-md-4">
            <h2>Get Quote</h2>
            <asp:Table runat="server" Width="800">      
               
               <asp:TableRow>
                   <asp:TableCell Width="100">                   
                       <label>Vehicle Price:</label>
                   </asp:TableCell>              
                   <asp:TableCell>  
					   <asp:TextBox ID="txtVehiclePrice" runat="server">0</asp:TextBox>
                    </asp:TableCell>  
                   <asp:TableCell>  
                       <asp:Label ID="lblVehiclePriceIsNotValid" runat="server" Text="" ForeColor="red"></asp:Label>
                    </asp:TableCell>  
               </asp:TableRow>
               <asp:TableRow>
                    <asp:TableCell>  
                       <label>Deposit Amount:</label>
                    </asp:TableCell>                
                    <asp:TableCell>  
                       <asp:TextBox ID="txtDepositAmount" runat="server">0</asp:TextBox>
					   
                    </asp:TableCell>  
                    <asp:TableCell>  
                       <asp:Label ID="lblMinDepositError" runat="server" Text="" ForeColor="red"></asp:Label>
                    </asp:TableCell>  
               </asp:TableRow>
              <asp:TableRow>
                    <asp:TableCell>  
                       <label>Delivery Date:</label>
                    </asp:TableCell>                
                    <asp:TableCell>                          
					   <asp:Calendar ID="calendarDeliveryDate" runat="server" Visible="true" OnSelectionChanged="calendarDeliveryDate_SelectionChanged"></asp:Calendar>
                    </asp:TableCell>  
                   <asp:TableCell>  
                       <asp:Label ID="lblDeliveryDateError" runat="server" Text="" ForeColor="red"></asp:Label>
                    </asp:TableCell>  
              </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>  
                       <label>Finance Options (Yrs):</label>
                    </asp:TableCell>                
                    <asp:TableCell>  
					   <asp:DropDownList ID="drpFinanceYear" Width="50px" runat="server">
						   <asp:ListItem>1</asp:ListItem>
						   <asp:ListItem>2</asp:ListItem>
						   <asp:ListItem>3</asp:ListItem>
					   </asp:DropDownList>
                    </asp:TableCell>  
                </asp:TableRow>
               <asp:TableRow>
                    <asp:TableCell>  
				   <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                       <br />
                        </asp:TableCell>  
            </asp:TableRow>
           </asp:Table>
           
            <br />
            <asp:Table runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>
                        <asp:Label runat="server" ID="lblSummary" Visible="false"> Summary:</asp:Label>                       
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                     <asp:TableCell>  
                        <asp:GridView ID="grdSummary" runat="server">
                        </asp:GridView>
                     </asp:TableCell>  
                </asp:TableRow>
           </asp:Table>
        </div>

    </div>

	

</asp:Content>
