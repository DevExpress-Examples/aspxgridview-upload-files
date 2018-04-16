<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function OnFileUploadComplete(s, e) {
            if (e.callbackData !== "") {
                lblFileName.SetText(e.callbackData);
                btnDeleteFile.SetVisible(true);
            }
        }
        function OnClick(s, e) {
            callback.PerformCallback(lblFileName.GetText());
        }
        function OnCallbackComplete(s, e) {
            if (e.result === "ok") {
                lblFileName.SetText(null);
                btnDeleteFile.SetVisible(false);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" OnCustomErrorText="ASPxGridView1_CustomErrorText" OnRowUpdating="ASPxGridView1_RowUpdating"
                DataSourceID="SqlDataSource1" KeyFieldName="ProductID">
                <Columns>
                    <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="true">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="CategoryID" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn FieldName="Discontinued" VisibleIndex="5">
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataTextColumn FieldName="Url" UnboundType="Object" VisibleIndex="6">
                        <DataItemTemplate>
                            <dx:ASPxHyperLink ID="ASPxHyperLink" OnLoad="ASPxHyperLink_Load" runat="server" Target="_blank" Text="No data uploaded">
                            </dx:ASPxHyperLink>
                        </DataItemTemplate>
                        <EditItemTemplate>
                            <dx:ASPxLabel ID="lblAllowebMimeType" runat="server" Text="Allowed image types: jpeg, jpg" Font-Size="8pt" />
                            <br />
                            <dx:ASPxLabel ID="lblMaxFileSize" runat="server" Text="Maximum file size: 4Mb" Font-Size="8pt" />
                            <br />
                            <dx:ASPxUploadControl ID="ASPxUploadControl1" ShowProgressPanel="true" UploadMode="Auto" AutoStartUpload="true" FileUploadMode="OnPageLoad"
                                OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete" runat="server">
                                <ValidationSettings MaxFileSize="4194304" MaxFileSizeErrorText="Size of the uploaded file exceeds maximum file size" AllowedFileExtensions=".jpg,.jpeg">
                                </ValidationSettings>
                                <ClientSideEvents FileUploadComplete="OnFileUploadComplete" />
                            </dx:ASPxUploadControl>
                            <br />
                            <dx:ASPxLabel ID="lblFileName" runat="server" ClientInstanceName="lblFileName" Font-Size="8pt" />
                            <dx:ASPxButton ID="btnDeleteFile" RenderMode="Link" runat="server" ClientVisible="false" ClientInstanceName="btnDeleteFile" AutoPostBack="false" Text="Remove">
                                <ClientSideEvents Click="OnClick" />
                            </dx:ASPxButton>
                        </EditItemTemplate>
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
                SelectCommand="SELECT [ProductID], [ProductName], [CategoryID], [UnitPrice], [Discontinued] FROM [Products]"
                UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [CategoryID] = @CategoryID, [UnitPrice] = @UnitPrice, [Discontinued] = @Discontinued WHERE [ProductID] = @ProductID">
                <UpdateParameters>
                    <asp:Parameter Name="ProductName" Type="String" />
                    <asp:Parameter Name="CategoryID" Type="Int32" />
                    <asp:Parameter Name="UnitPrice" Type="Decimal" />
                    <asp:Parameter Name="Discontinued" Type="Boolean" />
                    <asp:Parameter Name="ProductID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="callback" OnCallback="ASPxCallback1_Callback">
                <ClientSideEvents CallbackComplete="OnCallbackComplete" />
            </dx:ASPxCallback>
        </div>
    </form>
</body>
</html>