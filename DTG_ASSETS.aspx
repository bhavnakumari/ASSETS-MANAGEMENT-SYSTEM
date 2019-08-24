<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DTG_ASSETS.aspx.cs" Inherits="DTG_ASSETS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>DTG ASSETS</title>
    <style>
            body{
                font-size:50 px; 
                text-align:center;
                background-image: url("https://www.google.com/url?sa=i&source=images&cd=&ved=2ahUKEwiUraKnx7vjAhVo8XMBHQkaBjwQjRx6BAgBEAU&url=https%3A%2F%2Fdtv.nagra.com%2Fnode%2F228&psig=AOvVaw2TbAikMVDtPHHB2KUqCWqG&ust=1563439232232083");
                background-repeat: no-repeat;
                background-position: center;
                background-attachment: fixed;

                }
       
    </style>
       <link rel="stylesheet" href="Style/chosen.css" />
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">        $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    <style>
     <style type="text/css">
        a img
        {
            border: none;
        }
        ol li
        {
            list-style: decimal outside;
        }
        div#container
        {
            margin: 0 auto;
            padding: 1em 0;
        }
        div#container1
        {
            margin: 0 auto;
            padding: 1em 0;
        }
        div.side-by-side
        {
            width: 111%;
            margin-bottom: 1em;
            height: 1px;
            margin-right: 0px;
        }
        div.side-by-side > div
        {
            /*float: left;*/
            align: center;
            width: 34%;
            height: 38px;
        }
        div.side-by-side > div > em
        {
            margin-bottom: 10px;
            display: block;
        }        
        .clearfix:after
        {
            content: "\0020";
            display: block;
            height: 0;
            clear: both;
            overflow: hidden;
            visibility: hidden;
        }       
        .chzn-select
        {
        }              
          .Qtn_Style
        {
            text-align: center;
            height: 20px;
            background-color: #c0d8ed;
        }
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body style="background-color:lightblue">
    <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
                <table>

            <tr>
          
