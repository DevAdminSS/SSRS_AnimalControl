<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DALIncidents.aspx.cs" Inherits="AnimalControl.DALIncidents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="PanData" UpdateMode="Conditional" ChildrenAsTriggers="false">
      
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnInsert" />
            <asp:AsyncPostBackTrigger ControlID="btnUpdate" />
            <asp:AsyncPostBackTrigger ControlID="btnClear" />
        </Triggers>
    <ContentTemplate>
    <div>
        <table id="Tbl1" class="PrjLeft">
            <tr>
                <td colspan="3" class="lblMiddle">
                    Enter or Update Incident Information</td>
            </tr>
            <tr>
                <td >
                    &nbsp;
                </td>
            </tr>
               <tr>
                <td class="lblRight">
                    ID</td>
                <td class="lblLeft" >
                    <asp:TextBox runat="server" ID="txtID"  MaxLength="30" TabIndex="1" Enabled ="false"></asp:TextBox>

                </td>
                <td class="lblRight">
                    &nbsp;</td>
                <td class="lblLeft">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="lblRight">
                    Date</td>
                <td class="lblLeft" >
                    <asp:TextBox runat="server" ID="txtDate"  MaxLength="30" TabIndex="1"  AutoPostBack="True"></asp:TextBox>
                    <asp:ImageButton ID="imgCal" runat="server"  ImageUrl="~/Images/calendar.png"  ImageAlign="AbsMiddle" />
                   <ajaxToolkit:CalendarExtender ID="dtDate" runat="server" DefaultView="Days" TargetControlID="txtDate" PopupButtonID="imgCal" />
                </td>
                <td class="lblRight">
                    &nbsp;</td>
                <td class="lblLeft">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="lblRight">
                    CIT/WWW #</td>
                <td class="lblLeft" >
                    <asp:TextBox runat="server" ID="txtCIT"  MaxLength="255" TabIndex="2" AutoPostBack="True"></asp:TextBox>
                </td>
                <td class="lblRight">
                    &nbsp;</td>
                <td class="lblLeft">
                    &nbsp;</td>
            </tr>
            <tr>
                 <td class="lblRight">
                     Animal Name</td>
                <td class="lblLeft" >
                    <asp:TextBox runat="server" ID="txtAnimal"  MaxLength="255" TabIndex="3" AutoPostBack="True"></asp:TextBox>
                </td>
                <td class="lblRight">
                    &nbsp;</td>
                <td class="lblLeft">
                    &nbsp;</td>
            </tr>
            <tr>
                 <td class="lblRight">
                     Breed</td>
                <td class="lblLeft" >
                      <asp:TextBox runat="server" ID="txtBreed"  MaxLength="255" TabIndex="3" AutoPostBack="True"></asp:TextBox>
                </td>
                <td class="lblRight">
                    &nbsp;</td>
                <td class="lblLeft">
                    &nbsp;</td>
            </tr>

            <tr>
                 <td class="lblRight">
                     Disposition</td>
                 <td class="lblLeft" >
                      <asp:TextBox runat="server" ID="txtDisposition"  MaxLength="255" TabIndex="3" AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
                        <tr>
                 <td class="lblRight">
                     Owner Name(First Last)</td>
                 <td class="lblLeft" >
                    <asp:TextBox runat="server" ID="txtOwnerFirst" Width="161px" MaxLength="100" TabIndex="11" AutoPostBack="True"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtOwnerLast" Width="161px" MaxLength="100" TabIndex="11" AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                 <td class="lblRight">
                     DOB</td>
                 <td class="lblLeft" >
                    <asp:TextBox runat="server" ID="txtDOB" Width="325px" MaxLength="100" TabIndex="12" AutoPostBack="True"></asp:TextBox>
                    <asp:ImageButton ID="imgDOB" runat="server"  ImageUrl="~/Images/calendar.png" ImageAlign="AbsMiddle" />
                    <ajaxToolkit:CalendarExtender ID="dtDOB" runat="server" DefaultView="Days" TargetControlID="txtDOB" PopupButtonID="imgDOB" />
                </td>
            </tr>
                        <tr>
                 <td class="lblRight">
                     Address</td>
                 <td class="lblLeft" >
                    <asp:TextBox runat="server" ID="txtAddr" Width="325px" MaxLength="100" TabIndex="13" AutoPostBack="True"></asp:TextBox>
               
                </td>
            </tr>
            <tr>
                <td class="lblRight">
                    Officer</td>
                <td class="lblLeft" >
                    <asp:TextBox runat="server" ID="txtOfficer"  MaxLength="300"  Width="350px" TabIndex="14" AutoPostBack="True"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td class="lblRight">
                    Area Picked Up</td>
                <td class="lblLeft">
                    <asp:TextBox runat="server" ID="txtAreaPickedUp"  MaxLength="500" Height="70px" Width="350px" TextMode="MultiLine" TabIndex="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="lblRight">
                    Comments</td>
                <td class="lblLeft" >
                    <asp:TextBox runat="server" ID="txtComments"  MaxLength="255" Height="70px" Width="350px" TextMode="MultiLine" TabIndex="16"></asp:TextBox>

                    <asp:Button ID="btnInsert" Text="Save" runat="server" OnClick="InsertRec" Enabled="true" />
                     <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="UpdateRec" enabled="false" />
                    <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="Clear"  />
                   
                    <asp:Button ID="btnTransfer" runat="server" OnClientClick="return Transfer();" Visible="false" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td class="lblMid">
                    <asp:Label ID="lblSuccess" runat="server" Text="Record Inserted Successfully!" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
      </div>
    </ContentTemplate>
   </asp:UpdatePanel>
    
</asp:Content>