<td>

            <asp:panel ID="main_panel" runat="server" >
               

                  
            <asp:RadioButtonList ID="main_list" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="main_list_OnSelectedIndexChanged">
             
            <asp:ListItem  Text="DTG ASSETS MASTER " runat="server" Value="0" ></asp:ListItem> 
                
                 <asp:ListItem Text="DTG ASSETS ASSIGN" runat="server" Value="1"></asp:ListItem>
               
                 <asp:ListItem Text="DTG ASSETS RETERIVED" runat="server" Value="2"></asp:ListItem>
                 <asp:ListItem Text="DTG REPORT" runat="server" Value="3"></asp:ListItem>
        
            </asp:RadioButtonList>
                        
        
        
            </asp:panel>
                </td>
                </tr>
        </table>
        
        <asp:Panel ID="master_panel" runat="server" AutoPostBack="true" visible="false">
            <center>
            <fieldset style="width:50%;background-color:floralwhite">
            <b><legend >MASTER</legend></b><hr />
            
            <div>
                
                <h1><b>DTG ASSETS MASTER</b></h1>
                 <table style="width:100%;" >
            <tr>
                <td  style="text-align:right;" class="auto-style1"><asp:Label ID="DTG_asset_id1" runat="server" Text="DTG ASSET ID"></asp:Label> </td>
                <td  style="text-align:left;" class="auto-style1"><asp:TextBox ID="asset_id1" runat="server"></asp:TextBox></td>    
               
            </tr>
             <tr>
                <td  style="text-align:right;"><asp:Label ID="DTG_serial_no1" runat="server" Text="SL NO."></asp:Label> </td>
                <td style="text-align:left;"><asp:TextBox ID="serial_no1" runat="server"></asp:TextBox></td>    
               
            </tr>
             <tr>
                <td  style="text-align:right;"><asp:Label ID="DTG_type" runat="server" Text="TYPE"></asp:Label> </td>
                 <%--    <td style="text-align:left;">                       
                            <asp:DropDownList ID="type_no" runat="server" Width="180px">  
                                <asp:ListItem Value="0">--Please Select--</asp:ListItem>  
                                <asp:ListItem Value="1" Text="CPU"> </asp:ListItem>  
                                <asp:ListItem Value="2" Text="MONITOR"></asp:ListItem>  
                                <asp:ListItem Value="3" Text="SERVER"></asp:ListItem>  
                                <asp:ListItem Value="4" Text="SWITCH"></asp:ListItem>  
                                <asp:ListItem Value="5" Text="MOUSE"></asp:ListItem>
                                <asp:ListItem Value="5" Text="KEYBOARD"></asp:ListItem>  
                                 </asp:DropDownList> 
                        
                    </td>   --%> 
                     <td> <div id="container" style="width: 100%">
                    <div class="side-by-side clearfix">
                        <div>
                            <asp:DropDownList ID="drp_type" CssClass="chzn-select" AutoPostBack="true"
                                runat="server" Style="width: 370px; height: 30px;" >                        
                            </asp:DropDownList> 
                                                      
                        </div>
                    </div>
                </div>   
                            <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">        $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>                
                       </td>
               
            </tr>
             <tr>
                <td  style="text-align:right;"><asp:Label ID="DTG_po_no" runat="server" Text="PURCHASE ORDER NO."></asp:Label> </td>


                  <td> <div id="container" style="width: 100%">
                    <div class="side-by-side clearfix">
                        <div>
                            <asp:DropDownList ID="drp_po_no" CssClass="chzn-select" AutoPostBack="true"
                                runat="server" Style="width: 370px; height: 30px;" >                        
                            </asp:DropDownList> 
                                                      
                        </div>
                    </div>
                </div>   
                            <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">        $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>                
                       </td>
         
            </tr>
 
                 <tr>
                <td  style="text-align:right;"><asp:Label ID="DTG_details" runat="server" Text="DETAILS"></asp:Label> </td>
                <td style="text-align:left;"><textarea ID="details" runat="server"></textarea></td>    
               
            </tr>
           
        </table>
                <asp:Button ID="BTN1" runat="server" Text="SUBMIT" OnClick="Submit_Button_Click" CssClass="btn btn-danger" />
       
                  
            </div>
        
                </fieldset>
            </center>
            </asp:Panel>
        

          <asp:Panel ID="assign_panel" runat="server" AutoPostBack="true" visible="false">
              <center>
               <fieldset style="width:50%;background-color:floralwhite">
            <b> <legend>ASSIGN</legend></b><hr />
              <div>
                   <h1><b>DTG ASSETS ASSIGN</b></h1>
              <table style="width: 100%;">
                <tr>
                    <td style="text-align: right;">
                        <asp:Label ID="DTG_asset_id" runat="server" Text="DTG ASSET ID" ></asp:Label></td>
                    <td style="text-align: left;">
                        <asp:DropDownList ID="asset_id2" runat="server" Width="180px" AutoPostBack ="True" OnSelectedIndexChanged ="get_slno_OnClick"></asp:DropDownList></td>
                    
                </tr>
             
                <tr>
                    <td style="text-align: right;">
                        <asp:Label ID="DTG_serial_no" runat="server" Text="DTG SERIAL NO"></asp:Label></td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="serial_no2" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
               
                 <tr>
                    <td style="text-align: right;">
                        <asp:Label ID="DTG_empolyees" runat="server" Text="EMPLOYEES"></asp:Label></td>
                   <td> <div id="container" style="width: 100%">
                    <div class="side-by-side clearfix">
                        <div>
                            <asp:DropDownList ID="drp_employees" CssClass="chzn-select" AutoPostBack="true"
                                runat="server" Style="width: 370px; height: 30px;" >                        
                            </asp:DropDownList> 
                                                      
                        </div>
                    </div>
                </div>   
                            <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">        $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>                
                       </td>
                </tr>
                <tr>
                   <td style="text-align: right;"><asp:Label ID="Label1" runat="server" Text="DATE:"></asp:Label></td> 
                   
                    <td style="text-align: left;"><input type="date"/></td>

                </tr>
     
            </table>
            <asp:Button ID="assign" runat="server" Text="ASSIGN" OnClick="assign_OnClick" />
        
              </div>
                   </fieldset>
                  </center>
              </asp:Panel>


         <asp:Panel ID="retreived_panel" runat="server" AutoPostBack="true" visible="false" >
             <center>
              <fieldset style="width:50%;background-color:floralwhite">
            <b><legend >RETERIVE</legend></b><hr />

             <div>
                  <h1><b>DTG ASSETS RETERIVE</b></h1>
                  <table>
            <tr>
                <td  style="/*text-align: right;*/ width:100%"><asp:Label ID="DTG_employee_id" runat="server" Text="EMPLOYEE ID"></asp:Label> </td>


                          <td><asp:DropDownList ID="drp_employee_id" CssClass="chzn-select" AutoPostBack="true"
                                runat="server" Style="width: 370px; height: 30px; text-align:center " OnSelectedIndexChanged="assigned_details_OnSelectedIndexChanged" >                        
                            </asp:DropDownList></td>

            </tr>
               
                </table>
        
        <div>
            <asp:Panel ID="employee_panel" runat="server" >
             
    <asp:GridView ID="employee_gird" runat="server" AutoGenerateColumns="false">
         <Columns>
             <asp:TemplateField HeaderText="Select" ItemStyle-Width="0.5%" ItemStyle-Wrap="true"
                    ItemStyle-Font-Size="Small">
                    <HeaderTemplate>
                        <asp:CheckBox ID="checkall" runat="server" Text="" onclick="checkAll(this);" Visible="false" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>  
              <asp:BoundField HeaderText="record id" DataField="recIDMaster" ItemStyle-Wrap="true" ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small" ItemStyle-CssClass ="hideCol" HeaderStyle-CssClass ="hideCol"/>
             <asp:BoundField HeaderText="record id" DataField="recIDAss" ItemStyle-Wrap="true" ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small" ItemStyle-CssClass ="hideCol" HeaderStyle-CssClass ="hideCol"/>
                <asp:BoundField HeaderText="DTG ASSET ID" DataField="DTG_ASSET_ID" ItemStyle-Wrap="true" ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small"/>        
                <asp:BoundField HeaderText="SERIAL NO" DataField="SL_NO" ItemStyle-Wrap="true" ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small"/>
                        <asp:BoundField HeaderText="TYPE" DataField="TYPE" ItemStyle-Wrap="true" ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small"/>
              <asp:BoundField HeaderText="PO No" DataField="PO_NO" ItemStyle-Wrap="true" ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small"/>            
         </Columns>
        <FooterStyle BackColor="SkyBlue" />
            <HeaderStyle BackColor="SkyBlue" Font-Bold="True" BorderWidth="1px" BorderStyle="Double" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" BorderWidth="1px"
                BorderStyle="Double" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />       
    </asp:GridView>
                <asp:Button ID="retreive_btn" runat="server" Text="RETREIVE" OnClick="retreive_btn_click" />
                         
         </asp:Panel>
             
     </div>
          </div>
       
                  </fieldset>
                   </center>  
            
                </asp:Panel>

                 <asp:Panel ID="report_panel" runat="server" AutoPostBack="true" visible="false">

                     <center>
                     <fieldset style="background-color:floralwhite; width:50%"> 
                        <b><legend>DTG REPORT</legend></b> 
     
                         <div>
    <asp:GridView ID="report_grid" runat="server" AutoGenerateColumns="false">
         <Columns>
              <asp:BoundField HeaderText="DTG ASSET ID" DataField="DTG_ASSET_ID" ItemStyle-Wrap="true" ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small"/>
             <asp:BoundField HeaderText="SL_NO" DataField="SL_NO" ItemStyle-Wrap="true" ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small"/>  
                <asp:BoundField HeaderText="EMPLOYEE ID" DataField="STAFF_NO_ASSIGN_TO" ItemStyle-Wrap="true" ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small"/>           
                <asp:BoundField HeaderText="ASSIGNED DATE" DataField="ASSIGNED_DATE" ItemStyle-Wrap="true" ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small"/>          
            </Columns>
    </asp:GridView>
    </div>
    
 </fieldset>
                         </center>
         </asp:Panel>

    </form>
</body>
</html>
