SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectHoSoCapGCNByMaVach]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vu Le Thanh
-- Create date: 20091126
-- Description:	Select AnhMaVach theo MaHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectHoSoCapGCNByMaVach]
	@MaHoSoCapGCN BIGINT=NULL
AS
BEGIN
	SELECT TOP 1 MaSoGCN, AnhMaVach ,InMaVach
	FROM tblHoSoCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectLichSuThuaDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091103
-- Description:	Truy vấn lịch sử thửa đất
-- =============================================
CREATE PROCEDURE [dbo].[spSelectLichSuThuaDat]
	-- Add the parameters for the stored procedure here
	--@xml XML
	@xml TEXT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;

    -- Insert statements for procedure here

	DECLARE @idoc int
--	DECLARE @xmlTemp XML
--	--Kiểm tra dữ liệu trước khi thực hiện 
--	SET @xmlTemp = CONVERT(XML,@xml)
--	IF @@ERROR <> 0
--	BEGIN
--		RETURN NULL
--	END

	EXEC sp_xml_preparedocument @idoc OUTPUT,@xml
	SELECT SW_MEMBER AS MaThua ,ToBanDo,SoThua 
	FROM OPENXML(@idoc,''/root/ThuaDat'')
	WITH(
			MaThua	int	''MaThua''
		) AS xmlTable
	INNER JOIN tblDLieuKGianThuaDatLichSu ON xmlTable.MaThua = tblDLieuKGianThuaDatLichSu.SW_MEMBER
	EXEC sp_xml_removedocument @idoc
	PRINT ''Selected''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateXML]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091103
-- Description:	Cập nhật XML
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateXML]
	-- Add the parameters for the stored procedure here
	@xml XML
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	DECLARE @idoc int
	EXEC sp_xml_preparedocument @idoc OUTPUT,@xml

	UPDATE Region
	SET 
		TblDLieuKGianThuaDat.ToBanDo	=xmlTable.ToBanDo
		,TblDLieuKGianThuaDat.SoThua	=xmlTable.SoThua
		,TblDLieuKGianThuaDat.DienTichTuNhien =xmlTable.DienTichTuNhien
		,TblDLieuKGianThuaDat.featureID =xmlTable.featureID
		,TblDLieuKGianThuaDat.TYLEIN =xmlTable.TYLEIN
		,TblDLieuKGianThuaDat.Status =xmlTable.Status
		,TblDLieuKGianThuaDat.MaDonViHanhChinh =xmlTable.MaDonViHanhChinh
		,TblDLieuKGianThuaDat.MI_STYLE =xmlTable.MI_STYLE
		,TblDLieuKGianThuaDat.SW_MEMBER =xmlTable.SW_MEMBER
		,TblDLieuKGianThuaDat.SW_GEOMETRY =xmlTable.SW_GEOMETRY
		,TblDLieuKGianThuaDat.DanhSachMaThuaDatCha =xmlTable.DanhSachMaThuaDatCha

	FROM OPENXML(@idoc,''/root/TblDLieuKGianThuaDat'')
	WITH(
			ToBanDo	varchar(50)	''ToBanDo''
			,SoThua	varchar(500)	''SoThua''
			,DienTichTuNhien	decimal(19, 1)	''DienTichTuNhien''
			,featureID	varchar(100)	''featureID''
			,TYLEIN	float	''TYLEIN''
			,Status	int	''Status''
			,MaDonViHanhChinh	int	''MaDonViHanhChinh''
			,MI_STYLE	varchar(254)	''MI_STYLE''
			,SW_MEMBER	int	''SW_MEMBER''
			,SW_GEOMETRY	image	''SW_GEOMETRY''
			,DanhSachMaThuaDatCha	nvarchar(500) ''DanhSachMaThuaDatCha''
		) AS xmlTable
	WHERE
		 TblDLieuKGianThuaDat.SW_MEMBER=xmlTable.SW_MEMBER
	EXEC sp_xml_removedocument @idoc
	PRINT ''Đã cập nhật''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTrangThaiHSCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[spSelectTrangThaiHSCapGCN]
@MaHoSoCapGCN BIGINT=NULL
AS
  BEGIN 
    SELECT DISTINCT TrangThaiHoSoCapGCN
    FROM tblHoSoCapGCN
    WHERE TrangThaiHoSoCapGCN=8 AND MaHoSoCapGCN=@MaHoSoCapGCN
  END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectNoiDungThayDoi]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 20100413
--Người tạo: Quách Văn Phong ,
--Mục đích: Nhận thông tin nội dung thay đổi và cơ sở pháp lý
--In mặt 4 Giấy chứng nhận

CREATE PROCEDURE [dbo].[spSelectNoiDungThayDoi]
@MaHoSoCapGCN bigint=NULL
AS
SELECT NoidungSoBienDong,Chon
FROM tblDangKyBienDong
WHERE MaHoSoCapGCN=@MaHoSoCapGCN' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteGhiChuNoiDungChuDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091222
-- Description:	Xóa thông tin Chủ (sử dụng, sở hữu) đề nghị
-- cấp GCN theo Mã hồ sơ cấp GCN.
-- Thực chất là gán các giá trị bằng NULL
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteGhiChuNoiDungChuDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT,
	@GhiChuNoiDungChuDeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
		GhiChuNoiDungChuDeNghiCapGCN = NULL
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectRptGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 20100106
--Người tạo: Vũ Lê Thành,
--Mục đích: Nhận thông tin In GCN mặt 2-3

CREATE PROC [dbo].[spSelectRptGCN]
	@MaHoSoCapGCN bigint
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	-- Liet ke Thong tin Phe Duyet
			SELECT 
				MaHoSoCapGCN,
				GhiChuNoiDungChuDeNghiCapGCN,
				ThongTinThuaDatDeNghiCapGCN,
				ThongTinNhaODeNghiCapGCN,
				ThongTinHangMucCongTrinhDeNghiCapGCN,
				ThongTinRungCayDeNghiCapGCN,
				ThongTinCayLauNamDeNghiCapGCN,
				GhiChuGCN,
				SoVaoSoCapGCN,
				TieuDeKyGCN,
				NguoiKyGCN
			FROM   tblHoSoCapGCN
			WHERE  1 = 1
			AND(CASE @MaHoSoCapGCN
				WHEN '''' THEN @MaHoSoCapGCN  ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectSoDoNhaDatByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:	Vũ Lê Thành	
-- Create date: 20100109
-- Description:	Hiển thị Sơ đồ thửa đất
-- =============================================
CREATE PROCEDURE [dbo].[spSelectSoDoNhaDatByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT HoSoKiThuatThamDinh 
	FROM tblHoSoCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectSoHoSoGocLonNhatByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100225
-- Description:	Số Số hồ sơ gốc lớn nhất theo Mã hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectSoHoSoGocLonNhatByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT  MAX(SoHoSoGoc) AS SoHoSoGocLonNhat
	FROM tblHoSoCapGCN
	WHERE (MaXa = (Select Top 1 MaXa FROM tblHoSoCapGCN WHERE MaHoSoCapGCN = @MaHoSoCapGCN))
		AND (YEAR(NgayKyGCN) = (SELECT TOP 1 YEAR(NgayKyGCN)
			FROM tblHoSoCapGCN WHERE MaHoSoCapGCN = @MaHoSoCapGCN))
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectSoThuTuVaoSoCapGCNLonNhatTheoCapXa]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100225
-- Description:	Số thứ tự vào sổ cấp GCN lớn nhất theo cấp Xã/Phường
-- =============================================
CREATE PROCEDURE [dbo].[spSelectSoThuTuVaoSoCapGCNLonNhatTheoCapXa]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MAX(ThuTuVaoSoCapGCN) AS ThuTuVaoSoCapGCNLonNhat
	FROM tblHoSoCapGCN
	WHERE (MaXa = (Select Top 1 MaXa FROM tblHoSoCapGCN WHERE MaHoSoCapGCN = @MaHoSoCapGCN))
		AND (KyHieuThamQuyenCapGCN = ''CH'')
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThamDinhThongTinPhapLyKhacByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091222
-- Description:	Truy vấn thông tin Thẩm định
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThamDinhThongTinPhapLyKhacByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@TrangThaiHoSoCapGCN INT,
	@MaHoSoCapGCN NVARCHAR(100) = NULL,
	@NgayNopDuHoSoHopLe NVARCHAR(50) = NULL,
	@TrinhTuThuTucPhuong NVARCHAR(200) = NULL,
	@CacKhoanPhaiNop NVARCHAR(1000) = NULL,
	@GhiChuThamDinh NVARCHAR(500) = NULL,
	@LyDo nvarchar(500)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TrangThaiHoSoCapGCN, MaHoSoCapGCN 
	,NgayNopDuHoSoHopLe,TrinhTuThuTucPhuong
	,CacKhoanPhaiNop,GhiChuThamDinh,LyDoThamDinh
	FROM tblHoSoCapGCN
	WHERE  1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectSoThuTuVaoSoCapGCNLonNhatTheoCapTinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100225
-- Description:	Số thứ tự vào sổ cấp GCN lớn nhất theo cấp Tỉnh/Thành phố
-- =============================================
CREATE PROCEDURE [dbo].[spSelectSoThuTuVaoSoCapGCNLonNhatTheoCapTinh]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MAX(ThuTuVaoSoCapGCN)  AS ThuTuVaoSoCapGCNLonNhat
	FROM tblHoSoCapGCN
	WHERE KyHieuThamQuyenCapGCN = ''CT''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteSoDoNhaDatThamDinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100127
-- Description:	Xóa thông tin Sơ đồ nhà đất THẦM ĐỊNH theo Mã Hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteSoDoNhaDatThamDinhByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN	BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1
    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET HoSoKiThuatThamDinh = NULL
	WHERE (MaHoSoCapGCN = @MaHoSoCapGCN)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongBaoCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091217
-- Description:	Truy vấn thông tin Thông báo cấp GCN trong bảng
-- tblHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongBaoCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT
	,@NgayThongBaoUBND	NVARCHAR (50) = NULL
	,@NgayCongDanNhanThongBao	NVARCHAR (50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaHoSoCapGCN,NgayThongBaoUBND,NgayCongDanNhanThongBao
	FROM tblHoSoCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThamDinhThongTinPhapLyKhacByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091222
-- Description:	Xóa thông tin Thẩm định.
-- Thực chất là gán các giá trị bằng NULL
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThamDinhThongTinPhapLyKhacByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@TrangThaiHoSoCapGCN INT,
	@MaHoSoCapGCN NVARCHAR(100) = NULL,
	@NgayNopDuHoSoHopLe NVARCHAR(50) = NULL,
	@TrinhTuThuTucPhuong NVARCHAR(200) = NULL,
	@CacKhoanPhaiNop NVARCHAR(1000) = NULL,
	@GhiChuThamDinh NVARCHAR(500) = NULL,
	@LyDo nvarchar(500)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
		TrangThaiHoSoCapGCN = CONVERT(INT,@TrangThaiHoSoCapGCN)
		,NgayNopDuHoSoHopLe = NULL 
		,TrinhTuThuTucPhuong = NULL
		,CacKhoanPhaiNop = NULL,GhiChuThamDinh = NULL
		,LyDoThamDinh = NULL
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongBaoCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091217
-- Description:	Xóa Thông báo cấp GCN trong bảng
-- tblHoSoCapGCN. Thực chất là thiết đặt các giá trị về NULL
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongBaoCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT
	,@NgayThongBaoUBND	NVARCHAR (50) = NULL
	,@NgayCongDanNhanThongBao	NVARCHAR (50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
	NgayThongBaoUBND = NULL
	,NgayCongDanNhanThongBao = NULL
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongInTraGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091217
-- Description:	Xóa Thông tin Trả GCN trong bảng
-- tblHoSoCapGCN. Thực chất là thiết đặt các giá trị về NULL
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongInTraGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT
	,@NgayTraGCN	NVARCHAR (50) = NULL
	,@NgayHoanTatGCN	NVARCHAR (50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
	NgayTraGCN = NULL
	,NgayHoanTatGCN = NULL
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinCayLauNamDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100104
-- Description:	Truy vấn Thông tin CÂY LÂU NĂM
-- đề nghị cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinCayLauNamDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT,
	@ThongTinCayLauNamDeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaHoSoCapGCN,ThongTinCayLauNamDeNghiCapGCN
	FROM tblHoSoCapGCN
	WHERE 1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091218
-- Description:	Truy vấn thông tin  GCN trong bảng
-- tblHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT
	,@TrangThaiHoSoCapGCN INT
	,@CoQuanCapGCN	NVARCHAR(200) = NULL
	,@MaSoGCN	NVARCHAR(50) = NULL	
	,@GhiChuGCN	NVARCHAR(1000) = NULL	
	,@NghiaVuTaiChinh	NVARCHAR(500) = NULL	
	,@SoHoSoGoc NVARCHAR (50) = NULL
	,@SoPhatHanhGCN NVARCHAR (50) = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		MaHoSoCapGCN,TrangThaiHoSoCapGCN,CoQuanCapGCN,MaSoGCN
		,GhiChuGCN,NghiaVuTaiChinh,SoHoSoGoc
		,SoPhatHanhGCN,NgayKyGCN,MaXa
	FROM tblHoSoCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinKyGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100223
-- Description:	Truy vấn thông tin ký GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinKyGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT = NULL
	,@DiaDanhNoiCap	NVARCHAR(200) = NULL
	,@NgayKyGCN	NVARCHAR(50) = NULL
	,@TieuDeKyGCN	NVARCHAR(200) = NULL
	,@NguoiKyGCN	NVARCHAR(200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		MaHoSoCapGCN
		,DiaDanhNoiCap
		,NgayKyGCN
		,TieuDeKyGCN
		,NguoiKyGCN
	FROM tblHoSoCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinCayLauNamDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100104
-- Description:	Xóa thông tin Cây lâu năm đề nghị
-- cấp GCN theo Mã hồ sơ cấp GCN.
-- Thực chất là gán các giá trị bằng NULL
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinCayLauNamDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT,
	@ThongTinCayLauNamDeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
		ThongTinCayLauNamDeNghiCapGCN = NULL
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinLichSuChuSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090827
-- Description:	Lựa chọn Chủ sử dụng thửa đất lịch sử
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinLichSuChuSuDung]
	-- Add the parameters for the stored procedure here
	@MaThuaDatLichSu BIGINT = NULL,
	@MaHoSoCapGCNHienThoi BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		Begin
							
			SELECT DISTINCT  c.MaChu, c.GioiTinh,c.HoTen,c.NamSinh,c.SoDinhDanh
				,c.NgayCap,c.NoiCap,c.DiaChi
			FROM tblDLieuKGianThuaDatLichSu td
			INNER JOIN tblTrungGianThuaDatHoSo AS tg ON tg.MaThuaDat = td.SW_MEMBER
			INNER JOIN tblHoSoCapGCN AS hs ON hs.MaHoSoCapGCN = tg.MaHoSoCapGCN
			INNER JOIN tblChuSuDung AS csd ON csd.MaHoSoCapGCN = hs.MaHoSoCapGCN
			INNER JOIN tblChu AS c ON c.MaChu = csd.MaChu
			WHERE (td.SW_MEMBER = CONVERT(BIGINT,@MaThuaDatLichSu))
			PRINT ''Selected''
		END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091218
-- Description:	Xóa thông tin GCN trong bảng
-- tblHoSoCapGCN
-- Thực chất chỉ là cập nhật thông tin với giá trị các
-- trường cần cập nhật bằng NULL
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT
	,@TrangThaiHoSoCapGCN  INT
	,@CoQuanCapGCN	NVARCHAR(200) = NULL
	,@MaSoGCN	NVARCHAR(50) = NULL	
	,@GhiChuGCN	NVARCHAR(1000) = NULL	
	,@NghiaVuTaiChinh	NVARCHAR(500) = NULL	
	,@SoHoSoGoc NVARCHAR (50) = NULL
	,@SoPhatHanhGCN NVARCHAR (50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET 
		TrangThaiHoSoCapGCN = CONVERT(INT,@TrangThaiHoSoCapGCN)
		,CoQuanCapGCN = NULL
		,MaSoGCN = NULL
		,GhiChuGCN = NULL
		,NghiaVuTaiChinh = NULL
		,SoHoSoGoc = NULL
		,SoPhatHanhGCN = NULL
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinHangMucCongTrinhDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 201001069
-- Description:	Truy vấn Thông tin Công trình xây dựng
-- đề nghị cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinHangMucCongTrinhDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT,
	@ThongTinHangMucCongTrinhDeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaHoSoCapGCN,ThongTinHangMucCongTrinhDeNghiCapGCN
	FROM tblHoSoCapGCN
	WHERE 1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinLichSuKiemKe]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090827
-- Description:	Lựa chọn THÔNG TIN KIỂM KÊ thửa đất lịch sử
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinLichSuKiemKe]
	-- Add the parameters for the stored procedure here
	@MaThuaDatLichSu BIGINT = NULL,
	@MaHoSoCapGCNHienThoi BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		BEGIN
			SELECT kk.KyHieu, DienTich,tdmd.MoTa, GhiChu
			FROM tblDLieuKGianThuaDatLichSu td
			INNER JOIN tblTrungGianThuaDatHoSo AS tg ON tg.MaThuaDat = td.SW_MEMBER
			INNER JOIN tblHoSoCapGCN AS hs ON hs.MaHoSoCapGCN = tg.MaHoSoCapGCN
			INNER JOIN tblThongTinKiemKe AS kk ON kk.MaHoSoCapGCN = hs.MaHoSoCapGCN
			INNER JOIN tblTuDienMucDichSDD AS tdmd ON (tdmd.KyHieu = kk.KyHieu)
			WHERE (td.SW_MEMBER = @MaThuaDatLichSu)
			PRINT ''Selected''
		END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinHangMucCongTrinhDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100106
-- Description:	Xóa thông tin Công trình xây dựng đề nghị
-- cấp GCN theo Mã hồ sơ cấp GCN.
-- Thực chất là gán các giá trị bằng NULL
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinHangMucCongTrinhDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT,
	@ThongTinHangMucCongTrinhDeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
		ThongTinHangMucCongTrinhDeNghiCapGCN = NULL
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinLichSuMucDichSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090827
-- Description:	Lựa chọn MỤC ĐÍCH SỬ DỤNG thửa đất lịch sử
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinLichSuMucDichSuDung]
	-- Add the parameters for the stored procedure here
	@MaThuaDatLichSu BIGINT = NULL,
	@MaHoSoCapGCNHienThoi BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		Begin
							
			SELECT DISTINCT  md.KyHieu,DienTichKeKhai ,DienTichThucCap,DienTichRieng
				,DienTichChung,DienTichKhongCap,LyDoKhongCap,LoaiThoiHan
				,ThoiDiemBatDau,ThoiDiemKetThuc,GhiChu, tdmd.MoTa
			FROM tblDLieuKGianThuaDatLichSu td
			INNER JOIN tblTrungGianThuaDatHoSo AS tg ON tg.MaThuaDat = td.SW_MEMBER
			INNER JOIN tblHoSoCapGCN AS hs ON hs.MaHoSoCapGCN = tg.MaHoSoCapGCN
			INNER JOIN tblMucDichSuDungDat AS md ON md.MaHoSoCapGCN = hs.MaHoSoCapGCN
			INNER JOIN tblTuDienMucDichSDD AS tdmd ON (tdmd.KyHieu = md.KyHieu)
			WHERE (td.SW_MEMBER = @MaThuaDatLichSu)
			PRINT ''Selected''
		END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinLichSuNguonGocSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090827
-- Description:	Lựa chọn NGUỒN GỐC SỬ DỤNG thửa đất lịch sử
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinLichSuNguonGocSuDung]
	-- Add the parameters for the stored procedure here
	@MaThuaDatLichSu BIGINT = NULL,
	@MaHoSoCapGCNHienThoi BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		BEGIN
			SELECT ng.KyHieu,DienTich,DaCoTaiLieuChungThuc
					,TenTaiLieuChungThuc,NoiDungChungThuc, GhiChu, tdng.MoTa
			FROM tblDLieuKGianThuaDatLichSu td
			INNER JOIN tblTrungGianThuaDatHoSo AS tg ON tg.MaThuaDat = td.SW_MEMBER
			INNER JOIN tblHoSoCapGCN AS hs ON hs.MaHoSoCapGCN = tg.MaHoSoCapGCN
			INNER JOIN tblNguonGocSuDungDat AS ng ON ng.MaHoSoCapGCN = hs.MaHoSoCapGCN
			INNER JOIN tblTuDienNguonGocSDD AS tdng ON (tdng.KyHieu = ng.KyHieu)
			WHERE (td.SW_MEMBER = @MaThuaDatLichSu)
			PRINT ''Selected''
		END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinLichSuQuiHoach]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090827
-- Description:	Lựa chọn THÔNG TIN QUI HOẠCH thửa đất lịch sử
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinLichSuQuiHoach]
	-- Add the parameters for the stored procedure here
	@MaThuaDatLichSu BIGINT = NULL,
	@MaHoSoCapGCNHienThoi BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		BEGIN
			SELECT qh.KyHieu, DienTich,tdmd.MoTa, GhiChu
			FROM tblDLieuKGianThuaDatLichSu td
			INNER JOIN tblTrungGianThuaDatHoSo AS tg ON tg.MaThuaDat = td.SW_MEMBER
			INNER JOIN tblHoSoCapGCN AS hs ON hs.MaHoSoCapGCN = tg.MaHoSoCapGCN
			INNER JOIN tblThongTinQuiHoach AS qh ON qh.MaHoSoCapGCN = hs.MaHoSoCapGCN
			INNER JOIN tblTuDienMucDichSDD AS tdmd ON (tdmd.KyHieu = qh.KyHieu)
			WHERE (td.SW_MEMBER = @MaThuaDatLichSu)
			PRINT ''Selected''
		END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinKyGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100223
-- Description:	Xóa thông tin ký GCN
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinKyGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT
	,@DiaDanhNoiCap	NVARCHAR(200) = NULL
	,@NgayKyGCN	NVARCHAR(50) = NULL
	,@TieuDeKyGCN	NVARCHAR(200) = NULL
	,@NguoiKyGCN	NVARCHAR(200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET 
		DiaDanhNoiCap = NULL
		,NgayKyGCN = NULL
		,TieuDeKyGCN = NULL
		,NguoiKyGCN	= NULL
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinLichSuTaiLieuKemTheo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090827
-- Description:	Lựa chọn THÔNG TIN TÀI LIỆU KÈM THEO thửa đất lịch sử
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinLichSuTaiLieuKemTheo]
	-- Add the parameters for the stored procedure here
	@MaThuaDatLichSu BIGINT = NULL,
	@MaHoSoCapGCNHienThoi BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		BEGIN
			SELECT MoTa, TenTepDuLieuNguon,TaiLieu
			FROM tblDLieuKGianThuaDatLichSu td
			INNER JOIN tblTrungGianThuaDatHoSo AS tg ON tg.MaThuaDat = td.SW_MEMBER
			INNER JOIN tblHoSoCapGCN AS hs ON hs.MaHoSoCapGCN = tg.MaHoSoCapGCN
			INNER JOIN tblTaiLieuKemTheo AS tl ON tl.MaHoSoCapGCN = hs.MaHoSoCapGCN
			WHERE (td.SW_MEMBER = @MaThuaDatLichSu)
			PRINT ''Selected''
		END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinNhaODeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091229
-- Description:	Xóa thông tin Nhà ở đề nghị
-- cấp GCN theo Mã hồ sơ cấp GCN.
-- Thực chất là gán các giá trị bằng NULL
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinNhaODeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT,
	@ThongTinNhaODeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
		ThongTinNhaODeNghiCapGCN = NULL
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinMaVach]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vu Le Thanh
-- Create date: 20091126
-- Description:	Select AnhMaVach theo MaHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinMaVach]
	@MaHoSoCapGCN BIGINT=null
AS
BEGIN
	SELECT TOP 1 AnhMaVach,InMaVach
	FROM tblHoSoCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinNhaODeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091229
-- Description:	Truy vấn Thông tin Nhà ở
-- đề nghị cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinNhaODeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT,
	@ThongTinNhaODeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaHoSoCapGCN,ThongTinNhaODeNghiCapGCN
	FROM tblHoSoCapGCN
	WHERE 1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateStatusMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan CHung
-- Create date: 21/07/2010
-- Description:	Update trang thai ho so khi dang ky bien dong
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateStatusMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN nvarchar(20)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update tblHoSoCapGCN set status =0 where MaHoSoCapGCN = @MaHoSoCapGCN
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinRungCayDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100104
-- Description:	Xóa thông tin RỪNG CÂY đề nghị
-- cấp GCN theo Mã hồ sơ cấp GCN.
-- Thực chất là gán các giá trị bằng NULL
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinRungCayDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT,
	@ThongTinRungCayDeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
		ThongTinRungCayDeNghiCapGCN = NULL
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091222
-- Description:	Xóa Thẩm định thông tin Thửa đất.
-- Thực chất là gán các giá trị bằng NULL
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN NVARCHAR(100) = NULL,
	@ThongTinThuaDatDeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
		ThongTinThuaDatDeNghiCapGCN = NULL
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinRungCayDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100104
-- Description:	Truy vấn Thông tin RỪNG CÂY
-- đề nghị cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinRungCayDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT,
	@ThongTinRungCayDeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaHoSoCapGCN,ThongTinRungCayDeNghiCapGCN
	FROM tblHoSoCapGCN
	WHERE 1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinSoCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091217
-- Description:	Xóa thông tin Sổ cấp GCN trong bảng
-- tblHoSoCapGCN
-- Thực chất chỉ là cập nhật thông tin với giá trị các
-- trường cần cập nhật bằng NULL
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinSoCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT = NULL
    ,@KyHieuThamQuyenCapGCN NVARCHAR(50) = NULL
    ,@ThuTuVaoSoCapGCN INT = NULL
    ,@SoVaoSoCapGCN NVARCHAR(50) = NULL
    ,@NgayVaoSoCapGCN NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
    KyHieuThamQuyenCapGCN = NULL
    ,ThuTuVaoSoCapGCN = NULL
    ,SoVaoSoCapGCN = NULL
    ,NgayVaoSoCapGCN = NULL	
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinSoCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091217
-- Description:	Truy vấn thông tin  thông tin Sổ cấp GCN trong bảng
-- tblHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinSoCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT = NULL
    ,@KyHieuThamQuyenCapGCN NVARCHAR(50) = NULL
    ,@ThuTuVaoSoCapGCN INT = NULL
    ,@SoVaoSoCapGCN NVARCHAR(50) = NULL
    ,@NgayVaoSoCapGCN NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	MaHoSoCapGCN,KyHieuThamQuyenCapGCN
	,ThuTuVaoSoCapGCN,SoVaoSoCapGCN
	,NgayVaoSoCapGCN
	FROM tblHoSoCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091222
-- Date modified: 20100210
-- Description:	Truy vấn Thẩm định thông tin Thửa đất
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN NVARCHAR(100) = NULL,
	@ThongTinThuaDatDeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaHoSoCapGCN,ThongTinThuaDatDeNghiCapGCN
	FROM tblHoSoCapGCN
	WHERE  1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienLoaiHinhBienDong]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 20100313
--Người tạo: Vũ Lê Thành,
--Mục đích: Xóa loại hình biến động
CREATE PROC [dbo].[spDeleteTuDienLoaiHinhBienDong]
	@KyHieu NVARCHAR (500) = NULL,
	@MoTa NVARCHAR (500) = NULL,
	@Nhom NVARCHAR (100) = NULL

AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	DELETE FROM tblTuDienLoaiHinhBienDong
	WHERE KyHieu = @KyHieu
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinTraGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091217
-- Description:	Truy vấn thông tin Trả GCN trong bảng
-- tblHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinTraGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT
	,@NgayTraGCN	NVARCHAR (50) = NULL
	,@NgayHoanTatGCN	NVARCHAR (50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaHoSoCapGCN,NgayTraGCN,NgayHoanTatGCN
	FROM tblHoSoCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThuTuHoSoBienDongLonNhat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spSelectThuTuHoSoBienDongLonNhat]
AS
SELECT Max(ThuTuHoSoBienDong) as ThuTuHoSoBienDong
FROM tblDangKyBienDong' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinTranhChapKhieuKienByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[spSelectThongTinTranhChapKhieuKienByMaHoSoCapGCN](@MaHoSoCapGCN bigint)
as
SELECT     NoiDungTranhChapKhieuKien
FROM         dbo.tblHoSoCapGCN
WHERE     (MaHoSoCapGCN = @MaHoSoCapGCN)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinNguoiKyGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[spSelectThongTinNguoiKyGCN](@MaHoSoCapGCN bigint)
as
SELECT     NguoiKyGCN
FROM         dbo.tblHoSoCapGCN
WHERE     (MaHoSoCapGCN = @MaHoSoCapGCN)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinNguoiKyGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[spSelectThongTinNguoiKyGCNByMaHoSoCapGCN](@MaHoSoCapGCN bigint)
as
SELECT     NguoiKyGCN
FROM         dbo.tblHoSoCapGCN
WHERE     (MaHoSoCapGCN = @MaHoSoCapGCN)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinNghiaVuTaiChinh_TranhChap_NguoiKyGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[spSelectThongTinNghiaVuTaiChinh_TranhChap_NguoiKyGCNByMaHoSoCapGCN](@MaHoSoCapGCN bigint)
as 
SELECT     NghiaVuTaiChinh, NoiDungTranhChapKhieuKien, NguoiKyGCN
FROM         dbo.tblHoSoCapGCN
WHERE     (MaHoSoCapGCN = @MaHoSoCapGCN)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spThemChuSDDVaoChuTaiSan]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Cập nhật bảng tbChuTaiSan

CREATE PROCEDURE [dbo].[spThemChuSDDVaoChuTaiSan]
	@MaHoSoCapGCN BIGINT,
	@MaTaiSan BIGINT,
	@NhomDoiTuongSuDungDat NVARCHAR(50)

AS
SET NOCOUNT ON
	BEGIN
		--Thiết lập định dạng: ngày, tháng,năm (kiểu Pháp)
		set DATEFORMAT DMY
		INSERT INTO  tblChuTaiSan(MaTaiSan,ThoiDiemKeKhaiDangKy,DoiTuongSDD
			,QuanHe,GioiTinh,HoTen,NamSinh,SoDinhDanh,NgayCap,NoiCap,DiaChi	
			,QuocTich,SoHoKhau,NgayCapHoKhau,NoiCapHoKhau)
		SELECT @MaTaiSan, getdate(),DoiTuongSDD
			,QuanHe,GioiTinh,HoTen,NamSinh,SoDinhDanh,NgayCap,NoiCap,DiaChi	
			,QuocTich,SoHoKhau,NgayCapHoKhau,NoiCapHoKhau
		FROM tblChuSuDungDat
			--Lien ket voi bang tblTuDienDoiTuongSuDungDat
			left  join tblTuDienDoiTuongSuDungDat as b on (DoiTuongSDD = b.KyHieu)
		WHERE ( tblChuSuDungDat.MaHoSoCapGCN = convert(BIGINT,@MaHoSoCapGCN) ) and (b.Nhom = convert(int,@NhomDoiTuongSuDungDat))
	END
SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[respatialize]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[respatialize]
	@tab	varchar(200)
as
BEGIN
	exec sp_sw_drop_rtree ''dbo'', @tab, ''sw_geometry'', ''sw_member''
	exec sp_sw_despatialize_column ''dbo'', @tab,
	        ''sw_geometry'', ''sw_member''

	exec sp_sw_create_rtree ''dbo'', @tab, ''sw_geometry'', ''sw_member''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateGhiChuNoiDungChuDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091222
-- Description:	Cập nhật thông tin Chủ đề nghị
-- cấp GCN theo Mã hồ sơ cấp GCN.
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateGhiChuNoiDungChuDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT,
	@GhiChuNoiDungChuDeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
		GhiChuNoiDungChuDeNghiCapGCN = @GhiChuNoiDungChuDeNghiCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateHoSoCapGCNByHoSoKiThuatGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090930
-- Description:	Cập nhật hình ảnh bản đồ trong phần
-- soạn hồ sơ kĩ thuật. Để in ra sổ đỏ
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateHoSoCapGCNByHoSoKiThuatGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT = null,
	@HoSoKiThuat image = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	Update tblHoSoCapGCN 
	Set HoSoKiThuatGCN = @HoSoKiThuat
	Where MaHoSoCapGCN = @MaHoSoCapGCN
	
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateHoSoCapGCNByHoSoKiThuatThamDinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090930
-- Description:	Cập nhật hình ảnh bản đồ trong phần
-- soạn hồ sơ kĩ thuật. Để in ra Phiếu thẩm định, Hồ sơ kĩ thuật, Đơn kê khai
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateHoSoCapGCNByHoSoKiThuatThamDinh]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT = null,
	@HoSoKiThuat image = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	Update tblHoSoCapGCN 
	Set HoSoKiThuatThamDinh = @HoSoKiThuat
	Where MaHoSoCapGCN = @MaHoSoCapGCN
	
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateHoSoCapGCNByMaVach]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090930
-- Description:	Cập nhật hình MÃ VẠCH HỒ SƠ CẤP GCN
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateHoSoCapGCNByMaVach]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT = NULL,
	@InMaVach BIT = NULL,
	@AnhMaVach varbinary(8000) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	Update tblHoSoCapGCN 
	Set AnhMaVach = @AnhMaVach
		,InMaVach = @InMaVach
	Where MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinBanDuThaoGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan CHung
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinBanDuThaoGCN]
	@MaHoSoCapGCN nvarchar(20)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ThongTinThuaDatDeNghiCapGCN,ThongTinNhaODeNghiCapGCN,GhiChuGCN
	FROM tblHoSoCapGCN
	WHERE  1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateHoSoCapGCNBySoDoNhaDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100318
-- Description:	Cập nhật hình ảnh bản đồ . Để in ra
-- mặt 3 của GCN (Sổ đỏ)
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateHoSoCapGCNBySoDoNhaDat]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT = null,
	@SoDoNhaDat IMAGE = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	Update tblHoSoCapGCN 
	Set SoDoNhaDat = @SoDoNhaDat
	Where MaHoSoCapGCN = @MaHoSoCapGCN

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTrangThaiHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--Ngày tạo gần nhất: 20100510
--Người tạo: Quách Văn Phong ,
--Mục đích: Cập nhật thông tin trạng thái hồ sơ cấp giấy chứng nhận


CREATE PROCEDURE [dbo].[spUpdateTrangThaiHoSoCapGCN]
@Flag int=NULL,
@MaHoSoCapGCN bigint=NULL
AS
  BEGIN
    IF (@Flag=0)
      BEGIN
        UPDATE tblHoSoCapGCN SET TrangThaiHoSoCapGCN=0
        WHERE MaHoSoCapGCN=@MaHoSoCapGCN
      END
    IF (@Flag=1)
      BEGIN
        UPDATE tblHoSoCapGCN SET TrangThaiHoSoCapGCN=1
        WHERE MaHoSoCapGCN=@MaHoSoCapGCN
      END
    IF (@Flag=2)
      BEGIN
        UPDATE tblHoSoCapGCN SET TrangThaiHoSoCapGCN=2
        WHERE MaHoSoCapGCN=@MaHoSoCapGCN
      END
    IF(@Flag=3)
      BEGIN
        UPDATE tblHoSoCapGCN SET TrangThaiHoSoCapGCN=3
        WHERE MaHoSoCapGCN=@MaHoSoCapGCN
      END
    IF (@Flag=4)
      BEGIN
        UPDATE tblHoSoCapGCN SET TrangThaiHoSoCapGCN=4
        WHERE MaHoSoCapGCN=@MaHoSoCapGCN
      END
    IF (@Flag=5)
      BEGIN
        UPDATE tblHoSoCapGCN SET TrangThaiHoSoCapGCN=5
        WHERE MaHoSoCapGCN=@MaHoSoCapGCN
      END
    IF (@Flag=6)
      BEGIN
        UPDATE tblHoSoCapGCN SET TrangThaiHoSoCapGCN=6
        WHERE MaHoSoCapGCN=@MaHoSoCapGCN
      END
    IF(@Flag=7)
      BEGIN
        UPDATE tblHoSoCapGCN SET TrangThaiHoSoCapGCN=7
        WHERE MaHoSoCapGCN=@MaHoSoCapGCN
      END
    IF(@Flag=8)
      BEGIN
        UPDATE tblHoSoCapGCN SET TrangThaiHoSoCapGCN=8
        WHERE MaHoSoCapGCN=@MaHoSoCapGCN
      END
    
   IF(@Flag=9)
      BEGIN
        UPDATE tblHoSoCapGCN SET TrangThaiHoSoCapGCN=9
        WHERE MaHoSoCapGCN=@MaHoSoCapGCN
      END
  END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectGroupNghiaVuTaiChinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: <11/11/2009>
-- Description:	<select nhomn nghia vu tai chinh>(phan in phieu quyet dinh)
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectGroupNghiaVuTaiChinh]
	@MaHoSoCapGCN nvarchar(max)=null
AS
BEGIN
declare @str nvarchar(max)
	set @str = ''select NghiaVuTaiChinh , Count(NghiaVuTaiChinh)as SoLuong from  tblHoSoCapGCN where MaHoSoCapGCN in ('' + @MaHoSoCapGCN + '') group by NghiaVuTaiChinh''
exec (@str)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTrangThaiTiepNhanHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 20100510
--Người tạo: Quách Văn Phong ,
--Mục đích: Hiển thị thông tin trạng thái tiếp nhận hồ sơ cấp giấy chứng nhận


CREATE PROCEDURE [dbo].[spSelectTrangThaiTiepNhanHoSoCapGCN]
@MaHoSoCapGCN bigint=NULL
AS
  BEGIN
    SELECT TrangThaiHoSoCapGCN 
    FROM tblHoSoCapGCN
    WHERE MaHoSoCapGCN=@MaHoSoCapGCN AND TrangThaiHoSoCapGCN=''1''
  END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectHoSoKyThuat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham xuan chung	
-- Create date: <3/12/2009>
-- Description:	<lay du lieu ban do de hien thi len ho so ky thuat>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectHoSoKyThuat]
	@MaHoSoCapGCN nvarchar(50)=null
AS
BEGIN
	SELECT HoSoKiThuatGCN AS Image 
	FROM tblHoSoCapGCN  
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectHoSoKyThuatBienBanXetDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham xuan chung	
-- Create date: <17/11/2009>
-- Description:	<lay du lieu ban do de hien thi len bien ban xet duyet>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectHoSoKyThuatBienBanXetDuyet]
	@MaHoSoCapGCN nvarchar(50)=null
AS
BEGIN
	Select HoSoKiThuatThamDinh as Image from tblHoSoCapGCN  WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThamDinhThongTinPhapLyKhacByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091222
-- Description:	Cập nhật thông tin Thẩm định.
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThamDinhThongTinPhapLyKhacByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@TrangThaiHoSoCapGCN INT,
	@MaHoSoCapGCN NVARCHAR(100) = NULL,
	@NgayNopDuHoSoHopLe NVARCHAR(50) = NULL,
	@TrinhTuThuTucPhuong NVARCHAR(200) = NULL,
	@CacKhoanPhaiNop NVARCHAR(1000) = NULL,
	@GhiChuThamDinh NVARCHAR(500) = NULL,
	@LyDo nvarchar(500)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET DATEFORMAT DMY
	UPDATE tblHoSoCapGCN
	SET
		TrangThaiHoSoCapGCN = CONVERT(INT,@TrangThaiHoSoCapGCN)
 		,NgayNopDuHoSoHopLe = CONVERT(DATETIME,@NgayNopDuHoSoHopLe)
		,TrinhTuThuTucPhuong = @TrinhTuThuTucPhuong
		,CacKhoanPhaiNop = @CacKhoanPhaiNop
		,GhiChuThamDinh = @GhiChuThamDinh
		,LyDoThamDinh =@LyDo
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongBaoCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091217
-- Description:	Cập nhật Thông báo cấp GCN trong bảng
-- tblHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongBaoCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT
	,@NgayThongBaoUBND	NVARCHAR (50) = NULL
	,@NgayCongDanNhanThongBao	NVARCHAR (50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
	NgayThongBaoUBND = CONVERT(DATETIME,@NgayThongBaoUBND)
	,NgayCongDanNhanThongBao = CONVERT(DATETIME,@NgayCongDanNhanThongBao)
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSaoChepThongTinLichSuChuSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090827
-- Description:	Sao chép thông tin lịch sử
-- chủ sử dụng đất của thửa đất với Mã thửa đất
-- lịch sử và Mã hồ sơ cấp GCN hiện thời cho trước
-- =============================================
CREATE PROCEDURE [dbo].[spSaoChepThongTinLichSuChuSuDung]
	-- Add the parameters for the stored procedure here
	@MaThuaDatLichSu BIGINT = NULL,
	@MaHoSoCapGCNHienThoi BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		BEGIN TRANSACTION
			INSERT INTO tblChuSuDung(MaChu,MaHoSoCapGCN)
			(SELECT DISTINCT c.MaChu, @MaHoSoCapGCNHienThoi
			FROM tblDLieuKGianThuaDatLichSu td
			INNER JOIN tblTrungGianThuaDatHoSo AS tg ON tg.MaThuaDat = td.SW_MEMBER
			INNER JOIN tblHoSoCapGCN AS hs ON hs.MaHoSoCapGCN = tg.MaHoSoCapGCN
			INNER JOIN tblChuSuDung AS csd ON csd.MaHoSoCapGCN = hs.MaHoSoCapGCN
			INNER JOIN tblChu AS c ON c.MaChu = csd.MaChu
			WHERE (td.SW_MEMBER = @MaThuaDatLichSu))
--				AND NOT (EXISTS (SELECT c.MaChu, @MaHoSoCapGCNHienThoi 
--								FROM tblDLieuKGianThuaDatLichSu td1
--								INNER JOIN tblTrungGianThuaDatHoSo AS tg1 ON tg1.MaThuaDat = td1.SW_MEMBER
--								INNER JOIN tblHoSoCapGCN AS hs1 ON hs1.MaHoSoCapGCN = tg1.MaHoSoCapGCN
--								INNER JOIN tblChuSuDung AS csd1 ON csd1.MaHoSoCapGCN = hs1.MaHoSoCapGCN
--								INNER JOIN tblChu AS c1 ON c1.MaChu = csd1.MaChu
--								WHERE (c1.MaChu = c.MaChu) ))) )
			IF (@@ERROR <> 0 )
			BEGIN
				PRINT ''Error!''		
				ROLLBACK TRANSACTION
			END
			PRINT ''Successfully Insertion !''
		COMMIT TRANSACTION
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spNguoiXetDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Cập nhật bảng tblNguoiXetDuyet
-- Sẽ bỏ Store này
CREATE PROC [dbo].[spNguoiXetDuyet]
	@flag TINYINT,
	@MaNguoiXetDuyet NVARCHAR(100) = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@GioiTinh	 NVARCHAR(10) = NULL,
	@HoTen	NVARCHAR(200) = NULL,
	@ChucDanh NVARCHAR(200) = NULL,
	@ChucVu NVARCHAR(200) = NULL
AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	-- Liet ke danh sach 
	IF @flag = 0 
		BEGIN
			SELECT   	MaNguoiXetDuyet ,MaHoSoCapGCN ,GioiTinh  ,HoTen	,ChucDanh,ChucVu
			FROM tblNguoiXetDuyet
			WHERE 1 = 1
			AND (CASE @MaHoSoCapGCN 
				WHEN '''' then @MaHoSoCapGCN   ELSE MaHoSoCapGCN  END) = @MaHoSoCapGCN 
			AND (CASE @GioiTinh
				WHEN '''' THEN @GioiTinh ELSE GioiTinh  END) = @GioiTinh
			AND (CASE @ChucDanh
				WHEN '''' THEN @ChucDanh  ELSE  ChucDanh  END) = @ChucDanh
			AND (CASE @HoTen
				WHEN '''' THEN @HoTen ELSE HoTen END) = @HoTen
		END
	ELSE 
		BEGIN
			--Truong hop them 
			IF @flag = 1
				BEGIN				
					SET DATEFORMAT DMY
					SET @MaNguoiXetDuyet  = newid()
					IF NOT EXISTS (select MaNguoiXetDuyet ,MaHoSoCapGCN,GioiTinh  ,ChucDanh,ChucVu ,HoTen	
						FROM tblNguoiXetDuyet where (MaNguoiXetDuyet = @MaNguoiXetDuyet) )
						BEGIN
							INSERT INTO tblNguoiXetDuyet( MaNguoiXetDuyet ,MaHoSoCapGCN ,GioiTinh ,ChucDanh,ChucVu ,HoTen) 
							VALUES (convert( uniqueidentifier,@MaNguoiXetDuyet) ,convert(BIGINT,@MaHoSoCapGCN) ,convert(bit,@GioiTinh) ,@ChucDanh,@ChucVu ,@HoTen)
							PRINT ''Da them''
						END
					ELSE 
						SET @IsExit = 0
				END
			--Truong hop cap nhat 
			IF @flag  = 2
				BEGIN
					SET DATEFORMAT DMY --,
					UPDATE tblNguoiXetDuyet
					SET MaHoSoCapGCN =  convert(BIGINT,@MaHoSoCapGCN) , MaNguoiXetDuyet = convert(uniqueidentifier,@MaNguoiXetDuyet)
						,GioiTinh = convert(bit,@GioiTinh), ChucDanh= @ChucDanh, ChucVu= @ChucVu, HoTen = @HoTen
					WHERE (MaNguoiXetDuyet = @MaNguoiXetDuyet)
					PRINT ''Da sua''
				END
			--Truong hop xoa mot ban ghi tuong ung voi MaNguoiXetDuyet trong bang tblNguoiXetDuyet
			IF @flag = 3
				BEGIN
					DELETE FROM tblNguoiXetDuyet
					WHERE (MaNguoiXetDuyet = @MaNguoiXetDuyet) 
					PRINT ''Da xoa''
				END
			--Truong hop xoa nhieu ban ghi tuong ung voi MaHoSoCapGCN trong bang tblNguoiXetDuyet
			IF @flag = 4
				BEGIN
					DELETE FROM tblNguoiXetDuyet
					WHERE (MaHoSoCapGCN = @MaHoSoCapGCN) 
				END
	--			set nocount off 
			SELECT @IsExit
		END
	
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSaoChepThongTinLichSuKiemKe]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090827
-- Description:	Sao chép thông tin lịch sử
-- KIỂM KÊ sử dụng đất của thửa đất với Mã thửa đất
-- lịch sử và Mã hồ sơ cấp GCN hiện thời cho trước
-- =============================================
CREATE PROCEDURE [dbo].[spSaoChepThongTinLichSuKiemKe]
	-- Add the parameters for the stored procedure here
	@MaThuaDatLichSu BIGINT = NULL,
	@MaHoSoCapGCNHienThoi BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		BEGIN TRANSACTION
			INSERT INTO tblThongTinKiemKe(MaHoSoCapGCN,KyHieu,DienTich
				,MoTa,GhiChu)
			(SELECT @MaHoSoCapGCNHienThoi,kk.KyHieu,DienTich,kk.MoTa, GhiChu
			FROM tblDLieuKGianThuaDatLichSu td
			INNER JOIN tblTrungGianThuaDatHoSo AS tg ON tg.MaThuaDat = td.SW_MEMBER
			INNER JOIN tblHoSoCapGCN AS hs ON hs.MaHoSoCapGCN = tg.MaHoSoCapGCN
			INNER JOIN tblThongTinKiemKe AS kk ON kk.MaHoSoCapGCN = hs.MaHoSoCapGCN
			INNER JOIN tblTuDienMucDichSDD AS tdmd ON (tdmd.KyHieu = kk.KyHieu)
			WHERE (td.SW_MEMBER = @MaThuaDatLichSu))
			IF (@@ERROR <> 0 )
			BEGIN
				PRINT ''Error!''		
				ROLLBACK TRANSACTION
			END
		COMMIT TRANSACTION
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSaoChepThongTinLichSuMucDichSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090827
-- Description:	Sao chép thông tin lịch sử
-- MỤC ĐÍCH sử dụng đất của thửa đất với Mã thửa đất
-- lịch sử và Mã hồ sơ cấp GCN hiện thời cho trước
-- =============================================
CREATE PROCEDURE [dbo].[spSaoChepThongTinLichSuMucDichSuDung]
	-- Add the parameters for the stored procedure here
	@MaThuaDatLichSu BIGINT = NULL,
	@MaHoSoCapGCNHienThoi BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		BEGIN TRANSACTION
			INSERT INTO tblMucDichSuDungDat(MaHoSoCapGCN 
				,ThoiDiemKeKhaiDangKy,KyHieu,DienTichKeKhai,DienTichThucCap
				,DienTichRieng,DienTichChung,DienTichKhongCap,LyDoKhongCap
				,LoaiThoiHan,ThoiDiemBatDau,ThoiDiemKetThuc,GhiChu)
			(SELECT DISTINCT  @MaHoSoCapGCNHienThoi 
				,ThoiDiemKeKhaiDangKy,md.KyHieu,DienTichKeKhai,DienTichThucCap
				,DienTichRieng,DienTichChung,DienTichKhongCap,LyDoKhongCap
				,LoaiThoiHan,ThoiDiemBatDau,ThoiDiemKetThuc,GhiChu
			FROM tblDLieuKGianThuaDatLichSu td
			INNER JOIN tblTrungGianThuaDatHoSo AS tg ON tg.MaThuaDat = td.SW_MEMBER
			INNER JOIN tblHoSoCapGCN AS hs ON hs.MaHoSoCapGCN = tg.MaHoSoCapGCN
			INNER JOIN tblMucDichSuDungDat AS md ON md.MaHoSoCapGCN = hs.MaHoSoCapGCN
			INNER JOIN tblTuDienMucDichSDD AS tdmd ON (tdmd.KyHieu = md.KyHieu)
			WHERE (td.SW_MEMBER = @MaThuaDatLichSu))
			IF (@@ERROR <> 0 )
			BEGIN
				PRINT ''Error!''		
				ROLLBACK TRANSACTION
			END
		COMMIT TRANSACTION
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSaoChepThongTinLichSuNguonGocSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090827
-- Description:	Sao chép thông tin lịch sử
-- NGUỒN GỐC sử dụng đất của thửa đất với Mã thửa đất
-- lịch sử và Mã hồ sơ cấp GCN hiện thời cho trước
-- =============================================
CREATE PROCEDURE [dbo].[spSaoChepThongTinLichSuNguonGocSuDung]
	-- Add the parameters for the stored procedure here
	@MaThuaDatLichSu BIGINT = NULL,
	@MaHoSoCapGCNHienThoi BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		BEGIN TRANSACTION
			INSERT INTO tblNguonGocSuDungDat(MaHoSoCapGCN,
				ThoiDiemKeKhaiDangKy,KyHieu,DienTich,DaCoTaiLieuChungThuc,
				TenTaiLieuChungThuc,NoiDungChungThuc,GhiChu)
			(SELECT @MaHoSoCapGCNHienThoi,ThoiDiemKeKhaiDangKy,ng.KyHieu,DienTich
				,DaCoTaiLieuChungThuc,TenTaiLieuChungThuc,NoiDungChungThuc,GhiChu
			FROM tblDLieuKGianThuaDatLichSu td
			INNER JOIN tblTrungGianThuaDatHoSo AS tg ON tg.MaThuaDat = td.SW_MEMBER
			INNER JOIN tblHoSoCapGCN AS hs ON hs.MaHoSoCapGCN = tg.MaHoSoCapGCN
			INNER JOIN tblNguonGocSuDungDat AS ng ON ng.MaHoSoCapGCN = hs.MaHoSoCapGCN
			INNER JOIN tblTuDienNguonGocSDD AS tdng ON (tdng.KyHieu = ng.KyHieu)
			WHERE (td.SW_MEMBER = @MaThuaDatLichSu))
			IF (@@ERROR <> 0 )
			BEGIN
				PRINT ''Error!''		
				ROLLBACK TRANSACTION
			END
		COMMIT TRANSACTION
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinCayLauNamDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100104
-- Description:	Cập nhật thông tin CÂY LÂU NĂM đề nghị
-- cấp GCN theo Mã hồ sơ cấp GCN.
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinCayLauNamDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT,
	@ThongTinCayLauNamDeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
		ThongTinCayLauNamDeNghiCapGCN = @ThongTinCayLauNamDeNghiCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSaoChepThongTinLichSuQuiHoach]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090827
-- Description:	Sao chép thông tin lịch sử
-- QUI HOẠCH sử dụng đất của thửa đất với Mã thửa đất
-- lịch sử và Mã hồ sơ cấp GCN hiện thời cho trước
-- =============================================
CREATE PROCEDURE [dbo].[spSaoChepThongTinLichSuQuiHoach]
	-- Add the parameters for the stored procedure here
	@MaThuaDatLichSu BIGINT = NULL,
	@MaHoSoCapGCNHienThoi BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		BEGIN TRANSACTION
			INSERT INTO tblThongTinQuiHoach(MaHoSoCapGCN,KyHieu,DienTich
				,MoTa,GhiChu)
			(SELECT @MaHoSoCapGCNHienThoi,qh.KyHieu,DienTich,qh.MoTa, GhiChu
			FROM tblDLieuKGianThuaDatLichSu td
			INNER JOIN tblTrungGianThuaDatHoSo AS tg ON tg.MaThuaDat = td.SW_MEMBER
			INNER JOIN tblHoSoCapGCN AS hs ON hs.MaHoSoCapGCN = tg.MaHoSoCapGCN
			INNER JOIN tblThongTinQuiHoach AS qh ON qh.MaHoSoCapGCN = hs.MaHoSoCapGCN
			INNER JOIN tblTuDienMucDichSDD AS tdmd ON (tdmd.KyHieu = qh.KyHieu)
			WHERE (td.SW_MEMBER = @MaThuaDatLichSu))
			IF (@@ERROR <> 0 )
			BEGIN
				PRINT ''Error!''		
				ROLLBACK TRANSACTION
			END
		COMMIT TRANSACTION
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091217
-- Description:	Cập nhật thông tin GCN trong bảng
-- tblHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT
	,@TrangThaiHoSoCapGCN  INT
	,@CoQuanCapGCN	NVARCHAR(200) = NULL
	,@MaSoGCN	NVARCHAR(50) = NULL	
	,@GhiChuGCN	NVARCHAR(1000) = NULL	
	,@NghiaVuTaiChinh	NVARCHAR(500) = NULL	
	,@SoHoSoGoc NVARCHAR (50) = NULL
	,@SoPhatHanhGCN NVARCHAR (50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET 
		TrangThaiHoSoCapGCN = CONVERT(INT,@TrangThaiHoSoCapGCN)
		,CoQuanCapGCN = @CoQuanCapGCN
		,MaSoGCN = @MaSoGCN
		,GhiChuGCN = @GhiChuGCN
		,NghiaVuTaiChinh = @NghiaVuTaiChinh
		,SoHoSoGoc = @SoHoSoGoc
		,SoPhatHanhGCN = @SoPhatHanhGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSaoChepThongTinLichSuTaiLieuKemTheo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090827
-- Description:	Sao chép thông tin lịch sử
-- TÀI LIỆU KÈM THEO của thửa đất với Mã thửa đất
-- lịch sử và Mã hồ sơ cấp GCN hiện thời cho trước
-- =============================================
CREATE PROCEDURE [dbo].[spSaoChepThongTinLichSuTaiLieuKemTheo]
	-- Add the parameters for the stored procedure here
	@MaThuaDatLichSu BIGINT = NULL,
	@MaHoSoCapGCNHienThoi BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		BEGIN TRANSACTION
			INSERT INTO tblTaiLieuKemTheo( MaHoSoCapGCN,TenTepDuLieuNguon
				,MoTa,TaiLieu,NgayCapNhat,DinhDangTaiLieu)
			(SELECT @MaHoSoCapGCNHienThoi,TenTepDuLieuNguon
				,MoTa,TaiLieu,NgayCapNhat,DinhDangTaiLieu
			FROM tblDLieuKGianThuaDatLichSu td
			INNER JOIN tblTrungGianThuaDatHoSo AS tg ON tg.MaThuaDat = td.SW_MEMBER
			INNER JOIN tblHoSoCapGCN AS hs ON hs.MaHoSoCapGCN = tg.MaHoSoCapGCN
			INNER JOIN tblTaiLieuKemTheo AS tlkt ON tlkt.MaHoSoCapGCN = hs.MaHoSoCapGCN
			WHERE (td.SW_MEMBER = @MaThuaDatLichSu))
			IF (@@ERROR <> 0 )
			BEGIN
				PRINT ''Error!''		
				ROLLBACK TRANSACTION
			END
		COMMIT TRANSACTION
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinKyGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100223
-- Description:	Cập nhật thông tin ký cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinKyGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT = NULL
	,@DiaDanhNoiCap	NVARCHAR(200) = NULL
	,@NgayKyGCN	NVARCHAR(50) = NULL
	,@TieuDeKyGCN	NVARCHAR(200) = NULL
	,@NguoiKyGCN	NVARCHAR(200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET 
		DiaDanhNoiCap = @DiaDanhNoiCap
		,NgayKyGCN = CONVERT(DATETIME,@NgayKyGCN)
		,TieuDeKyGCN = @TieuDeKyGCN
		,NguoiKyGCN = @NguoiKyGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinHangMucCongTrinhDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100106
-- Description:	Cập nhật thông tin Công trình xây dựng đề nghị
-- cấp GCN theo Mã hồ sơ cấp GCN.
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinHangMucCongTrinhDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT,
	@ThongTinHangMucCongTrinhDeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
		ThongTinHangMucCongTrinhDeNghiCapGCN = @ThongTinHangMucCongTrinhDeNghiCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinNhaODeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091229
-- Description:	Cập nhật thông tin Nhà ở đề nghị
-- cấp GCN theo Mã hồ sơ cấp GCN.
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinNhaODeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT,
	@ThongTinNhaODeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
		ThongTinNhaODeNghiCapGCN = @ThongTinNhaODeNghiCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectThongTinToTrinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 1/2/2010
-- Description:	Tim kiem thong tin ve to trinh de in hang load to trinh
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectThongTinToTrinh]
	@SoToTrinhDiaChinh nvarchar(50)=null,
	@NgayTrinhDiaChinh nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @str2 nvarchar(max) 
declare @str1 nvarchar(max)
set @str1=''SELECT DISTINCT 
                      b.MaHoSoCapGCN, TDCGCN.ToBanDo, TDCGCN.SoThua, TDCGCN.DienTich, TDCGCN.DiaChi, a.SW_MEMBER AS MaThuaDat, a.Status, 
                      b.ToTrinhPhuong AS SoToTrinh, YEAR(b.NgayTrinhPhuong) AS NgayLapToTrinh, a.MaDonViHanhChinh, 
                      dbo.tblTuDienQuyetDinhCapGCN.SoQuyetDinhCapGCN, dbo.tblTuDienQuyetDinhCapGCN.NgayQuyetDinhCapGCN, 
                      dbo.tblTuDienToTrinhDiaChinh.NgayLapToTrinhDiaChinh, dbo.tblTuDienToTrinhDiaChinh.DonViLapToTrinhDiaChinh, 
                      dbo.tblTuDienToTrinhDiaChinh.NgayTrinhDiaChinh, dbo.tblTuDienToTrinhDiaChinh.SoToTrinhDiaChinh
FROM         dbo.tblHoSoTrinhDiaChinh RIGHT OUTER JOIN
                      dbo.tblTuDienToTrinhDiaChinh ON 
                      dbo.tblHoSoTrinhDiaChinh.MaToTrinhDiaChinh = dbo.tblTuDienToTrinhDiaChinh.MaToTrinhDiaChinh LEFT OUTER JOIN
                      dbo.tblHoSoCapGCN AS b INNER JOIN
                      dbo.tblThuaDatCapGCN AS TDCGCN ON TDCGCN.MaHoSoCapGCN = b.MaHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblHoSoQuyetDinhCapGCN AS tblHoSoQuyetDinhCapGCN_1 INNER JOIN
                      dbo.tblTuDienQuyetDinhCapGCN ON tblHoSoQuyetDinhCapGCN_1.MaQuyetDinhCapGCN = dbo.tblTuDienQuyetDinhCapGCN.MaQuyetDinhCapGCN ON 
                      b.MaHoSoCapGCN = tblHoSoQuyetDinhCapGCN_1.MaHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblDLieuKGianThuaDat AS a RIGHT OUTER JOIN
                      dbo.tblTrungGianThuaDatHoSo AS t ON a.SW_MEMBER = t.MaThuaDat ON b.MaHoSoCapGCN = t.MaHoSoCapGCN ON 
                      dbo.tblHoSoTrinhDiaChinh.MaHoSoCapGCN = b.MaHoSoCapGCN ''
if @SoToTrinhDiaChinh is null
	begin
		set @str2=           @str1 + '' where  (day (tblTuDienToTrinhDiaChinh.NgayTrinhDiaChinh) = day('''''' + @NgayTrinhDiaChinh +'''''') and month (tblTuDienToTrinhDiaChinh.NgayTrinhDiaChinh) = month('''''' + @NgayTrinhDiaChinh +'''''')and year (tblTuDienToTrinhDiaChinh.NgayTrinhDiaChinh) = year('''''' + @NgayTrinhDiaChinh +''''''))''
	end
if @NgayTrinhDiaChinh is null
	begin
set @str2=           @str1 + '' where tblTuDienToTrinhDiaChinh.SoToTrinhDiaChinh = '''''' + @SoToTrinhDiaChinh +'''''' ''
	end
if ((@SoToTrinhDiaChinh is not null) and (@NgayTrinhDiaChinh is not null))
	begin
set @str2=           @str1 + '' where tblTuDienToTrinhDiaChinh.SoToTrinhDiaChinh = '''''' + @SoToTrinhDiaChinh +'''''' and  (day (tblTuDienToTrinhDiaChinh.NgayTrinhDiaChinh) = day('''''' + @NgayTrinhDiaChinh +'''''') and month (tblTuDienToTrinhDiaChinh.NgayTrinhDiaChinh) = month('''''' + @NgayTrinhDiaChinh +'''''')and year (tblTuDienToTrinhDiaChinh.NgayTrinhDiaChinh) = year('''''' + @NgayTrinhDiaChinh +''''''))''
	end

exec( @str2)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SeletAllHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 7/11/2009
-- Description:	lay thong tin ho so hoan chinh (Phan In phieu)
-- =============================================
CREATE PROCEDURE [dbo].[sp_SeletAllHoSoCapGCN]
	@MaHoSoCapGCN nvarchar (50)=null
AS
BEGIN
declare @str nvarchar(max)
--set @str=''SELECT DISTINCT 
--                      MaHoSoCapGCN, TrangThaiHoSoCapGCN, SoHoSoTiepNhan, ThuTuTiepNhan, ThoiDiemTiepNhan, NoiNhanHoSo, NgayNhanDuHoSo, 
--                      NgayKeKhaiDangKy, SoHoSoCapGCN, ToBanDo, SoThua, DienTichTuNhien, DiaChiThua, ThoiDiemKeKhaiCapGCN, ThoiDiemHenTra, MaQuanLy, 
--                      ToTrinhPhuong, NgayTrinhPhuong, NgayXetDuyet, KetQuaXetDuyet, CanhBaoTranhChapKhieuKien, NoiDungTranhChapKhieuKien, 
--                      YKienCanBoXetDuyet, KetQuaThamDinh, DienTichThucCap, DienTichRieng, DienTichChung, DienTichKhongCap, QuiHoachChiTiet, 
--                      HanhLangBaoVeCongTrinhHaTang, NgayNopDuHoSoHopLe, TrinhTuThuTucPhuong, CacKhoanPhaiNop, HoTenCanBoThamDinh, NgayThamDinh, 
--                      YKienThamDinh, KetQuaPheDuyet, HoTenCanBoPheDuyet, NgayPheDuyet, YKienPheDuyet, SoToTrinhDiaChinh, NgayTrinhDiaChinh, 
--                      YEAR(NgayTrinhDiaChinh) AS NgayLapToTrinh, DonViLapToTrinhDiaChinh, NoiCapGCN, YEAR(NgayQuyetDinhCapGCN) AS NgayQuyetDinhCapGCN, 
--                      MaSoGCN, GhiChuGCN, NghiaVuTaiChinh, NguoiLapSoQuanLy, SoQuyetDinhCapGCN, NgayVaoSo, SoPhatHanhGCN, 
--                      NgayVaoSo AS Expr1, NgayThongBaoUBND, NgayCongDanNhanThongBao, NgayTraGCN, NgayHoanTatGCN, SoHoSoGoc, NgayKyGCN, 
--                      NguoiKyGCN
--FROM         dbo.tblHoSoCapGCN where tblHoSoCapGCN.MaHoSoCapGCN in ('' + @MaHoSoCapGCN + '')''

--set @str=''SELECT DISTINCT 
--                      MaHoSoCapGCN, TrangThaiHoSoCapGCN, NgayKeKhaiDangKy, SoHoSoCapGCN, ToBanDo, SoThua, DienTichTuNhien, DiaChiThua, 
--                      ThoiDiemKeKhaiCapGCN, ThoiDiemHenTra, MaQuanLy, ToTrinhPhuong, NgayTrinhPhuong, NgayXetDuyet, KetQuaXetDuyet, 
--                      CanhBaoTranhChapKhieuKien, NoiDungTranhChapKhieuKien, YKienCanBoXetDuyet, NgayNopDuHoSoHopLe, TrinhTuThuTucPhuong, 
--                      CacKhoanPhaiNop,  SoToTrinhDiaChinh, NgayTrinhDiaChinh, 
--                      YEAR(NgayTrinhDiaChinh) AS NgayLapToTrinh, DonViLapToTrinhDiaChinh, NoiCapGCN, YEAR(NgayQuyetDinhCapGCN) AS NgayQuyetDinhCapGCN, 
--                      MaSoGCN, GhiChuGCN, NghiaVuTaiChinh, NguoiLapSoQuanLy, SoQuyetDinhCapGCN, NgayVaoSo, SoPhatHanhGCN, NgayVaoSo AS Expr1, 
--                      NgayThongBaoUBND, NgayCongDanNhanThongBao, NgayTraGCN, NgayHoanTatGCN, SoHoSoGoc, NgayKyGCN, NguoiKyGCN
--FROM         dbo.tblHoSoCapGCN where tblHoSoCapGCN.MaHoSoCapGCN in ('' + @MaHoSoCapGCN + '')''

set @str=''SELECT DISTINCT 
                      b.MaHoSoCapGCN, TDCGCN.ToBanDo, TDCGCN.SoThua, TDCGCN.DienTich, TDCGCN.DiaChi, a.SW_MEMBER AS MaThuaDat, a.Status, 
                      b.ToTrinhPhuong AS SoToTrinh, YEAR(b.NgayTrinhPhuong) AS NgayLapToTrinh, YEAR(TDQD.NgayQuyetDinhCapGCN) AS NgayQuyetDinhCapGCN, 
                      a.MaDonViHanhChinh, dbo.tblHoSoTiepNhan.ThoiDiemTiepNhan, dbo.tblHoSoTiepNhan.SoHoSoTiepNhan, dbo.tblHoSoTiepNhan.ThuTuTiepNhan, 
                      dbo.tblTuDienToTrinhDiaChinh.DonViLapToTrinhDiaChinh, TDCGCN.DienTichRieng, TDCGCN.DienTichChung, b.NghiaVuTaiChinh, b.GhiChuGCN
FROM         dbo.tblThuaDatCapGCN AS TDCGCN RIGHT OUTER JOIN
                      dbo.tblHoSoTiepNhan RIGHT OUTER JOIN
                      dbo.tblHoSoCapGCN AS b ON dbo.tblHoSoTiepNhan.MaHoSoCapGCN = b.MaHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblHoSoTrinhDiaChinh ON b.MaHoSoCapGCN = dbo.tblHoSoTrinhDiaChinh.MaHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblTuDienToTrinhDiaChinh ON 
                      dbo.tblHoSoTrinhDiaChinh.MaToTrinhDiaChinh = dbo.tblTuDienToTrinhDiaChinh.MaToTrinhDiaChinh LEFT OUTER JOIN
                      dbo.tblTuDienQuyetDinhCapGCN AS TDQD INNER JOIN
                      dbo.tblHoSoQuyetDinhCapGCN AS HSQD ON TDQD.MaQuyetDinhCapGCN = HSQD.MaQuyetDinhCapGCN ON 
                      b.MaHoSoCapGCN = HSQD.MaHoSoCapGCN ON TDCGCN.MaHoSoCapGCN = b.MaHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblDLieuKGianThuaDat AS a RIGHT OUTER JOIN
                      dbo.tblTrungGianThuaDatHoSo AS t ON a.SW_MEMBER = t.MaThuaDat ON b.MaHoSoCapGCN = t.MaHoSoCapGCN where b.MaHoSoCapGCN in ('' + @MaHoSoCapGCN + '')''

print (@str)
exec (@str)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinRungCayDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100104
-- Description:	Cập nhật thông tin RỪNG CÂY đề nghị
-- cấp GCN theo Mã hồ sơ cấp GCN.
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinRungCayDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT,
	@ThongTinRungCayDeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
		ThongTinRungCayDeNghiCapGCN = @ThongTinRungCayDeNghiCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinSoCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091217
-- Description:	Cập nhật thông tin Sổ cấp GCN trong bảng
-- tblHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinSoCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT = NULL
    ,@KyHieuThamQuyenCapGCN NVARCHAR(50) = NULL
    ,@ThuTuVaoSoCapGCN INT = NULL
    ,@SoVaoSoCapGCN NVARCHAR(50) = NULL
    ,@NgayVaoSoCapGCN NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET 
    KyHieuThamQuyenCapGCN = @KyHieuThamQuyenCapGCN
    ,ThuTuVaoSoCapGCN = CONVERT(INT,@ThuTuVaoSoCapGCN)
    ,SoVaoSoCapGCN = @SoVaoSoCapGCN
    ,NgayVaoSoCapGCN = CONVERT(DATETIME,@NgayVaoSoCapGCN)
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091222
-- Description:	Cập nhật Thông tin Thẩm định thửa đất .
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN NVARCHAR(100) = NULL,
	@ThongTinThuaDatDeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET DATEFORMAT DMY
	UPDATE tblHoSoCapGCN
	SET
		ThongTinThuaDatDeNghiCapGCN = @ThongTinThuaDatDeNghiCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectDanhSachChuDangKyCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091229
-- Description:	Lựa chọn danh sách Chủ (sử dụng, sở hữu)
-- đăng ký cấp GCN theo Mã Hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectDanhSachChuDangKyCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT * FROM tblChu AS C
	INNER JOIN tblChuSoHuu AS CSH ON CSH.MaChu = C.MaChu
	INNER JOIN tblTaiSan AS TS ON TS.MaTaiSan = CSH.MaTaiSan
	INNER JOIN tblHoSoCapGCN AS HoSo ON HoSo.MaHoSoCapGCN = TS.MaHoSoCapGCN
	INNER JOIN tblChuSuDung  AS CSD ON ((CSD.MaChu = C.MaChu)  AND (CSD.MaHoSoCapGCN = HoSo.MaHoSoCapGCN))
	WHERE ( HoSo.MaHoSoCapGCN = @MaHoSoCapGCN )
	PRINT ''Selected''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinTraGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091217
-- Description:	Cập nhật Thông tin Trả GCN trong bảng
-- tblHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinTraGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT
	,@NgayTraGCN	NVARCHAR (50) = NULL
	,@NgayHoanTatGCN	NVARCHAR (50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
    -- Insert statements for procedure here
	UPDATE tblHoSoCapGCN
	SET
	NgayTraGCN = CONVERT(DATETIME,@NgayTraGCN)
	,NgayHoanTatGCN = CONVERT(DATETIME,@NgayHoanTatGCN)
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectGCNThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100118
-- Description:	Truy vấn Thông tin thửa đất Đề nghị cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectGCNThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN NVARCHAR(100) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ThongTinThuaDatDeNghiCapGCN
	FROM tblHoSoCapGCN
	WHERE  1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_XuLyChuSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		PhamXuanChung
-- Create date: <4/11/2009>
-- Description:	<xy ly phan tong hop chu su dung>(Phan cap giay chung nhan)
-- =============================================
CREATE PROCEDURE [dbo].[sp_XuLyChuSuDung]
	@flag int ,
	@MaHoSoCapGCN nvarchar(50)=nulll
AS
BEGIN 
--SELECT DISTINCT    dbo.tblHoSoCapGCN.MaHoSoCapGCN, dbo.tblChu.MaChu,dbo.tblChuSuDung.MaChuSuDung, dbo.tblChuSoHuu.MaChuSoHuu, 
--                      dbo.tblChu.ThoiDiemKeKhaiDangKy, dbo.tblChu.DoiTuongSDD, dbo.tblChu.QuanHe, dbo.tblChu.GioiTinh, dbo.tblChu.HoTen, dbo.tblChu.NamSinh, 
--                      dbo.tblChu.SoDinhDanh, dbo.tblChu.NgayCap, dbo.tblChu.NoiCap, dbo.tblChu.DiaChi, dbo.tblChu.QuocTich, dbo.tblChu.SoHoKhau, 
--                      dbo.tblChu.NgayCapHoKhau, dbo.tblChu.NoiCapHoKhau, dbo.tblChu.TonTai, dbo.tblTuDienDoiTuongSuDungDat.Nhom
--FROM         dbo.tblChu INNER JOIN
--                      dbo.tblChuSuDung ON dbo.tblChu.MaChu = dbo.tblChuSuDung.MaChu INNER JOIN
--                      dbo.tblChuSoHuu ON dbo.tblChu.MaChu = dbo.tblChuSoHuu.MaChu INNER JOIN
--                      dbo.tblTaiSan ON dbo.tblChuSoHuu.MaTaiSan = dbo.tblTaiSan.MaTaiSan INNER JOIN
--                      dbo.tblHoSoCapGCN ON dbo.tblTaiSan.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN AND 
--                      dbo.tblChuSuDung.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN INNER JOIN
--                      dbo.tblTuDienDoiTuongSuDungDat ON dbo.tblChu.DoiTuongSDD = dbo.tblTuDienDoiTuongSuDungDat.KyHieu
--where tblHoSoCapGCN.MaHoSoCapGCN=@MaHoSoCapGCN

if @flag =1 
	begin
		SELECT DISTINCT 
							  dbo.tblChu.MaChu, dbo.tblChu.ThoiDiemKeKhaiDangKy, dbo.tblChu.DoiTuongSDD, dbo.tblChu.QuanHe, dbo.tblChu.GioiTinh, dbo.tblChu.HoTen, 
							  dbo.tblChu.NamSinh, dbo.tblChu.SoDinhDanh, dbo.tblChu.NgayCap, dbo.tblChu.NoiCap, dbo.tblChu.DiaChi, dbo.tblChu.QuocTich, dbo.tblChu.SoHoKhau, 
							  dbo.tblChu.NgayCapHoKhau, dbo.tblChu.NoiCapHoKhau, dbo.tblChu.TonTai, dbo.tblTuDienDoiTuongSuDungDat.Nhom
		FROM         dbo.tblChu LEFT OUTER JOIN
							  dbo.tblChuSuDung ON dbo.tblChu.MaChu = dbo.tblChuSuDung.MaChu RIGHT OUTER JOIN
							  dbo.tblTuDienDoiTuongSuDungDat ON dbo.tblChu.DoiTuongSDD = dbo.tblTuDienDoiTuongSuDungDat.KyHieu
		WHERE     (dbo.tblChuSuDung.MaHoSoCapGCN = @MaHoSoCapGCN)
	end
if @flag=2 
	begin
		SELECT DISTINCT 
							  dbo.tblChu.MaChu, dbo.tblChu.ThoiDiemKeKhaiDangKy, dbo.tblChu.DoiTuongSDD, dbo.tblChu.QuanHe, dbo.tblChu.GioiTinh, dbo.tblChu.HoTen, 
							  dbo.tblChu.NamSinh, dbo.tblChu.SoDinhDanh, dbo.tblChu.NgayCap, dbo.tblChu.NoiCap, dbo.tblChu.DiaChi, dbo.tblChu.QuocTich, dbo.tblChu.SoHoKhau, 
							  dbo.tblChu.NgayCapHoKhau, dbo.tblChu.NoiCapHoKhau, dbo.tblChu.TonTai, dbo.tblTuDienDoiTuongSuDungDat.Nhom
		FROM         dbo.tblChu LEFT OUTER JOIN
							  dbo.tblChuSuDung ON dbo.tblChu.MaChu = dbo.tblChuSuDung.MaChu RIGHT OUTER JOIN
							  dbo.tblTuDienDoiTuongSuDungDat ON dbo.tblChu.DoiTuongSDD = dbo.tblTuDienDoiTuongSuDungDat.KyHieu
		WHERE     (dbo.tblChuSuDung.MaHoSoCapGCN = @MaHoSoCapGCN)
		union (SELECT DISTINCT 
							  dbo.tblChu.MaChu, dbo.tblChu.ThoiDiemKeKhaiDangKy, dbo.tblChu.DoiTuongSDD, dbo.tblChu.QuanHe, dbo.tblChu.GioiTinh, dbo.tblChu.HoTen, 
							  dbo.tblChu.NamSinh, dbo.tblChu.SoDinhDanh, dbo.tblChu.NgayCap, dbo.tblChu.NoiCap, dbo.tblChu.DiaChi, dbo.tblChu.QuocTich, dbo.tblChu.SoHoKhau, 
							  dbo.tblChu.NgayCapHoKhau, dbo.tblChu.NoiCapHoKhau, dbo.tblChu.TonTai, dbo.tblTuDienDoiTuongSuDungDat.Nhom
		FROM         dbo.tblTaiSan RIGHT OUTER JOIN
							  dbo.tblChuSoHuu ON dbo.tblTaiSan.MaTaiSan = dbo.tblChuSoHuu.MaTaiSan RIGHT OUTER JOIN
							  dbo.tblChu RIGHT OUTER JOIN
							  dbo.tblTuDienDoiTuongSuDungDat ON dbo.tblChu.DoiTuongSDD = dbo.tblTuDienDoiTuongSuDungDat.KyHieu ON 
							  dbo.tblChuSoHuu.MaChu = dbo.tblChu.MaChu
		  where (dbo.tblTaiSan.MaHoSoCapGCN = @MaHoSoCapGCN))
	end
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienLoaiHinhBienDong]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày hiệu chỉnh: 20100313
--Người tạo: Vũ Lê Thành,
--Mục đích: Cập nhật bảng từ điển Loại hình biến động
CREATE PROC [dbo].[spUpdateTuDienLoaiHinhBienDong]
	@KyHieu NVARCHAR (500) = NULL ,
	@MoTa NVARCHAR (500) = NULL,
	@Nhom NVARCHAR (100) = NULL
AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	UPDATE tblTuDienLoaiHinhBienDong
	SET KyHieu=@KyHieu ,MoTa=@MoTa 
	WHERE KyHieu = @KyHieu

	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectGhiChuNoiDungChuDeNghiCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vu Le Thanh
-- Create date: 20091126
-- Description:	Truy vấn thông tin Chủ GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectGhiChuNoiDungChuDeNghiCapGCN]
	@MaHoSoCapGCN BIGINT=null
AS
BEGIN
	SELECT GhiChuNoiDungChuDeNghiCapGCN
	FROM tblHoSoCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectGCNThongTinNhaODeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100118
-- Description:	HIỂN THỊ THÔNG TIN TÀI SẢN
-- LÀ NHÀ Ở ĐỀ NGHỊ CẤP GCN THEO MÃ HỒ SƠ CẤP GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectGCNThongTinNhaODeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ThongTinNhaODeNghiCapGCN
	FROM tblHoSoCapGCN
	WHERE 1 = 1
	AND (case @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN  ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_UpdateTraGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		pham xuan chung
-- Create date: 31/10/2009
-- Description:	update thong tin tra giay chung nhan(phan cap giay chung nhan)
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateTraGCN]
	@MaHoSoCapGCN nvarchar(50)=null,
	@NgayTraGCN nvarchar(50)=null,
	@NgayHoanTatGCN nvarchar(50)=null,
	@TrangThaiHoSoCapGCN nvarchar (50)
AS
BEGIN
	update tblHoSoCapGCN set NgayTraGCN=@NgayTraGCN,NgayHoanTatGCN=@NgayHoanTatGCN,TrangThaiHoSoCapGCN=@TrangThaiHoSoCapGCN where MaHoSoCapGCN=@MaHoSoCapGCN

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectGhiChuNoiDungChuDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091222
-- Description:	Truy vấn Thông tin Chủ sử dụng
-- đề nghị cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectGhiChuNoiDungChuDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT,
	@GhiChuNoiDungChuDeNghiCapGCN NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaHoSoCapGCN,GhiChuNoiDungChuDeNghiCapGCN
	FROM tblHoSoCapGCN
	WHERE 1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spChuSuDungCursor]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spChuSuDungCursor] 
	@MaHoSoCapGCN nvarchar(50),
	@ChuHo nvarchar (500)output ,
	@ChuSuDungCursor CURSOR VARYING OUTPUT
	AS
	Declare @HoTen nvarchar (50)
	Declare @ChuHoSo nvarchar (500)	
	SET @ChuSuDungCursor = CURSOR
	FORWARD_ONLY STATIC FOR
	SELECT HoTen
	FROM tblChuSuDungDat
	WHERE convert(bigint,@MaHoSoCapGCN) = MaHoSoCapGCN
	OPEN @ChuSuDungCursor
	Set @ChuHoSo = ''''

	FETCH NEXT FROM @ChuSuDungCursor INTO @HoTen
	WHILE @@FETCH_STATUS = 0
		BEGIN
			Set @ChuHoSo = @ChuHoSo + @HoTen 
			FETCH NEXT FROM @ChuSuDungCursor INTO @HoTen
			Set @ChuHoSo = @ChuHoSo + ''\''
		END
	Set @ChuHo = @ChuHoSo' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectNguonGocChiTietByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Phạm Xuân Chung, Vũ Lê Thành
-- Create date: 20100316
-- Description:	Select thông tin Nguồn gốc chi tiết
-- theo Mã hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectNguonGocChiTietByMaHoSoCapGCN]
	@MaHoSoCapGCN NVARCHAR(50)=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT  NGSDD.ChiTiet 
	FROM    
			dbo.tblHoSoCapGCN AS HS
			INNER JOIN dbo.tblThuaDatCapGCN AS TDCGCN ON TDCGCN.MaHoSoCapGCN = HS.MaHoSoCapGCN
			INNER JOIN dbo.tblNguonGocSuDungDat AS NGSDD ON NGSDD.MaThuaDatCapGCN = TDCGCN.MaThuaDatCapGCN
	WHERE     (HS.MaHoSoCapGCN =@MaHoSoCapGCN)
	END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinHoSoByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 12/05/2010
-- Description:	LayThongTin ve ho so theo ma ho so cap GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinHoSoByMaHoSoCapGCN]
	@MaHoSoCapGCN nvarchar(20)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET NOCOUNT ON;
	declare @HoTen nvarchar(200)
	declare @strHoTen nvarchar(300)
set @strHoTen=''''
	DECLARE db_cursor CURSOR FOR 
	SELECT  distinct   dbo.tblChu.HoTen
	FROM         dbo.tblChu RIGHT OUTER JOIN
						  dbo.tblChuHoSoCapGCN ON dbo.tblChu.MaChu = dbo.tblChuHoSoCapGCN.MaChu
	WHERE     (dbo.tblChuHoSoCapGCN.MaHoSoCapGCN = @MaHoSoCapGCN)
	OPEN db_cursor  
	FETCH NEXT FROM db_cursor INTO @HoTen  

	WHILE @@FETCH_STATUS = 0  
	BEGIN  
		set @strHoTen = @strHoten + @HoTen + '', ''
		   FETCH NEXT FROM db_cursor INTO @HoTen
	END  
	CLOSE db_cursor  
	DEALLOCATE db_cursor
print @strHoTen

SELECT     dbo.tblThuaDatCapGCN.ToBanDo as ''Tờ bản đồ'', dbo.tblThuaDatCapGCN.SoThua as ''Số Thửa'', dbo.tblThuaDatCapGCN.DienTich as ''Diện tích'', dbo.tblThuaDatCapGCN.DiaChi as ''Địa chỉ'', @strHoTen as ''Chủ sử dụng'',
                      dbo.tblThongTinKiemKe.KyHieu AS ''Kiểm kê'', dbo.tblThongTinQuiHoach.KyHieu AS ''Quy hoạch''
FROM         dbo.tblThuaDatCapGCN RIGHT OUTER JOIN
                      dbo.tblHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblThongTinKiemKe ON dbo.tblHoSoCapGCN.MaHoSoCapGCN = dbo.tblThongTinKiemKe.MaHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblThongTinQuiHoach ON dbo.tblHoSoCapGCN.MaHoSoCapGCN = dbo.tblThongTinQuiHoach.MaHoSoCapGCN ON 
                      dbo.tblThuaDatCapGCN.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN
where tblHoSoCapGCN.MaHoSoCapGCN=@MaHoSoCapGCN
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectMaHoSoCapGCNByToBanDoSoThua]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		pham xuan chung	
-- Create date: 12/5/2010
-- Description:	lay thong tin ho so theo to ban do va so thua
-- =============================================
CREATE PROCEDURE [dbo].[spSelectMaHoSoCapGCNByToBanDoSoThua]
	-- Add the parameters for the stored procedure h
@MaThuaDat nvarchar(20)=null,
@DienTichTuNhien nvarchar(20)=null,
	@ToBanDo nvarchar(10)=null,
	@SoThua nvarchar(10)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  SELECT     MaHoSoCapGCN, DienTich, DiaChi, MaThuaDat
FROM         dbo.tblThuaDatCapGCN
where ToBanDo=@ToBanDo and SoThua=@SoThua
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThuaDatCapGCNByMaThuaDatCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 20100206
--Người tạo: Vũ Lê Thành,
--Mục đích: Cập nhật bảng tblThuaDatCapGCN
CREATE PROC [dbo].[spDeleteThuaDatCapGCNByMaThuaDatCapGCN]
		@MaThuaDatCapGCN	BIGINT = NULL
		,@MaHoSoCapGCN	BIGINT = NULL
		,@ToBanDo	NVARCHAR(50) = NULL
		,@SoThua	NVARCHAR(50) = NULL
		,@DiaChi	NVARCHAR(500) = NULL
		,@DienTich	NVARCHAR(50) = NULL
		,@DienTichBangChu	NVARCHAR(500) = NULL
		,@DienTichRieng	NVARCHAR(50) = NULL
		,@DienTichChung	NVARCHAR(50) = NULL
		,@MucDichSuDung	NVARCHAR(50) = NULL
		,@ThoiHanSuDung	NVARCHAR(200) = NULL
		,@NguonGocSuDung NVARCHAR(50) = NULL
		,@DienTichKhongCap	FLOAT = NULL
		,@DienTichKhongCapBangChu	NVARCHAR(200) = NULL
		,@LyDoKhongCap	NVARCHAR(500) = NULL
AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	--Truong hop xoa mot ban ghi voi Mã thửa đất cấp GCN
	BEGIN
		DELETE FROM tblThuaDatCapGCN
		WHERE (MaThuaDatCapGCN = @MaThuaDatCapGCN)
	END

	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinQuyetDinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[spSelectThongTinQuyetDinh](@MaHoSoCapGCN bigint)
as
 SELECT     dbo.tblNhaO.DiaChiNha, dbo.tblThuaDatCapGCN.DienTich, dbo.tblThuaDatCapGCN.DienTichRieng, dbo.tblThuaDatCapGCN.DienTichChung, 
                      dbo.tblThuaDatCapGCN.MucDichSuDung, dbo.tblNhaO.MaHoSoCapGCN, dbo.tblChu.HoTen, dbo.tblNhaO.SoTang
FROM         dbo.tblThuaDatCapGCN INNER JOIN
                      dbo.tblNhaO ON dbo.tblThuaDatCapGCN.MaHoSoCapGCN = dbo.tblNhaO.MaHoSoCapGCN INNER JOIN
                      dbo.tblChuHoSoCapGCN ON dbo.tblThuaDatCapGCN.MaHoSoCapGCN = dbo.tblChuHoSoCapGCN.MaHoSoCapGCN INNER JOIN
                      dbo.tblChu ON dbo.tblChuHoSoCapGCN.MaChu = dbo.tblChu.MaChu
where dbo.tblNhaO.MaHoSoCapGCN = @MaHoSoCapGCN
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThuaDatCapGCNWithHoSoKyThuat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Date modified: 20100402
--Create by: Vũ Lê Thành
--Discription: Select bảng tblThuaDatCapGCN.
CREATE PROC [dbo].[spSelectThuaDatCapGCNWithHoSoKyThuat]
		@MaHoSoCapGCN	BIGINT = NULL
AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	SELECT *
	FROM tblThuaDatCapGCN
	WHERE 1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN  ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThuaDatCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--Ngày tạo gần nhất: 20100206
--Người tạo: Vũ Lê Thành,
--Mục đích: Select bảng tblThuaDatCapGCN
CREATE PROC [dbo].[spSelectThuaDatCapGCNByMaHoSoCapGCN]
		@MaThuaDatCapGCN	BIGINT = NULL
		,@MaHoSoCapGCN	BIGINT = NULL
		,@ToBanDo	NVARCHAR(50) = NULL
		,@SoThua	NVARCHAR(50) = NULL
		,@DiaChi	NVARCHAR(500) = NULL
		,@DienTich	NVARCHAR(50) = NULL
		,@DienTichBangChu	NVARCHAR(500) = NULL
		,@DienTichRieng	NVARCHAR(50) = NULL
		,@DienTichChung	NVARCHAR(50) = NULL
		,@MucDichSuDung	NVARCHAR(50) = NULL
		,@ThoiHanSuDung	NVARCHAR(200) = NULL
		,@NguonGocSuDung NVARCHAR(50) = NULL
		,@DienTichKhongCap	FLOAT = NULL
		,@DienTichKhongCapBangChu	NVARCHAR(200) = NULL
		,@LyDoKhongCap	NVARCHAR(500) = NULL
		,@GhiChu	NVARCHAR(500) = NULL
AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	SELECT *
	FROM tblThuaDatCapGCN
	WHERE 1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN  ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
	SET NOCOUNT OFF
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinThuaDatDangKyCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100210
-- Description:	Lựa chọn danh sách Thửa đất
-- đăng ký cấp GCN theo Mã Hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinThuaDatDangKyCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT *
	FROM tblThuaDatCapGCN
	WHERE (MaHoSoCapGCN = @MaHoSoCapGCN)
	PRINT ''Selected''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinNhaO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[spSelectThongTinNhaO](@MaHoSoCapGCN bigint)
as
SELECT     dbo.tblNhaO.SoTang, dbo.tblHoSoPheDuyet.HoTenCanBoPheDuyet, dbo.tblNhaO.KetCauNha, dbo.tblNhaO.NamXayDung, 
                      dbo.tblNhaO.DienTichXayDung, dbo.tblThuaDatCapGCN.DiaChi
FROM         dbo.tblThuaDatCapGCN INNER JOIN
                      dbo.tblChuHoSoCapGCN ON dbo.tblThuaDatCapGCN.MaHoSoCapGCN = dbo.tblChuHoSoCapGCN.MaHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblNhaO ON dbo.tblChuHoSoCapGCN.MaHoSoCapGCN = dbo.tblNhaO.MaHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblHoSoPheDuyet ON dbo.tblChuHoSoCapGCN.MaHoSoCapGCN = dbo.tblHoSoPheDuyet.MaHoSoCapGCN
WHERE     (dbo.tblChuHoSoCapGCN.MaHoSoCapGCN = @MaHoSoCapGCN)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinThuaDatByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE procedure [dbo].[spSelectThongTinThuaDatByMaHoSoCapGCN](@MaHoSoCapGCN bigint)
as
SELECT     dbo.tblThuaDatCapGCN.DiaChi, dbo.tblThuaDatCapGCN.DienTich, dbo.tblThuaDatCapGCN.DienTichRieng, dbo.tblThuaDatCapGCN.DienTichChung, 
                      dbo.tblThuaDatCapGCN.MucDichSuDung, dbo.tblThuaDatCapGCN.ThoiHanSuDung, dbo.tblThuaDatCapGCN.ToBanDo, dbo.tblThuaDatCapGCN.SoThua, 
                      dbo.tblNguonGocSuDungDat.ChiTiet AS NguonGocSuDung
FROM         dbo.tblThuaDatCapGCN LEFT OUTER JOIN
                      dbo.tblNguonGocSuDungDat ON dbo.tblThuaDatCapGCN.MaThuaDatCapGCN = dbo.tblNguonGocSuDungDat.MaThuaDatCapGCN
WHERE     (MaHoSoCapGCN = @MaHoSoCapGCN)


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spThongTinBienDongHoSo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Phạm Xuân Chung
-- Create date: 29/07/2010
-- Description:	Thong tin ho so bien dong
-- =============================================
CREATE PROCEDURE [dbo].[spThongTinBienDongHoSo]
	@flag int=null,
	@MaThuaDat bigint =null,
	@MaHoSoCapGCN bigint =null
AS
BEGIN
	
	SET NOCOUNT ON;
	if @flag =0 
		begin
			SELECT      MaThuaDat, MaHoSoCapGCN,ThoiDiemDangKy, NoidungSoDiaChinh as noidung
			FROM         dbo.tblDangKyBienDong
			where MaThuaDat =@MaThuaDat 
			order by ThoiDiemDangKy
		end
    if @flag =1
		begin
			SELECT     dbo.tblDangKyBienDong.ThoiDiemDangKy, dbo.tblDangKyBienDong.NoidungSoDiaChinh, dbo.tblThuaDatCapGCN.ToBanDo, 
								  dbo.tblThuaDatCapGCN.SoThua, dbo.tblThuaDatCapGCN.DiaChi, dbo.tblThuaDatCapGCN.DienTich, dbo.tblChu.HoTen, 
								  dbo.tblHoSoCapGCN.HoSoKiThuatThamDinh
			FROM         dbo.tblChu INNER JOIN
								  dbo.tblChuDeNghiCapGCN ON dbo.tblChu.MaChu = dbo.tblChuDeNghiCapGCN.MaChu INNER JOIN
								  dbo.tblDangKyBienDong INNER JOIN
								  dbo.tblHoSoCapGCN ON dbo.tblDangKyBienDong.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN INNER JOIN
								  dbo.tblThuaDatCapGCN ON dbo.tblHoSoCapGCN.MaHoSoCapGCN = dbo.tblThuaDatCapGCN.MaHoSoCapGCN ON 
								  dbo.tblChuDeNghiCapGCN.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN
			where tblHoSoCapGCN.MaHoSoCapGCN =@MaHoSoCapGCN
		end
	if @flag =2
		begin
			SELECT     MaThuaDat, MaHoSoCapGCN, ThoiDiemDangKy
			FROM         dbo.tblDangKyBienDong
			where MaThuaDat =@MaThuaDat and MaHoSoCapGCN =@MaHoSoCapGCN
		end
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectMaThuaDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:	Pham xuan chung
-- Create date: 1/11/2009
-- Description:	Lay ma thua dat (Phan soan ho so)
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectMaThuaDat] 
	@MaHoSoCapGCN nvarchar (50)=NULL
AS
BEGIN
	SELECT MaThuaDat FROM tblHoSoCapGCN 
	INNER JOIN tblThuaDatCapGCN ON tblHoSoCapGCN.MaHoSoCapGCN = tblThuaDatCapGCN.MaHoSoCapGCN 
	WHERE tblHoSoCapGCN.MaHoSoCapGCN= @MaHoSoCapGCN 
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_selectInPhieuTaiSan]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung	
-- Create date: 28/12/2009
-- Description:	Lay thong tin tai san de in vao giay quyet dinh cap GCN (Phan In QUyet dinh cap GCN + to trinh )
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectInPhieuTaiSan]
	@MaHoSoCapGCN nvarchar(50)=null
AS
BEGIN
--	SELECT     dbo.tblTaiSan.LoaiNha, dbo.tblTaiSan.DiaChiNha, dbo.tblTaiSan.DienTichXayDung, dbo.tblTaiSan.DienTichSanXayDung, 
--                      dbo.tblTaiSan.DienTichSanPhu, dbo.tblHoSoCapGCN.DienTichChung, dbo.tblHoSoCapGCN.DienTichRieng, dbo.tblTaiSan.KetCauNha, 
--                      dbo.tblTaiSan.CapHangNha, dbo.tblTaiSan.SoTang, dbo.tblTaiSan.NamXayDung, dbo.tblTaiSan.NamHoanThanhXayDung, 
--                      dbo.tblTaiSan.NgayCapPhepXayDung, dbo.tblTaiSan.ThoiHanSoHuu
--FROM         dbo.tblTaiSan INNER JOIN
--                      dbo.tblChuSoHuu ON dbo.tblTaiSan.MaTaiSan = dbo.tblChuSoHuu.MaTaiSan INNER JOIN
--                      dbo.tblHoSoCapGCN ON dbo.tblTaiSan.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN
SELECT     dbo.tblNhaO.LoaiNha, dbo.tblNhaO.DiaChiNha, dbo.tblNhaO.DienTichXayDung, dbo.tblNhaO.DienTichSanXayDung, dbo.tblNhaO.DienTichSanPhu, 
                      dbo.tblThuaDatCapGCN.DienTichChung, dbo.tblThuaDatCapGCN.DienTichRieng, dbo.tblNhaO.KetCauNha, dbo.tblNhaO.CapHangNha, 
                      dbo.tblNhaO.SoTang, dbo.tblNhaO.NamXayDung, dbo.tblNhaO.NamHoanThanhXayDung, dbo.tblNhaO.NgayCapPhepXayDung, 
                      dbo.tblNhaO.ThoiHanSoHuu
FROM         dbo.tblNhaO RIGHT OUTER JOIN
                      dbo.tblHoSoCapGCN ON dbo.tblNhaO.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblThuaDatCapGCN ON dbo.tblHoSoCapGCN.MaHoSoCapGCN = dbo.tblThuaDatCapGCN.MaHoSoCapGCN where tblNhaO.MaHoSoCapGCN=@MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectInPhieuNguonGocSuDungDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan CHung
-- Create date: <12/11/2009>
-- Description:	<lau NguonGoc su dung dat>(phan in giay quyet dinh)
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectInPhieuNguonGocSuDungDat]
@MaHoSoCapGCN nvarchar (50) =null
AS
BEGIN
SELECT     dbo.tblNguonGocSuDungDat.ThoiDiemKeKhaiDangKy, dbo.tblNguonGocSuDungDat.KyHieu, dbo.tblNguonGocSuDungDat.DienTich, 
                      dbo.tblNguonGocSuDungDat.DaCoTaiLieuChungThuc, dbo.tblNguonGocSuDungDat.TenTaiLieuChungThuc, 
                      dbo.tblNguonGocSuDungDat.NoiDungChungThuc, dbo.tblNguonGocSuDungDat.GhiChu, dbo.tblHoSoCapGCN.MaHoSoCapGCN, 
                      dbo.tblTuDienNguonGocSDD.MoTa
FROM         dbo.tblThuaDatCapGCN LEFT OUTER JOIN
                      dbo.tblTuDienNguonGocSDD INNER JOIN
                      dbo.tblNguonGocSuDungDat ON dbo.tblTuDienNguonGocSDD.KyHieu = dbo.tblNguonGocSuDungDat.KyHieu ON 
                      dbo.tblThuaDatCapGCN.MaThuaDatCapGCN = dbo.tblNguonGocSuDungDat.MaThuaDatCapGCN RIGHT OUTER JOIN
                      dbo.tblHoSoCapGCN ON dbo.tblThuaDatCapGCN.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN where tblHoSoCapGCN.MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectInPhieuMucDichSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan CHung
-- Create date: <12/11/2009>
-- Description:	<lau muc dich su dung dat>(phan in giay quyet dinh)
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectInPhieuMucDichSuDung]
@MaHoSoCapGCN nvarchar (50) =null
AS
BEGIN
SELECT     dbo.tblMucDichSuDungDat.ThoiDiemKeKhaiDangKy, dbo.tblMucDichSuDungDat.DienTichKeKhai, dbo.tblMucDichSuDungDat.ThoiHan AS namSuDung, 
                      dbo.tblMucDichSuDungDat.GhiChu, dbo.tblThuaDatCapGCN.SoThua, dbo.tblThuaDatCapGCN.ToBanDo, dbo.tblMucDichSuDungDat.KyHieu, 
                      dbo.tblTuDienMucDichSDD.MoTa
FROM         dbo.tblThuaDatCapGCN LEFT OUTER JOIN
                      dbo.tblHoSoCapGCN ON dbo.tblThuaDatCapGCN.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblTuDienMucDichSDD INNER JOIN
                      dbo.tblMucDichSuDungDat ON dbo.tblTuDienMucDichSDD.KyHieu = dbo.tblMucDichSuDungDat.KyHieu ON 
                      dbo.tblThuaDatCapGCN.MaThuaDatCapGCN = dbo.tblMucDichSuDungDat.MaThuaDatCapGCN where tblHoSoCapGCN.MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spPhieuThamDinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Date Modified: 200807
--Create by: Vũ Lê Thành,
--Dicription: Select thông tin Phiếu thẩm định Hồ sơ cấp GCN

CREATE PROC [dbo].[spPhieuThamDinh]
	@MaHoSoCapGCN BIGINT
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	-- Select thông tin Thẩm định Hồ sơ cấp GCN
	SELECT HoSo.MaHoSoCapGCN,ThongTinThuaDatDeNghiCapGCN,ThongTinNhaODeNghiCapGCN
	,ToBanDo,SoThua,DienTich,DienTichBangChu,DiaChi
	,MucDich.DienTichRieng,ThuaDat.DienTichChung,ChiTietQuiHoach
	,NgayNopDuHoSoHopLe,TrinhTuThuTucPhuong,HanhLangBaoVeCongTrinhHaTang
	,HoTenCanBoThamDinh,YKienThamDinh,ToTrinhPhuong,NghiaVuTaiChinh
	,DienTichKhongCap,DienTichKhongCapBangChu
	FROM   tblHoSoCapGCN  AS HoSo
	INNER JOIN tblThuaDatCapGCN AS ThuaDat ON ThuaDat.MaHoSoCapGCN = HoSo.MaHoSoCapGCN
	INNER JOIN tblMucDichSuDungDat AS MucDich ON MucDich.MaThuaDatCapGCN = ThuaDat.MaThuaDatCapGCN
	INNER JOIN tblHoSoThamDinh AS ThamDinh ON ThamDinh.MaHoSoCapGCN = HoSo.MaHoSoCapGCN
	WHERE  1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN  ELSE HoSo.MaHoSoCapGCN END) = @MaHoSoCapGCN
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_selectThongTinDatInQuyetDinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 22/01/2009
-- Description:	lay thong tin ve dat, nha o de in quyet dinh trinh  va to trinh
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectThongTinDatInQuyetDinh]
	@MaHoSoCapGCN nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT     dbo.tblThuaDatCapGCN.DienTich, dbo.tblThuaDatCapGCN.DiaChi as DiaChiThua, dbo.tblThuaDatCapGCN.DienTichRieng, dbo.tblThuaDatCapGCN.DienTichChung, 
						  dbo.tblNhaO.DienTichXayDung AS DienTichSuDung, dbo.tblNhaO.KetCauNha AS KetCau, CAST(dbo.tblNhaO.SoTang AS nvarchar(50)) AS SoTang, 
						  dbo.tblHoSoCapGCN.ToTrinhPhuong, dbo.tblHoSoCapGCN.NgayTrinhPhuong, dbo.tblHoSoCapGCN.MaHoSoCapGCN,CAST(dbo.tblNhaO.NamXayDung AS nvarchar(50)) as NgayXayDung
						,NghiaVuTaiChinh
	FROM         dbo.tblHoSoCapGCN LEFT OUTER JOIN
						  dbo.tblThuaDatCapGCN ON dbo.tblHoSoCapGCN.MaHoSoCapGCN = dbo.tblThuaDatCapGCN.MaHoSoCapGCN LEFT OUTER JOIN
						  dbo.tblNhaO ON dbo.tblHoSoCapGCN.MaHoSoCapGCN = dbo.tblNhaO.MaHoSoCapGCN
	WHERE tblHoSoCapGCN.MaHoSoCapGCN=@MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectPhieuChuyenThongTinDiaChinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan CHung
-- Create date: 29/1/2010
-- Description:	Lay thong tin in ra phieu chuyen thong tin dia chinh
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectPhieuChuyenThongTinDiaChinh]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

--   SELECT     dbo.tblHoSoCapGCN.DienTichTuNhien AS DienTich, dbo.tblHoSoCapGCN.DiaChiThua AS diachi, dbo.tblHoSoCapGCN.DienTichRieng, 
--                      dbo.tblHoSoCapGCN.DienTichChung, dbo.tblNhaO.DienTichXayDung AS DienTichSuDung, dbo.tblNhaO.KetCauNha AS KetCau, 
--                      CAST(dbo.tblNhaO.SoTang AS nvarchar(3)) AS SoTang, dbo.tblHoSoCapGCN.SoThua AS thuadat, dbo.tblHoSoCapGCN.ToBanDo, 
--                      dbo.tblTuDienNguonGocSDD.MoTa AS NguonGocSuDung, dbo.tblTuDienMucDichSDD.MoTa AS MucDichSD, 
--                      dbo.tblNhaO.DienTichSanXayDung AS DienTichSan, dbo.tblNhaO.CapHangNha AS CapNha
--FROM         dbo.tblNhaO RIGHT OUTER JOIN
--                      dbo.tblMucDichSuDungDat INNER JOIN
--                      dbo.tblTuDienMucDichSDD ON dbo.tblMucDichSuDungDat.KyHieu = dbo.tblTuDienMucDichSDD.KyHieu RIGHT OUTER JOIN
--                      dbo.tblTuDienNguonGocSDD INNER JOIN
--                      dbo.tblNguonGocSuDungDat ON dbo.tblTuDienNguonGocSDD.KyHieu = dbo.tblNguonGocSuDungDat.KyHieu RIGHT OUTER JOIN
--                      dbo.tblHoSoCapGCN ON dbo.tblNguonGocSuDungDat.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN ON 
--                      dbo.tblMucDichSuDungDat.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN ON 
--                      dbo.tblNhaO.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN
SELECT     dbo.tblThuaDatCapGCN.DienTich, dbo.tblThuaDatCapGCN.diachi AS diachi, dbo.tblThuaDatCapGCN.DienTichRieng, 
                      dbo.tblThuaDatCapGCN.DienTichChung, dbo.tblNhaO.DienTichXayDung AS DienTichSuDung, dbo.tblNhaO.KetCauNha AS KetCau, 
                      CAST(dbo.tblNhaO.SoTang AS nvarchar(50)) AS SoTang, dbo.tblThuaDatCapGCN.SoThua AS thuadat, dbo.tblThuaDatCapGCN.ToBanDo, 
                      dbo.tblTuDienNguonGocSDD.MoTa AS NguonGocSuDung, dbo.tblTuDienMucDichSDD.MoTa AS MucDichSD, 
                      dbo.tblNhaO.DienTichSanXayDung AS DienTichSan, dbo.tblNhaO.CapHangNha AS CapNha,dbo.tblNhaO.NamXayDung as NgayXayDung
FROM         dbo.tblTuDienNguonGocSDD INNER JOIN
                      dbo.tblNguonGocSuDungDat ON dbo.tblTuDienNguonGocSDD.KyHieu = dbo.tblNguonGocSuDungDat.KyHieu RIGHT OUTER JOIN
                      dbo.tblMucDichSuDungDat INNER JOIN
                      dbo.tblTuDienMucDichSDD ON dbo.tblMucDichSuDungDat.KyHieu = dbo.tblTuDienMucDichSDD.KyHieu RIGHT OUTER JOIN
                      dbo.tblThuaDatCapGCN INNER JOIN
                      dbo.tblHoSoCapGCN ON dbo.tblThuaDatCapGCN.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN ON 
                      dbo.tblMucDichSuDungDat.MaThuaDatCapGCN = dbo.tblThuaDatCapGCN.MaThuaDatCapGCN ON 
                      dbo.tblNguonGocSuDungDat.MaThuaDatCapGCN = dbo.tblThuaDatCapGCN.MaThuaDatCapGCN LEFT OUTER JOIN
                      dbo.tblNhaO ON dbo.tblHoSoCapGCN.MaHoSoCapGCN = dbo.tblNhaO.MaHoSoCapGCN
where tblHoSoCapGCN.MaHoSoCapGCN=@MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThuaDatCapGCNByMaThuaDatCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--Ngày tạo gần nhất: 20100206
--Người tạo: Vũ Lê Thành,
--Mục đích: Cập nhật bảng tblThuaDatCapGCN
CREATE PROC [dbo].[spUpdateThuaDatCapGCNByMaThuaDatCapGCN]
		@MaThuaDatCapGCN	BIGINT = NULL
		,@MaHoSoCapGCN	BIGINT = NULL
		,@ToBanDo	NVARCHAR(50) = NULL
		,@SoThua	NVARCHAR(50) = NULL
		,@DiaChi	NVARCHAR(500) = NULL
		,@DienTich	NVARCHAR(50) = NULL
		,@DienTichBangChu	NVARCHAR(500) = NULL
		,@DienTichRieng	NVARCHAR(50) = NULL
		,@DienTichChung	NVARCHAR(50) = NULL
		,@MucDichSuDung	NVARCHAR(50) = NULL
		,@ThoiHanSuDung	NVARCHAR(200) = NULL
		,@NguonGocSuDung NVARCHAR(50) = NULL
		,@DienTichKhongCap	FLOAT = NULL
		,@DienTichKhongCapBangChu	NVARCHAR(200) = NULL
		,@LyDoKhongCap	NVARCHAR(500) = NULL
		,@GhiChu	NVARCHAR(500) = NULL
AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
		--Truong hop cap nhat Bang Ma
	BEGIN	
		SET DATEFORMAT DMY
		UPDATE tblThuaDatCapGCN
		SET
		 MaHoSoCapGCN =  CONVERT(BIGINT,@MaHoSoCapGCN)
		,ToBanDo =  @ToBanDo
		,SoThua = @SoThua
		,DiaChi = @DiaChi
		,DienTich = CONVERT(FLOAT, @DienTich)
		,DienTichBangChu = @DienTichBangChu
		,DienTichRieng = CONVERT(FLOAT,@DienTichRieng)
		,DienTichChung = CONVERT(FLOAT,@DienTichChung)
		,MucDichSuDung = @MucDichSuDung
		,ThoiHanSuDung = @ThoiHanSuDung
		,NguonGocSuDung = @NguonGocSuDung
		,DienTichKhongCap	 = @DienTichKhongCap
		,DienTichKhongCapBangChu	 = @DienTichKhongCapBangChu
		,LyDoKhongCap	 = @LyDoKhongCap,GhiChu =@GhiChu
		WHERE (MaThuaDatCapGCN = @MaThuaDatCapGCN) 
	END

	SET NOCOUNT OFF
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectDiaChiThuaDatByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100407
-- Description:	Truy vấn thông tin địa chỉ thửa đất 
-- theo Mã hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectDiaChiThuaDatByMaHoSoCapGCN] 
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT DiaChi
	FROM tblThuaDatCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


--Ngày tạo gần nhất: 20100510
--Người tạo: Quách Văn Phong ,
--Mục đích: Kiểm tra sự tồn tại của MaHoSoCapGCN

CREATE PROCEDURE [dbo].[spSelectMaHoSoCapGCN]
@TrangThai int=NULL,
@MaHoSoCapGCN bigint=NULL
AS
 BEGIN
  IF(@TrangThai=0)
    BEGIN
      SELECT tblThuaDatCapGCN.MaHoSoCapGCN
      FROM tblThuaDatCapGCN
      INNER JOIN tblHoSoCapGCN ON tblHoSoCapGCN.MaHoSoCapGCN =tblThuaDatCapGCN.MaHoSoCapGCN
      WHERE tblHoSoCapGCN.MaHoSoCapGCN=@MaHoSoCapGCN
    END
  IF (@TrangThai=1)
    BEGIN
      SELECT tblHoSoTiepNhan.MaHoSoCapGCN 
      FROM tblHoSoTiepNhan
      INNER JOIN tblHoSoCapGCN ON tblHoSoCapGCN.MaHoSoCapGCN=tblHoSoTiepNhan.MaHoSoCapGCN
      WHERE tblHoSoCapGCN.MaHoSoCapGCN=@MaHoSoCapGCN
    END
  IF (@TrangThai=2)
    BEGIN
      SELECT tblChuHoSoCapGCN.MaHoSoCapGCN
      FROM tblChuHoSoCapGCN
      INNER JOIN tblHoSoCapGCN ON tblHoSoCapGCN.MaHoSoCapGCN= tblChuHoSoCapGCN.MaHoSoCapGCN
      WHERE tblHoSoCapGCN.MaHoSoCapGCN=@MaHoSoCapGCN
    END
  IF (@TrangThai=3)
    BEGIN
      SELECT tblHoiDongXetDuyet.MaHoSoCapGCN
      FROM tblHoiDongXetDuyet
      INNER JOIN tblHoSoCapGCN ON tblHoSoCapGCN.MaHoSoCapGCN=tblHoiDongXetDuyet.MaHoSoCapGCN
      WHERE tblHoSoCapGCN.MaHoSoCapGCN=@MaHoSoCapGCN
    END
  IF (@TrangThai=4)
    BEGIN
      SELECT tblHoSoThamDinh.MaHoSoCapGCN
      FROM tblHoSoThamDinh 
      INNER JOIN tblHoSoCapGCN ON tblHoSoThamDinh.MaHoSoCapGCN = tblHoSoCapGCN.MaHoSoCapGCN
      WHERE tblHoSoCapGCN.MaHoSoCapGCN=@MaHoSoCapGCN
    END
  IF (@TrangThai=5)
    BEGIN
      SELECT tblHoSoPheDuyet.MaHoSoCapGCN
      FROM tblHoSoPheDuyet
      INNER JOIN tblHoSoCapGCN ON tblHoSoCapGCN.MaHoSoCapGCN=tblHoSoPheDuyet.MaHoSoCapGCN
      WHERE tblHoSoCapGCN.MaHoSoCapGCN=@MaHoSoCapGCN
    END
  IF (@TrangThai=8)
    BEGIN
      SELECT tblHoSoCapGCN.MaHoSoCapGCN 
      FROM tblHoSoCapGCN
      WHERE tblHoSoCapGCN.MaHoSoCapGCN =@MaHoSoCapGCN
    END
  IF (@TrangThai=7)
    BEGIN
      SELECT tblHoSoThamDinh.MaHoSoCapGCN,KetQuaThamDinh
      FROM tblHoSoThamDinh
      INNER JOIN tblHoSoCapGCN ON tblHoSoCapGCN.MaHoSoCapGCN=tblHoSoThamDinh.MaHoSoCapGCN
      WHERE tblHoSoCapGCN.MaHoSoCapGCN=@MaHoSoCapGCN AND tblHoSoThamDinh.KetQuaThamDinh=''1''
    END
 END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InBienBanXetDuyetHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		pham xuan chung
-- Create date: <16/11/2009>
-- Description:	<Lay thogn tin de in bien ban giay chung nhan> (phan in bien ban gia xet duyet ho so cap GCN)
-- =============================================
CREATE PROCEDURE [dbo].[sp_InBienBanXetDuyetHoSoCapGCN] 
	@MaHoSoCapGCN nvarchar (50)
AS
BEGIN
SELECT     dbo.tblHoSoCapGCN.MaHoSoCapGCN, dbo.tblThuaDatCapGCN.ToBanDo, dbo.tblThuaDatCapGCN.SoThua AS ThuaDat, 
                      dbo.tblThuaDatCapGCN.DienTich AS DienTichTuNhien, dbo.tblThuaDatCapGCN.DiaChi AS DiaChiNha, 
                      dbo.tblThuaDatCapGCN.DienTich AS TongDienTich, dbo.tblThuaDatCapGCN.DienTichRieng AS SuDungRieng, 
                      dbo.tblThuaDatCapGCN.DienTichChung AS SuDungChung, dbo.tblThuaDatCapGCN.DienTichKhongCap, 
                      dbo.tblMucDichSuDungDat.ChiTietQuiHoach AS QuiHoachChiTiet, dbo.tblHoSoCapGCN.HoSoKiThuatThamDinh AS LyDoKhongCap
FROM         dbo.tblMucDichSuDungDat RIGHT OUTER JOIN
                      dbo.tblThuaDatCapGCN ON dbo.tblMucDichSuDungDat.MaThuaDatCapGCN = dbo.tblThuaDatCapGCN.MaThuaDatCapGCN RIGHT OUTER JOIN
                      dbo.tblHoSoCapGCN ON dbo.tblThuaDatCapGCN.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN
where tblHoSoCapGCN.MaHoSoCapGCN= @MaHoSoCapGCN
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSoTheoDoiBienDong]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




-- =============================================
-- Author:		Quach Van Phong
-- Create date: <28/4/2010>
-- Description:	Phan in so theo doi bien dong
-- =============================================


CREATE PROCEDURE [dbo].[spSoTheoDoiBienDong]
@Flag int =null,
@NamIn int =null,
@MaDVHC nvarchar(20)=null
AS
 BEGIN 
  IF (@Flag=1)
    BEGIN
     IF (@NamIn=0)
        BEGIN
            SELECT DISTINCT TenNguoiDangKy, DiaChiNguoiDangKy,ThoiDiemDangKy, ToBanDo, SoThua, NoidungSoBienDong,MaDonViHanhChinh
            FROM tblDangKyBienDong
            INNER JOIN tblHoSoCapGCN ON tblHoSoCapGCN.MaHoSoCapGCN = tblDangKyBienDong.MaHoSoCapGCN 
            INNER JOIN tblThuaDatCapGCN ON tblDangKyBienDong.MaHoSoCapGCN = tblThuaDatCapGCN.MaHoSoCapGCN
            INNER JOIN tblTuDienDonViHanhChinh ON tblTuDienDonViHanhChinh.MaXa=tblHoSoCapGCN.MaXa
            WHERE MaDonViHanhChinh=@MaDVHC 
            ORDER BY ThoiDiemDangKy
       END
    ELSE 
       BEGIN
           SELECT DISTINCT TenNguoiDangKy,DiaChiNguoiDangKy,ThoiDiemDangKy,ToBanDo,SoThua,NoiDungSoBienDong,MaDonViHanhChinh
           FROM tblDangKyBienDong
           INNER JOIN tblHoSoCapGCN ON tblHoSoCapGCN.MaHoSoCapGCN = tblDangKyBienDong.MaHoSoCapGCN 
           INNER JOIN tblThuaDatCapGCN ON tblThuaDatCapGCN.MaHoSoCapGCN=tblDangKyBienDong.MaHoSoCapGCN
           INNER JOIN tblTuDienDonViHanhChinh ON tblTuDienDonViHanhChinh.MaXa=tblHoSoCapGCN.MaXa
           WHERE MaDonViHanhChinh=@MaDVHC AND year(ThoiDiemDangKy)=@NamIn
       END
   END
IF (@Flag=2)
   BEGIN
     IF (@NamIn=0)
       BEGIN 
          SELECT DISTINCT ThoiDiemDangKy 
          FROM tblDangKyBienDong 
          ORDER BY ThoiDiemDangKy
       END
    ELSE
       BEGIN
         SELECT DISTINCT ThoiDiemDangKy 
         FROM tblDangKyBienDong 
         WHERE year(ThoiDiemDangKy)=@NamIn
         ORDER BY ThoiDiemDangKy
      END
  END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThuaDatCapGCNByMaThuaDatCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--Ngày tạo gần nhất: 20100206
--Người tạo: Vũ Lê Thành,
--Mục đích: INSERT tblThuaDatCapGCN
CREATE PROC [dbo].[spInsertThuaDatCapGCNByMaThuaDatCapGCN]
		@MaThuaDatCapGCN	BIGINT = NULL
		,@MaHoSoCapGCN	BIGINT = NULL
		,@ToBanDo	NVARCHAR(50) = NULL
		,@SoThua	NVARCHAR(50) = NULL
		,@DiaChi	NVARCHAR(500) = NULL
		,@DienTich	NVARCHAR(50) = NULL
		,@DienTichBangChu	NVARCHAR(500) = NULL
		,@DienTichRieng	NVARCHAR(50) = NULL
		,@DienTichChung	NVARCHAR(50) = NULL
		,@MucDichSuDung	NVARCHAR(50) = NULL
		,@ThoiHanSuDung	NVARCHAR(200) = NULL
		,@NguonGocSuDung NVARCHAR(50) = NULL
		,@DienTichKhongCap	FLOAT = NULL
		,@DienTichKhongCapBangChu	NVARCHAR(200) = NULL
		,@LyDoKhongCap	NVARCHAR(500) = NULL
		,@GhiChu	NVARCHAR(500) = NULL
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	BEGIN
		SET DATEFORMAT DMY
		IF NOT EXISTS (SELECT * FROM tblThuaDatCapGCN
					 WHERE (MaThuaDatCapGCN = @MaThuaDatCapGCN))
			BEGIN
				INSERT INTO tblThuaDatCapGCN
				(
					MaHoSoCapGCN,ToBanDo,SoThua
					,DiaChi,DienTich,DienTichBangChu,DienTichRieng
					,DienTichChung,MucDichSuDung,ThoiHanSuDung,NguonGocSuDung 
					,DienTichKhongCap,DienTichKhongCapBangChu,LyDoKhongCap,GHiChu
				)
				VALUES 
				(CONVERT(BIGINT,@MaHoSoCapGCN),@ToBanDo,@SoThua
					,@DiaChi,CONVERT(FLOAT,@DienTich),@DienTichBangChu
					,CONVERT(FLOAT,@DienTichRieng),CONVERT(FLOAT,@DienTichChung)
					,@MucDichSuDung,@ThoiHanSuDung,@NguonGocSuDung
					,CONVERT(FLOAT,@DienTichKhongCap)
					,@DienTichKhongCapBangChu
					,@LyDoKhongCap,@GhiChu )
			END
		ELSE 
			SET @IsExit = 0
	END
	SELECT @IsExit
	SET NOCOUNT OFF
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectThongBaoHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Pham xuan chung
-- Create date: <14/12/2009>
-- Description:	<lay thong tin ho so de in thong bao cap giay chung nhan>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectThongBaoHoSoCapGCN]
	@MaHoSoCapGCN nvarchar(50)=null
AS
BEGIN
SELECT     dbo.tblThuaDatCapGCN.ToBanDo, dbo.tblThuaDatCapGCN.SoThua AS thuadat, dbo.tblThuaDatCapGCN.DienTich, 
                      dbo.tblThuaDatCapGCN.DiaChi AS diachi, dbo.tblThuaDatCapGCN.DienTichChung AS sudungchung, 
                      dbo.tblThuaDatCapGCN.DienTichRieng AS sudungrieng, CONVERT(nvarchar, dbo.tblTuDienQuyetDinhCapGCN.SoQuyetDinhCapGCN) 
                      AS SoQuyetDinhCapGCN, CONVERT(nvarchar, dbo.tblTuDienQuyetDinhCapGCN.NgayQuyetDinhCapGCN) AS NgayQuyetDinhCapGCN, 
                      dbo.tblThuaDatCapGCN.MaHoSoCapGCN
FROM         dbo.tblThuaDatCapGCN LEFT OUTER JOIN
                      dbo.tblHoSoQuyetDinhCapGCN ON dbo.tblThuaDatCapGCN.MaHoSoCapGCN = dbo.tblHoSoQuyetDinhCapGCN.MaHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblTuDienQuyetDinhCapGCN ON 
                      dbo.tblHoSoQuyetDinhCapGCN.MaQuyetDinhCapGCN = dbo.tblTuDienQuyetDinhCapGCN.MaQuyetDinhCapGCN
WHERE     (dbo.tblThuaDatCapGCN.MaHoSoCapGCN = @MaHoSoCapGCN)
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertHoSoCapGCNChuaCoThongTinKhongGianThuaDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100111
-- Description:	Tạo mới Hồ sơ cấp GCN chưa có thông tin 
-- không gian thửa đất (trên bảng Dữ liệu không gian thửa đất)
-- =============================================
CREATE PROCEDURE [dbo].[spInsertHoSoCapGCNChuaCoThongTinKhongGianThuaDat]
	-- Add the parameters for the stored procedure here
	@MaXa	INT = NULL,
	@ToBanDo NVARCHAR(50) = NULL,
	@SoThua NVARCHAR(200) = NULL,
	@DienTichTuNhien NVARCHAR(50) = NULL,
	@DiaChiThua NVARCHAR (500) = NULL,
	@MaThuaDat NVARCHAR (100) = NULL,
	@MaHoSoCapGCN BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1
    -- Insert statements for procedure here
	BEGIN
		SET  DATEFORMAT DMY
		-- SET @MaHoSoCapGCN =  @@IDENTITY -- SCOPE_IDENTITY()
		IF not exists (SELECT MaXa FROM tblHoSoCapGCN 
			WHERE MaHoSoCapGCN = @MaHoSoCapGCN )
			BEGIN
				BEGIN TRANSACTION TaoHoSo
					INSERT INTO tblHoSoCapGCN(MaXa,TrangThaiHoSoCapGCN)
					VALUES (CONVERT(INT,@MaXa),0)
					SET @MaHoSoCapGCN =  @@IDENTITY
					IF @@ERROR !=0
						BEGIN
							PRINT ''Insert tblHoSoCapGCN error!''
							ROLLBACK TRANSACTION 
						END
					-- Thêm mới vào bảng thửa đất cấp GCN
					INSERT INTO tblThuaDatCapGCN (MaThuaDat,MaHoSoCapGCN,ToBanDo,SoThua,DienTich,DiaChi)
					VALUES (NULL,@MaHoSoCapGCN,@ToBanDo,@SoThua,CONVERT(FLOAT,@DienTichTuNhien),@DiaChiThua)
					IF @@ERROR !=0
						BEGIN
							PRINT ''Insert tblThuaDatCapGCN error!''
							ROLLBACK TRANSACTION 
						END					
					SELECT @MaHoSoCapGCN AS MaHoSoCapGCN
				COMMIT TRANSACTION TaoHoSo
			END
		ELSE 
			SET @IsExit = 0
	END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSoDiaChinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Quach Van Phong
-- Create date: <28/4/2010>
-- Description:	Phan in so dia chinh
-- =============================================
CREATE PROCEDURE [dbo].[spSoDiaChinh]
	@Flag int =null,
	@NamIn int =null,
    @MaDVHC nvarchar (20)=null,
    @MaChu bigint=null,
    @MaHoSoCapGCN bigint=null
AS
BEGIN
	if @Flag=1
		begin
			if (@NamIn=0)
				begin
                   SELECT tblChu.MaChu, tblChu.DoiTuongSDD, tblChu.GioiTinh,tblChu.HoTen , tblChu.NamSinh ,tblChu.SoDinhDanh, tblChu.NgayCap,MaDonViHanhChinh,
                   tblChu.NoiCap,tblChu.DiaChi,tblChu.QuocTich,tblChu.SoHoKhau,tblChu.NgayCapHoKhau,tblChu.NoiCapHoKhau, tblHoSoCapGCN.MaHoSoCapGCN
                   FROM tblChu
				   INNER JOIN tblChuHoSoCapGCN ON tblChuHoSoCapGCN.MaChu = tblChu.MaChu
				   INNER JOIN tblHoSoCapGCN ON tblHoSoCapGCN.MaHoSoCapGCN = tblChuHoSoCapGCN.MaHoSoCapGCN
				   INNER JOIN tblTuDienDonViHanhChinh ON tblTuDienDonViHanhChinh.MaXa=tblHoSoCapGCN.MaXa
                   WHERE MaDonViHanhChinh=@MaDVHC
                   ORDER BY HoTen
				end
			else
				begin
                    SELECT tblChu.MaChu, tblChu.DoiTuongSDD, tblChu.GioiTinh,tblChu.HoTen , tblChu.NamSinh ,tblChu.SoDinhDanh, tblChu.NgayCap,
                   tblChu.NoiCap,tblChu.DiaChi,tblChu.QuocTich,tblChu.SoHoKhau,tblChu.NgayCapHoKhau,tblChu.NoiCapHoKhau, tblHoSoCapGCN.MaHoSoCapGCN
                   FROM tblChu
                   INNER JOIN tblChuHoSoCapGCN ON tblChuHoSoCapGCN.MaChu=tblChu.MaChu
                   INNER JOIN tblHoSoCapGCN ON tblHoSoCapGCN.MaHoSoCapGCN=tblChuHoSoCapGCN.MaHoSoCapGCN
                   INNER JOIN tblTuDienDonViHanhChinh ON tblTuDienDonViHanhChinh.MaXa=tblHoSoCapGCN.MaXa
                   WHERE  MaDonViHanhChinh=@MaDVHC AND year(NgayHoanTatGCN)=@NamIn
                   ORDER BY HoTen
				end
		end
	if @Flag=2
		Begin
			if (@NamIn=0)
				begin
                   SELECT tblHoSoCapGCN.MaHoSoCapGCN, NgayVaoSoCapGCN, SoThua, ToBanDo,SoPhatHanhGCN, SoVaoSoCapGCN,MaDonViHanhChinh
                   FROM tblHoSoCapGCN
                   INNER JOIN tblThuaDatCapGCN ON tblThuaDatCapGCN.MaHoSoCapGCN=tblHoSoCapGCN.MaHoSoCapGCN
                   INNER JOIN tblTuDienDonViHanhChinh ON tblTuDienDonViHanhChinh.MaXa=tblHoSoCapGCN.MaXa
                   INNER JOIN tblChuHoSoCapGCN ON tblChuHoSoCapGCN.MaHoSoCapGCN=tblHoSoCapGCN.MaHoSoCapGCN
                   WHERE MaDonViHanhChinh=@MaDVHC AND MaChu=@MaChu
                   ORDER BY NgayVaoSoCapGCN
				end
			else
				begin
                   SELECT tblHoSoCapGCN.MaHoSoCapGCN, NgayVaoSoCapGCN, SoThua, ToBanDo,SoPhatHanhGCN, SoVaoSoCapGCN,MaDonViHanhChinh
                   FROM tblHoSoCapGCN
                   INNER JOIN tblThuaDatCapGCN ON tblThuaDatCapGCN.MaHoSoCapGCN=tblHoSoCapGCN.MaHoSoCapGCN
                   INNER JOIN tblTuDienDonViHanhChinh ON tblTuDienDonViHanhChinh.MaXa=tblHoSoCapGCN.MaXa
                   INNER JOIN tblChuHoSoCapGCN ON tblChuHoSoCapGCN.MaHoSoCapGCN=tblHoSoCapGCN.MaHoSoCapGCN
                   WHERE MaDonViHanhChinh=@MaDVHC AND MaChu=@MaChu AND year(tblHoSoCapGCN.NgayHoanTatGCN)=@NamIn
                   ORDER BY NgayVaoSoCapGCN
				end
		end
	if @Flag=3
		Begin
			if (@NamIn=0)
				begin
					SELECT DISTINCT tblMucDichSuDungDat.DienTichRieng, tblMucDichSuDungDat.DienTichChung,tblMucDichSuDungDat.KyHieu ,ThoiHan,NguonGocSuDung
                    FROM tblHoSoCapGCN,tblMucDichSuDungDat,tblThuaDatCapGCN
                    WHERE tblThuaDatCapGCN.MaThuaDatCapGCN=tblMucDichSuDungDat.MaThuaDatCapGCN 
                          AND tblHoSoCapGCN.MaHoSoCapGCN=tblThuaDatCapGCN.MaHoSoCapGCN AND tblHoSoCapGCN.MaHoSoCapGCN=@MaHoSoCapGCN
					end
				else
					begin
                    SELECT DISTINCT tblMucDichSuDungDat.DienTichRieng, tblMucDichSuDungDat.DienTichChung,tblMucDichSuDungDat.KyHieu ,ThoiHan,NguonGocSuDung
                    FROM tblHoSoCapGCN,tblMucDichSuDungDat,tblThuaDatCapGCN
                    WHERE tblThuaDatCapGCN.MaThuaDatCapGCN=tblMucDichSuDungDat.MaThuaDatCapGCN AND tblHoSoCapGCN.MaHoSoCapGCN=tblThuaDatCapGCN.MaHoSoCapGCN 
                          AND tblHoSoCapGCN.MaHoSoCapGCN=@MaHoSoCapGCN AND year(tblHoSoCapGCN.NgayHoanTatGCN)=@NamIn
					end
			End
	if @Flag=4
		begin
			if (@NamIn=0)
				begin
					SELECT DISTINCT KyHieu
				    FROM tblHoSoCapGCN,tblMucDichSuDungDat,tblThuaDatCapGCN
                    WHERE tblThuaDatCapGCN.MaThuaDatCapGCN=tblMucDichSuDungDat.MaThuaDatCapGCN 
                          AND tblHoSoCapGCN.MaHoSoCapGCN=tblThuaDatCapGCN.MaHoSoCapGCN AND tblHoSoCapGCN.MaHoSoCapGCN=@MaHoSoCapGCN
				end
			else
				begin
					SELECT DISTINCT KyHieu
				    FROM tblHoSoCapGCN,tblMucDichSuDungDat,tblThuaDatCapGCN
                    WHERE tblThuaDatCapGCN.MaThuaDatCapGCN=tblMucDichSuDungDat.MaThuaDatCapGCN AND tblHoSoCapGCN.MaHoSoCapGCN=tblThuaDatCapGCN.MaHoSoCapGCN
                          AND tblHoSoCapGCN.MaHoSoCapGCN=@MaHoSoCapGCN AND year(tblHoSoCapGCN.NgayHoanTatGCN)=@NamIn
				end
		end
	if @Flag=5
		begin
			SELECT * FROM tblChuHoSoCapGCN
            INNER JOIN tblHoSoCapGCN ON tblHoSoCapGCN.MaHoSoCapGCN=tblChuHoSoCapGCN.MaHoSoCapGCN
            INNER JOIN tblTuDienDonViHanhChinh ON tblTuDienDonViHanhChinh.MaXa=tblHoSoCapGCN.MaXa
            WHERE MaDonViHanhChinh=@MaDVHC
		end


   IF @Flag=6
        BEGIN
            IF(@NamIn=0)
                BEGIN
                   SELECT DISTINCT SoThua,ThoiDiemDangKy,NoidungSoBienDong,tblThuaDatCapGCN.MaHoSoCapGCN,tblDangKyBienDong.MaHoSoCapGCN
                   FROM tblDangKyBienDong
                   INNER JOIN tblThuaDatCapGCN ON tblThuaDatCapGCN.MaHoSoCapGCN=tblDangKyBienDong.MaHoSoCapGCN
                   WHERE tblDangKyBienDong.MaHoSoCapGCN=@MaHoSoCapGCN
               END
           ELSE
               BEGIN
                  SELECT DISTINCT SoThua,ThoiDiemDangKy,NoidungSoBienDong,NgayHoanTatGCN
                  FROM tblDangKyBienDong
                  INNER JOIN tblThuaDatCapGCN ON tblThuaDatCapGCN.MaHoSoCapGCN=tblDangKyBienDong.MaHoSoCapGCN
                  INNER JOIN tblHoSoCapGCN ON tblHoSoCapGCN.MaHoSoCapGCN=tblDangKyBienDong.MaHoSoCapGCN
                  WHERE tblDangKyBienDong.MaHoSoCapGCN=@MaHoSoCapGCN AND year(tblHoSoCapGCN.NgayHoanTatGCN)=@NamIn
               END
        END

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertHoSoCapGCNDaCoThongTinKhongGianThuaDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090910
-- Description:	Tạo mới Hồ sơ cấp GCN đã có thông tin 
-- không gian thửa đất (trên bảng Dữ liệu không gian thửa đất)
-- =============================================
CREATE PROCEDURE [dbo].[spInsertHoSoCapGCNDaCoThongTinKhongGianThuaDat]
	-- Add the parameters for the stored procedure here
	@MaXa	INT = NULL,
	@ToBanDo NVARCHAR(50) = NULL,
	@SoThua NVARCHAR(200) = NULL,
	@DienTichTuNhien NVARCHAR(50) = NULL,
	@DiaChiThua NVARCHAR (500) = NULL,
	@MaThuaDat NVARCHAR (100) = NULL,
	@MaHoSoCapGCN BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1
    -- Insert statements for procedure here
	BEGIN
		SET  DATEFORMAT DMY
		-- SET @MaHoSoCapGCN =  @@IDENTITY -- SCOPE_IDENTITY()
		IF not exists (SELECT MaXa FROM tblHoSoCapGCN 
			WHERE MaHoSoCapGCN = @MaHoSoCapGCN )
			BEGIN
				BEGIN TRANSACTION TaoHoSo
					-- Thêm mới vào bảng Hồ sơ cấp GCN
					INSERT INTO tblHoSoCapGCN(MaXa,TrangThaiHoSoCapGCN)
					VALUES (CONVERT(INT,@MaXa),0)
					SET @MaHoSoCapGCN =  @@IDENTITY
					IF @@ERROR !=0
						BEGIN
							PRINT ''Insert tblHoSoCapGCN error!''
							ROLLBACK TRANSACTION 
						END
					-- Thêm mới vào bảng thửa đất cấp GCN
					INSERT INTO tblThuaDatCapGCN (MaThuaDat,MaHoSoCapGCN,ToBanDo,SoThua,DienTich,DiaChi)
					VALUES (@MaThuaDat,@MaHoSoCapGCN,@ToBanDo,@SoThua,CONVERT(FLOAT,@DienTichTuNhien),@DiaChiThua)
					IF @@ERROR !=0
						BEGIN
							PRINT ''Insert tblThuaDatCapGCN error!''
							ROLLBACK TRANSACTION 
						END					
					SELECT @MaHoSoCapGCN AS MaHoSoCapGCN
				COMMIT TRANSACTION TaoHoSo
			END
		ELSE 
			SET @IsExit = 0
	END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinNhaOByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE procedure [dbo].[spSelectThongTinNhaOByMaHoSoCapGCN](@MaHoSoCapGCN bigint)
as
SELECT     dbo.tblNhaO.SoTang, dbo.tblHoSoPheDuyet.HoTenCanBoPheDuyet, dbo.tblNhaO.KetCauNha, dbo.tblNhaO.NamXayDung, 
                      dbo.tblThuaDatCapGCN.DiaChi, dbo.tblNhaO.CapHangNha, dbo.tblNhaO.LoaiNha, dbo.tblNhaO.DienTichSanXayDung AS DienTichXayDung
FROM         dbo.tblThuaDatCapGCN INNER JOIN
                      dbo.tblChuHoSoCapGCN ON dbo.tblThuaDatCapGCN.MaHoSoCapGCN = dbo.tblChuHoSoCapGCN.MaHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblNhaO ON dbo.tblChuHoSoCapGCN.MaHoSoCapGCN = dbo.tblNhaO.MaHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblHoSoPheDuyet ON dbo.tblChuHoSoCapGCN.MaHoSoCapGCN = dbo.tblHoSoPheDuyet.MaHoSoCapGCN
WHERE     (dbo.tblChuHoSoCapGCN.MaHoSoCapGCN = @MaHoSoCapGCN)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTuDienChucNang]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Created:03/20/2009
--Author:Pham Xuan Chung
--Thuc hien mot so chuc nang su dung trong control phan quyen
CREATE procedure [dbo].[spTuDienChucNang]
@flag int,
@IDGroup as int
 as 
if @flag=0 
	begin
		Select * from tbltudienchucnang where @IDGroup=idGroup order by iMaChucNang
	end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProcLayChucNangTheoNguoiDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProcLayChucNangTheoNguoiDung]
	-- Add the parameters for the stored procedure here
	@UserName NVarChar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

    -- Insert statements for procedure here
	SELECT  DISTINCT C.[nMoTaChucNang]
	FROM [georgetown].[dbo].[tblUsers] A, [georgetown].[dbo].tblUserChucNang B, [georgetown].[dbo].[tblTuDienChucNang] C
	WHERE A.[TenDangNhap] = @UserName
		AND A.[MaUsers] = B.[MaUsers]
		AND B.[iMaChucNang] = C.[iMaChucNang]
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectMaCoQuanThucHienChinhLy]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spSelectMaCoQuanThucHienChinhLy]
    @KyHieu NVARCHAR (500)= NULL,
	@MoTa NVARCHAR (500) = NULL,
	@Nhom NVARCHAR (100) = NULL
AS
SELECT * FROM tblTuDienCoQuanChinhLyGCN ORDER BY KyHieu ASC' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteMaCoQuanThucHien]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spDeleteMaCoQuanThucHien]
    @KyHieu nvarchar(50),
    @MoTa NVARCHAR (500) = NULL,
	@Nhom NVARCHAR (100) = NULL
AS 
SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	DELETE FROM tblTuDienCoQuanChinhLyGCN
	WHERE KyHieu = @KyHieu
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTuDienCoQuanChinhLyHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 29/4/2009
-- Description:	lay ra danh sach co quan chinh ly ho so cap GCN
-- =============================================
CREATE proc [dbo].[spTuDienCoQuanChinhLyHoSoCapGCN]
	@flag int,
	@KyHieu nvarchar(50)
AS
BEGIN
	if @flag=0 
		begin   
			SELECT KyHieu,MoTa from tblTuDienCoQuanChinhLyGCN
		end
	if @flag=1
		begin   
			SELECT MoTa from tblTuDienCoQuanChinhLyGCN where KyHieu=@KyHieu
		end
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertMaCoQuanThucHien]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spInsertMaCoQuanThucHien]
@KyHieu nvarchar(50)=null,
@MoTa nvarchar(500)=null,
@Nhom NVARCHAR (100)=null
AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	IF NOT EXISTS(SELECT * FROM tblTuDienCoQuanChinhLyGCN
		WHERE KyHieu =@KyHieu)
		INSERT INTO tblTuDienCoQuanChinhLyGCN( KyHieu ,MoTa )
		VALUES (@KyHieu,@MoTa )
	ELSE 
		SET @IsExit = 0
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateMaCoQuanThucHien]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spUpdateMaCoQuanThucHien]
    @KyHieu nvarchar(50)=null,
    @MoTa nvarchar(500)=null,
    @Nhom NVARCHAR (100)=null
AS 
    SET NOCOUNT ON
    DECLARE @IsExit INT
    SET @IsExit = 1

    UPDATE tblTuDienCoQuanChinhLyGCN
    SET KyHieu=@KyHieu ,MoTa=@MoTa 
    WHERE KyHieu = @KyHieu

    SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBangMa]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Cập nhật bảng tblBangMa ( Tu dien Muc dich su dung dat)
CREATE PROC [dbo].[spBangMa]
	@Bang tinyint,
	@flag tinyint,
	@KyHieu nvarchar (500),
	@MoTa nvarchar (500),
	@Nhom nvarchar (100)

as 
	set nocount on
	declare @IsExit int
	set @IsExit = 1
	-- Bang ma Muc dich su dung
	if @Bang = 0
		begin
			if @flag = 0 
				--Truong hop hien thi Muc dich su dung
				select * from tblTuDienMucDichSDD
				where 1 = 1
				and (case @KyHieu
					when '''' then @KyHieu  else KyHieu end) = @KyHieu
				and (case @MoTa 
					when '''' then @MoTa else MoTa end) = @MoTa
			else 
				begin
				--Truong hop them Muc dich su dung
				if @flag = 1
					if not exists (select * from tblTuDienMucDichSDD
						where KyHieu = @KyHieu)
						insert into tblTuDienMucDichSDD( KyHieu ,MoTa )
						 values (@KyHieu,@MoTa )
					else 
						set @IsExit = 0
		
				--Truong hop cap nhat muc dich su dung
				if @flag  = 2
					update tblTuDienMucDichSDD
					set KyHieu=@KyHieu ,MoTa=@MoTa 
					where KyHieu = @KyHieu
				--Truong hop xoa muc dich su dung
				if @flag = 3
					delete from tblTuDienMucDichSDD
					where KyHieu = @KyHieu
		--			set nocount off 
				select @IsExit
			end
		end
	--Bang ma nguon goc su dung
	else if @Bang = 1
		begin
			if @flag = 0 
				--Truong hop View
				select * from tblTuDienNguonGocSDD
				where 1 = 1
				and (case @KyHieu
					when '''' then @KyHieu  else KyHieu end) = @KyHieu
				and (case @MoTa 
					when '''' then @MoTa else MoTa end) = @MoTa
			else 
				begin
				--Truong hop them Bang Ma
				if @flag = 1
					if not exists (select * from tblTuDienNguonGocSDD
						where KyHieu = @KyHieu)
						insert into tblTuDienNguonGocSDD( KyHieu ,MoTa )
						 values (@KyHieu,@MoTa )
					else 
						set @IsExit = 0
		
				--Truong hop cap nhat Bang Ma
				if @flag  = 2
					update tblTuDienNguonGocSDD
					set KyHieu=@KyHieu ,MoTa=@MoTa 
					where KyHieu = @KyHieu
				--Truong hop xoa Ma
				if @flag = 3
					delete from tblTuDienNguonGocSDD
					where KyHieu = @KyHieu
		--			set nocount off 
				select @IsExit
			end
		end
	-- Bang ma doi tuong su dung
	else if @Bang = 2
		begin
			if @flag = 0 
				--Truong hop View
				select * from tblTuDienDoiTuongSuDungDat
				where 1 = 1
				and (case @KyHieu
					when '''' then @KyHieu  else KyHieu end) = @KyHieu
				and (case @MoTa 
					when '''' then @MoTa else MoTa end) = @MoTa
				and (case @Nhom
					when '''' then @Nhom else Nhom end) = @Nhom
			else 
				begin
				--Truong hop them Bang Ma
				if @flag = 1
					if not exists (select * from tblTuDienDoiTuongSuDungDat
						where KyHieu = @KyHieu)
						insert into tblTuDienDoiTuongSuDungDat( KyHieu ,MoTa,Nhom )
						 values (@KyHieu,@MoTa,@Nhom )
					else 
						set @IsExit = 0
		
				--Truong hop cap nhat Bang Ma
				if @flag  = 2
					update tblTuDienDoiTuongSuDungDat
					set KyHieu=@KyHieu ,MoTa=@MoTa , Nhom = @Nhom
					where KyHieu = @KyHieu
				--Truong hop xoa Ma
				if @flag = 3
					delete from tblTuDienDoiTuongSuDungDat
					where KyHieu = @KyHieu
		--			set nocount off 
				select @IsExit
			end
		end
	-- Bang loai hinh bien dong
	else if @Bang = 3
		begin
			if @flag = 0 
				--Truong hop View
				select * from tblTuDienLoaiHinhBienDong
				where 1 = 1
				and (case @KyHieu
					when '''' then @KyHieu  else KyHieu end) = @KyHieu
				and (case @MoTa 
					when '''' then @MoTa else MoTa end) = @MoTa
				--and (case @Nhom
				--	when '''' then @Nhom else Nhom end) = @Nhom
			else 
				begin
				--Truong hop them Bang Ma
				if @flag = 1
					if not exists (select * from tblTuDienLoaiHinhBienDong
						where KyHieu = @KyHieu)
						insert into tblTuDienLoaiHinhBienDong( KyHieu ,MoTa)--,Nhom )
						 values (@KyHieu,@MoTa)--,@Nhom )
					else 
						set @IsExit = 0
		
				--Truong hop cap nhat Bang Ma
				if @flag  = 2
					update tblTuDienLoaiHinhBienDong
					set KyHieu=@KyHieu ,MoTa=@MoTa -- , Nhom = @Nhom
					where KyHieu = @KyHieu
				--Truong hop xoa Ma
				if @flag = 3
					delete from tblTuDienLoaiHinhBienDong
					where KyHieu = @KyHieu
		--			set nocount off 
				select @IsExit
			end
		end
	--Ma quan ly dat
	else if @Bang = 4
		begin
			if @flag = 0 
				--Truong hop View
				select * from tblTuDienQuanLyDat
				where 1 = 1
				and (case @KyHieu
					when '''' then @KyHieu  else KyHieu end) = @KyHieu
				and (case @MoTa 
					when '''' then @MoTa else MoTa end) = @MoTa
			else 
				begin
				--Truong hop them Bang Ma
				if @flag = 1
					if not exists (select * from tblTuDienQuanLyDat
						where KyHieu = @KyHieu)
						insert into tblTuDienQuanLyDat( KyHieu ,MoTa )
						 values (@KyHieu,@MoTa )
					else 
						set @IsExit = 0
		
				--Truong hop cap nhat Bang Ma
				if @flag  = 2
					update tblTuDienQuanLyDat
					set KyHieu=@KyHieu ,MoTa=@MoTa 
					where KyHieu = @KyHieu
				--Truong hop xoa Ma
				if @flag = 3
					delete from tblTuDienQuanLyDat
					where KyHieu = @KyHieu
		--			set nocount off 
				select @IsExit
			end
		end

	else if @Bang = 5
		begin
			if @flag = 0 
				--Truong hop View
				select * from tblTuDienCoQuanChinhLyGCN
				where 1 = 1
				and (case @KyHieu
					when '''' then @KyHieu  else KyHieu end) = @KyHieu
				and (case @MoTa 
					when '''' then @MoTa else MoTa end) = @MoTa
			else 
				begin
				--Truong hop them Bang Ma
				if @flag = 1
					if not exists (select * from tblTuDienCoQuanChinhLyGCN
						where KyHieu = @KyHieu)
						insert into tblTuDienCoQuanChinhLyGCN( KyHieu ,MoTa )
						 values (@KyHieu,@MoTa )
					else 
						set @IsExit = 0
		
				--Truong hop cap nhat Bang Ma
				if @flag  = 2
					update tblTuDienCoQuanChinhLyGCN
					set KyHieu=@KyHieu ,MoTa=@MoTa 
					where KyHieu = @KyHieu
				--Truong hop xoa Ma
				if @flag = 3
					delete from tblTuDienCoQuanChinhLyGCN
					where KyHieu = @KyHieu
		--			set nocount off 
				select @IsExit
			end
		end
	--Tu dien nghia vu tai chinh
	else if @Bang = 6
		begin
			if @flag = 0 
				--Truong hop View
				select * from tblTuDienNghiaVuTaiChinh
				where 1 = 1
				and (case @KyHieu
					when '''' then @KyHieu  else KyHieu end) = @KyHieu
				and (case @MoTa 
					when '''' then @MoTa else MoTa end) = @MoTa
--				and (case @Nhom 
--					when '''' then @Nhom else Nhom end) = @Nhom
			else 
				begin
				--Truong hop them Bang Ma
				if @flag = 1
					if not exists (select * from tblTuDienNghiaVuTaiChinh
						where KyHieu = @KyHieu)
						insert into tblTuDienNghiaVuTaiChinh( KyHieu ,MoTa)--, Nhom )
						 values (@KyHieu,@MoTa)--, @Nhom )
					else 
						set @IsExit = 0
		
				--Truong hop cap nhat Bang Ma
				if @flag  = 2
					update tblTuDienNghiaVuTaiChinh
					set KyHieu=@KyHieu ,MoTa=@MoTa--, Nhom = @Nhom 
					where KyHieu = @KyHieu
				--Truong hop xoa Ma
				if @flag = 3
					delete from tblTuDienNghiaVuTaiChinh
					where KyHieu = @KyHieu
		--			set nocount off 
				select @IsExit
			end
		end



	set nocount off' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChuHoSoDangKyCapGCNTCDNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100202
-- Description:	Lựa chọn Chủ Hồ sơ đăng ký cấp GCN (Trong bảng tblChu và 
-- bảng tblChuHoSoCapGCN) thuộc đối tượng Tổ chức, doanh nghiệp theo 
-- Mã hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectChuHoSoDangKyCapGCNTCDNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT  = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT 
		DISTINCT (C.MaChu),
		DoiTuongSDD,
		KyHieu,
		HoTen,	
		SoDinhDanh,	
		NgayCap,	
		NoiCap,	
		DiaChi,	
		DaChet,
		Dat,
		NhaO,
		CongTrinhXayDung,
		RungCay,
		CayLauNam
	FROM tblChu AS C
	INNER JOIN tblTuDienDoiTuongSuDungDat AS TD ON C.DoiTuongSDD = TD.KyHieu
	INNER JOIN tblChuHoSoCapGCN AS CHS ON CHS.MaChu = C.MaChu
	LEFT JOIN tblChuDeNghiCapGCN AS CDNC ON (CDNC.MaChu = CHS.MaChu)
	WHERE  1 = 1
	AND (TD.Nhom = 1)
	AND (@MaHoSoCapGCN = CHS.MaHoSoCapGCN)
	AND NOT EXISTS ( SELECT * FROM tblChuDeNghiCapGCN
					WHERE CDNC.MaHoSoCapGCN = @MaHoSoCapGCN )
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChuHoSoDangKyCapGCNCQNNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:	Vũ Lê Thành
-- Create date: 20100202
-- Description:	Lựa chọn Chủ Hồ sơ đăng ký cấp GCN(Trong bảng tblChuHoSoCapGCN),
-- thuộc đối tượng CƠ QUAN NHÀ NƯỚC theo Mã hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectChuHoSoDangKyCapGCNCQNNByMaHoSoCapGCN]
	@MaHoSoCapGCN BIGINT  = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT DISTINCT (C.MaChu),
		CHS.MaHoSoCapGCN
		,DoiTuongSDD,KyHieu,QuanHe,	
		HoTen,DiaChi,NamSinh,SoDinhDanh,	
		NgayCap,NoiCap,SoHoKhau,NgayCapHoKhau,	
		NoiCapHoKhau,GioiTinh,	QuocTich	
		,Dat,NhaO,CongTrinhXayDung,RungCay
		,CayLauNam,	DaChet
	FROM tblChu AS C
	INNER JOIN tblTuDienDoiTuongSuDungDat AS TD ON C.DoiTuongSDD = TD.KyHieu
	INNER JOIN tblChuHoSoCapGCN AS CHS ON CHS.MaChu = C.MaChu
	LEFT JOIN tblChuDeNghiCapGCN AS CDNC ON (CDNC.MaChu = CHS.MaChu)
	WHERE (TD.Nhom = 2)
	AND (@MaHoSoCapGCN = CHS.MaHoSoCapGCN )
	AND NOT EXISTS ( SELECT * FROM tblChuDeNghiCapGCN
					WHERE CDNC.MaHoSoCapGCN = @MaHoSoCapGCN )
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChuHoSoDangKyCapGCNGDCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100202
-- Description:	Lựa chọn Chủ Hồ sơ đăng ký cấp GCN bởi Mã hồ sơ cấp GCN,
-- theo các tiêu trí tìm kiếm
-- =============================================
CREATE PROCEDURE [dbo].[spSelectChuHoSoDangKyCapGCNGDCNByMaHoSoCapGCN]
	@MaHoSoCapGCN BIGINT  = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT DISTINCT (C.MaChu),
		CHS.MaHoSoCapGCN
		,DoiTuongSDD,KyHieu,QuanHe,	
		HoTen,DiaChi,NamSinh,SoDinhDanh,	
		NgayCap,NoiCap,SoHoKhau,NgayCapHoKhau,	
		NoiCapHoKhau,GioiTinh,	QuocTich	
		,Dat,NhaO,CongTrinhXayDung,RungCay
		,CayLauNam,	DaChet
	FROM tblChu AS C
	INNER JOIN tblTuDienDoiTuongSuDungDat AS TD ON C.DoiTuongSDD = TD.KyHieu
	INNER JOIN tblChuHoSoCapGCN AS CHS ON CHS.MaChu = C.MaChu
	LEFT JOIN tblChuDeNghiCapGCN AS CDNC ON (CDNC.MaChu = CHS.MaChu)
	WHERE  1 = 1
	AND (TD.Nhom = 0)
	AND (@MaHoSoCapGCN = CHS.MaHoSoCapGCN )
	AND NOT EXISTS ( SELECT * FROM tblChuDeNghiCapGCN
					WHERE CDNC.MaHoSoCapGCN = @MaHoSoCapGCN )
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienDoiTuongSuDungDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Cập nhật bảng từ điển ĐỐI TƯỢNG SỬ DỤNG ĐẤT
CREATE PROC [dbo].[spUpdateTuDienDoiTuongSuDungDat]
	@KyHieu NVARCHAR (500) = null ,
	@MoTa NVARCHAR (500) = null,
	@Nhom NVARCHAR (100) = null

AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	UPDATE tblTuDienDoiTuongSuDungDat
	SET KyHieu=@KyHieu ,MoTa=@MoTa 
	WHERE KyHieu = @KyHieu

	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spChu]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Hiển thị thông tin Chủ sử dụng của một
--hồ sơ cấp GCN

CREATE PROCEDURE [dbo].[spChu]
	@MaHoSoCapGCN bigint
AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	BEGIN
		SELECT  DISTINCT   Chu.MaChu , TuDien.Nhom,DoiTuongSDD ,QuanHe
			 ,GioiTinh ,HoTen ,NamSinh,SoDinhDanh ,NgayCap,NoiCap
			 ,DiaChi ,QuocTich,SoHoKhau ,NgayCapHoKhau ,NoiCapHoKhau
			,ChuHoSo.MaHoSoCapGCN,DaChet
		FROM tblChu AS Chu
		-- Liên kết với bảng Từ điển đối tượng Chủ sử dụng đất
		LEFT  JOIN tblTuDienDoiTuongSuDungDat AS TuDien ON (Chu.DoiTuongSDD = TuDien.KyHieu)
		-- Liên kết với bảng Chủ hồ sơ cấp GCN
		LEFT  JOIN tblChuHoSoCapGCN AS ChuHoSo ON (Chu.MaChu = ChuHoSo.MaChu)
		WHERE ChuHoSo.MaHoSoCapGCN = @MaHoSoCapGCN
	END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChuHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: <12/11/2009>
-- Date modified: 20100402
-- Description:	Nhận thông tin Chủ hồ sơ cấp GCN
-- In ra Hồ sơ kỹ thuật
-- Cần xem lại Store Proceduren vì đã có Store Procedure 
-- spSelectChuHoSoCapGCNByMaHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectChuHoSoCapGCN] 
	@MaHoSoCapGCN nvarchar(50)=null
AS
BEGIN
	SELECT   DISTINCT dbo.tblChuDeNghiCapGCN.MaChuDeNghiCapGCN, dbo.tblTuDienDoiTuongSuDungDat.Nhom, dbo.tblChu.QuanHe
		,dbo.tblChu.HoTen, dbo.tblChu.GioiTinh, dbo.tblChu.NamSinh
		,dbo.tblChu.SoDinhDanh , dbo.tblChu.NgayCap, dbo.tblChu.NoiCap
		,dbo.tblChu.DiaChi	, dbo.tblChu.QuocTich, dbo.tblChu.SoHoKhau
		,dbo.tblChu.NgayCapHoKhau	, dbo.tblChu.NoiCapHoKhau
	FROM   dbo.tblChu 
		 INNER JOIN dbo.tblChuDeNghiCapGCN ON dbo.tblChu.MaChu = dbo.tblChuDeNghiCapGCN.MaChu
		 INNER JOIN dbo.tblTuDienDoiTuongSuDungDat ON dbo.tblTuDienDoiTuongSuDungDat.KyHieu = dbo.tblChu.DoiTuongSDD
	WHERE     (dbo.tblChuDeNghiCapGCN.MaHoSoCapGCN = @MaHoSoCapGCN)
	ORDER BY  dbo.tblChuDeNghiCapGCN.MaChuDeNghiCapGCN ASC
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChuHoSoCapGCNGDCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100201
-- Description:	Lựa chọn Chủ Hồ sơ cấp GCN bởi Mã hồ sơ cấp GCN,
-- theo các tiêu trí tìm kiếm
-- =============================================
CREATE PROCEDURE [dbo].[spSelectChuHoSoCapGCNGDCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT  = NULL,
	@MaChu BIGINT = null,
	@QuanHe nvarchar (50) = null ,	
	@GioiTinh nvarchar(50)= null ,
	@HoTen nvarchar (50)= null ,	
	@NamSinh nvarchar(50)= null ,	
	@DiaChi nvarchar (200)= null ,	

	@QuocTich nvarchar (100)= null ,	
	@SoDinhDanh nvarchar (50)= null ,	
	@NgayCap nvarchar(50)= null ,	
	@NoiCap nvarchar (200)= null ,	

	@QuocTich2 nvarchar (100)= null ,	
	@SoDinhDanh2 nvarchar (50)= null ,	
	@NgayCap2 nvarchar(50)= null ,	
	@NoiCap2 nvarchar (200)= null ,	

	@SoHoKhau nvarchar (50)= null ,	
	@NgayCapHoKhau nvarchar(50)= null ,	
	@NoiCapHoKhau nvarchar (200)= null 
	,@Dat NVARCHAR(50) = NULL
	,@NhaO NVARCHAR(50) = NULL
	,@CongTrinhXayDung NVARCHAR(50) = NULL
	,@RungCay NVARCHAR(50) = NULL
	,@CayLauNam NVARCHAR(50) = NULL
	,@DaChet nvarchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT 
		C.MaChu,DoiTuongSDD,KyHieu,QuanHe,	
		HoTen,DiaChi,NamSinh
		,QuocTich,SoDinhDanh,NgayCap,NoiCap
		,SoHoKhau,NgayCapHoKhau,	
		NoiCapHoKhau,GioiTinh
		,Dat,NhaO,CongTrinhXayDung,RungCay
		,CayLauNam,	DaChet
		,QuocTich2,SoDinhDanh2,NgayCap2,NoiCap2
	FROM tblChu AS C
	INNER JOIN tblTuDienDoiTuongSuDungDat AS TD ON C.DoiTuongSDD = TD.KyHieu
	INNER JOIN tblChuHoSoCapGCN AS CHS ON CHS.MaChu = C.MaChu
	WHERE  1 = 1
	AND (TD.Nhom = 0)
	AND (@MaHoSoCapGCN = CHS.MaHoSoCapGCN )
	ORDER BY CHS.MaChu ASC

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChuHoSoCapGCNCQNNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:	Vũ Lê Thành
-- Create date: 20100201
-- Description:	Lựa chọn Chủ Hồ sơ cấp GCN(Trong bảng tblChuHoSoCapGCN),
-- thuộc đối tượng CƠ QUAN NHÀ NƯỚC theo Mã hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectChuHoSoCapGCNCQNNByMaHoSoCapGCN]
	@MaHoSoCapGCN BIGINT  = NULL
	,@MaChu BIGINT = NULL
	,@DoiTuongSDD NVARCHAR(100) = NULL
	,@HoTen NVARCHAR(200) = NULL
	,@DiaChi NVARCHAR(200) = NULL
	,@Dat NVARCHAR(50) = NULL
	,@NhaO NVARCHAR(50) = NULL
	,@CongTrinhXayDung NVARCHAR(50) = NULL
	,@RungCay NVARCHAR(50) = NULL
	,@CayLauNam NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT 
	CHS.MaHoSoCapGCN
	,C.MaChu,DoiTuongSDD,KyHieu,HoTen,DiaChi
	,Dat,NhaO,CongTrinhXayDung,RungCay
	,CayLauNam
	FROM tblChu AS C
	INNER JOIN tblTuDienDoiTuongSuDungDat AS TD ON C.DoiTuongSDD = TD.KyHieu
	INNER JOIN tblChuHoSoCapGCN AS CHS ON CHS.MaChu = C.MaChu
	WHERE (TD.Nhom = 2)
	AND (@MaHoSoCapGCN = CHS.MaHoSoCapGCN )
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChuHoSoCapGCNTCDNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100201
-- Description:	Lựa chọn Chủ Hồ sơ cấp GCN (Trong bảng tblChu và 
-- bảng tblChuHoSoCapGCN) thuộc đối tượng Tổ chức, doanh nghiệp theo 
-- Mã hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectChuHoSoCapGCNTCDNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT  = NULL,
	@MaChu BIGINT = NULL,
	--Những biến sau có thể không cần thiết
	@DoiTuongSDD nvarchar (10) = null,
	@HoTen nvarchar (50)= null ,	
	@SoDinhDanh nvarchar (50)= null ,	
	@NgayCap nvarchar(50)= null ,	
	@NoiCap nvarchar (200)= null ,	
	@DiaChi nvarchar (200)= null 
	,@Dat NVARCHAR(50) = NULL
	,@NhaO NVARCHAR(50) = NULL
	,@CongTrinhXayDung NVARCHAR(50) = NULL
	,@RungCay NVARCHAR(50) = NULL
	,@CayLauNam NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT 
		CHS.MaHoSoCapGCN,
		C.MaChu,
		DoiTuongSDD,
		KyHieu,
		HoTen,	
		SoDinhDanh,	
		NgayCap,	
		NoiCap,	
		DiaChi,	
		Dat,
		NhaO,
		CongTrinhXayDung,
		RungCay,
		CayLauNam
	FROM tblChu AS C
	INNER JOIN tblTuDienDoiTuongSuDungDat AS TD ON C.DoiTuongSDD = TD.KyHieu 
	INNER JOIN tblChuHoSoCapGCN AS CHS ON CHS.MaChu = C.MaChu
	WHERE (TD.Nhom = 1)
	AND	(@MaHoSoCapGCN = CHS.MaHoSoCapGCN )
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectInPhieuChuSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: <12/11/2009>
-- Description:	<Lay thong tin chu su dung> (Phan in phieu quyet dinh)
-- =============================================
create PROCEDURE [dbo].[sp_SelectInPhieuChuSuDung] 
	@MaHoSoCapGCN nvarchar(50)=null
AS
BEGIN
SELECT     dbo.tblTuDienDoiTuongSuDungDat.Nhom, dbo.tblChu.HoTen, dbo.tblChu.GioiTinh, dbo.tblChu.NamSinh, dbo.tblChu.SoDinhDanh, dbo.tblChu.NgayCap, 
                      dbo.tblChu.NoiCap, dbo.tblChu.DiaChi, dbo.tblChu.QuocTich, dbo.tblChu.SoHoKhau, dbo.tblChu.NgayCapHoKhau, dbo.tblChu.NoiCapHoKhau
FROM         dbo.tblChuHoSoCapGCN INNER JOIN
                      dbo.tblTuDienDoiTuongSuDungDat INNER JOIN
                      dbo.tblChu ON dbo.tblTuDienDoiTuongSuDungDat.KyHieu = dbo.tblChu.DoiTuongSDD ON dbo.tblChuHoSoCapGCN.MaChu = dbo.tblChu.MaChu
where tblChuHoSoCapGCN.MaHoSoCapGCN=@MaHoSoCapGCN ORDER BY Nhom
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienDoiTuongSuDungDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: THÊM ĐỐI TƯỢNG SỬ DỤNG ĐẤT vào bảng từ điển
CREATE PROC [dbo].[spInsertTuDienDoiTuongSuDungDat]
	@KyHieu NVARCHAR (500) = null,
	@MoTa NVARCHAR (500) = null,
	@Nhom NVARCHAR (100) = null

AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	IF NOT EXISTS(
		SELECT * FROM tblTuDienDoiTuongSuDungDat
		WHERE KyHieu = @KyHieu)
		INSERT INTO tblTuDienDoiTuongSuDungDat( KyHieu ,MoTa, Nhom )
		VALUES (@KyHieu,@MoTa,@Nhom )
	ELSE 
		SET @IsExit = 0
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTraCuuChuByCQNN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:	Vũ Lê Thành
-- Create date: 20100315
-- Description:	Lựa chọn Chủ sử dụng đất (Trong bảng tblChu),
-- thuộc đối tượng CƠ QUAN NHÀ NƯỚC theo các tiêu trí tìm kiếm
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTraCuuChuByCQNN]
	@HoTen nvarchar (50)= NULL
	,@DiaChi nvarchar (200)= NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT 
	MaChu
--	,DoiTuongSDD
--	,KyHieu
	,HoTen
	,DiaChi
--	,DaChet
	FROM tblChu AS a
	INNER JOIN tblTuDienDoiTuongSuDungDat AS b
	ON a.DoiTuongSDD = b.KyHieu
	WHERE  1 = 1
	-- Xác định đối tượng Tìm kiểm là Chủ 
	-- thuộc nhóm CƠ QUAN NHÀ NƯỚC (Nhóm 2)
	AND (b.Nhom = 2)
	AND ( @HoTen is null or ISNULL(HoTen,'''')	LIKE ''%''+@HoTen +''%'')
	AND (@DiaChi is null or ISNULL(DiaChi,'''')	LIKE ''%''+@DiaChi +''%'')

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTraCuuChuByTCDN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100315
-- Description:	Lựa chọn Chủ (Trong bảng tblChu),
-- thuộc đối tượng Tổ chức, doanh nghiệp theo các tiêu trí tìm kiếm
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTraCuuChuByTCDN]
	@HoTen nvarchar (50)= NULL,
	@DiaChi nvarchar (200)= NULL,
	@SoDinhDanh nvarchar(50)=null,
	@NgayCap nvarchar(20)=null,
	@NoiCap nvarchar(200)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
--declare @str nvarchar(max)
--set @str=''SELECT 
--		MaChu,
--		HoTen,	
--		SoDinhDanh,	
--		NgayCap,	
--		NoiCap,	
--		DiaChi
--	From tblChu AS a
--	INNER JOIN tblTuDienDoiTuongSuDungDat AS b
--	ON a.DoiTuongSDD = b.KyHieu
--	WHERE  1 = 1
--	AND (b.Nhom = 1)
--		AND (ISNULL(HoTen,'''''''')	LIKE ''''%''+ @HoTen +''%'''')
--	AND (ISNULL(DiaChi,'''''''')	LIKE ''''%''+ @DiaChi +''%'''')
--	AND (ISNULL(SoDinhDanh,'''''''')	LIKE ''''%''+ @SoDinhDanh +''%'''')
--	AND (ISNULL(NoiCap,'''''''')	LIKE ''''%''+ @NoiCap +''%'''')''
--	if @NgayCap <> '''' 
--	begin
--		set @str = @str + ''AND (ISNULL(NgayCap,'''''''')	= ''''''+ @NgayCap +'''''')''
--	end
--	
--exec (@str)


SELECT MaChu,HoTen,SoDinhDanh,NgayCap,NoiCap,DiaChi
	From tblChu AS a
	INNER JOIN tblTuDienDoiTuongSuDungDat AS b
	ON a.DoiTuongSDD = b.KyHieu
where 
	1 = 1
	AND (b.Nhom = 1)
	and (@hoten is null or ISNULL(a.HoTen,'''') like ''%'' + @HoTen + ''%'' )
		and (@DiaChi is null or ISNULL(a.DiaChi,'''') like ''%'' + @DiaChi + ''%'' )
		and (@SoDinhDanh is null or ISNULL(a.SoDinhDanh,'''') like ''%'' + @SoDinhDanh + ''%'' )
		and (@NoiCap is null or ISNULL(a.NoiCap,'''') like ''%'' + @NoiCap + ''%'' )
		and (@NgayCap is null or ISNULL(a.NgayCap,'''') like ''%'' + @NgayCap + ''%'' )
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTraCuuChuByGDCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100315
-- Description:	Lựa chọn Chủ Trong bảng tblChu),
-- thuộc nhóm Hộ gia đình, cá nhân, theo các tiêu trí tìm kiếm
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTraCuuChuByGDCN]
	@HoTen nvarchar (200)= NULL,
	@DiaChi nvarchar (200)= NULL,
	@SoDinhDanh nvarchar(50)=null,
	@NgayCap nvarchar(20)=null,
	@NoiCap nvarchar(200)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
--declare @str nvarchar(3950)
--set @str=''SELECT MaChu,HoTen,SoDinhDanh,NgayCap,NoiCap,DiaChi
--	From tblChu AS a
--	INNER JOIN tblTuDienDoiTuongSuDungDat AS b
--	ON a.DoiTuongSDD = b.KyHieu
--	WHERE  1 = 1
--	AND (b.Nhom = 0)
--	AND (ISNULL(a.HoTen,'''''''')	LIKE ''''%'' + isnull( @HoTen ,'''') +''%'''')
--	AND (ISNULL(a.DiaChi,'''''''')	LIKE ''''%''+ isnull( @DiaChi ,'''') +''%'''')
--	AND (ISNULL(a.SoDinhDanh,'''''''')	LIKE ''''%''+ isnull(@SoDinhDanh,'''') +''%'''')
--	AND (ISNULL(a.NoiCap,'''''''')	LIKE ''''%''+ isnull(@NoiCap,'''') +''%'''')''
--print @str
--	if @NgayCap <> '''' or @ngayCap is not null
--	begin
--		set @str = @str + ''AND (ISNULL(NgayCap,'''''''')	= ''+ isnull(@NgayCap,'''') +'')''
--	end
--exec (@str)
--print @str

SELECT MaChu,HoTen,SoDinhDanh,NgayCap,NoiCap,DiaChi
	From tblChu AS a
	INNER JOIN tblTuDienDoiTuongSuDungDat AS b
	ON a.DoiTuongSDD = b.KyHieu
where 
	1 = 1
	AND (b.Nhom = 0)
	and (@hoten is null or ISNULL(a.HoTen,'''') like ''%'' + @HoTen + ''%'' )
		and (@DiaChi is null or ISNULL(a.DiaChi,'''') like ''%'' + @DiaChi + ''%'' )
		and (@SoDinhDanh is null or ISNULL(a.SoDinhDanh,'''') like ''%'' + @SoDinhDanh + ''%'' )
		and (@NoiCap is null or ISNULL(a.NoiCap,'''') like ''%'' + @NoiCap + ''%'' )
		and (@NgayCap is null or ISNULL(a.NgayCap,'''') like ''%'' + @NgayCap + ''%'' )

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienDoiTuongSuDungDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Select ĐỐI TƯỢNG SỬ DỤNG ĐẤT
CREATE PROC [dbo].[spSelectTuDienDoiTuongSuDungDat]
	@KyHieu NVARCHAR (500)= NULL,
	@MoTa NVARCHAR (500) = NULL,
	@Nhom NVARCHAR (100) = NULL

AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	BEGIN
		--Trường hợp hiển thị đối tượng sử dụng đất
		SELECT * FROM tblTuDienDoiTuongSuDungDat
		WHERE 1 = 1
		AND (CASE @KyHieu
			WHEN '''' THEN @KyHieu  ELSE KyHieu END) = @KyHieu
		AND (CASE @Nhom
			WHEN '''' THEN @Nhom  ELSE Nhom END) = @Nhom
		ORDER BY KyHieu
	END
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinChuSuDungByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE procedure [dbo].[spSelectThongTinChuSuDungByMaHoSoCapGCN](@MaHoSoCapGCN bigint)
as
SELECT DISTINCT 
                      CASE dbo.tblChu.GioiTinh WHEN 1 THEN ''Ông '' + dbo.tblChu.HoTen WHEN 0 THEN ''Bà '' + dbo.tblChu.HoTen WHEN NULL 
                      THEN  dbo.tblChu.HoTen END AS HoTen, dbo.tblChu.NamSinh, dbo.tblChu.SoDinhDanh, dbo.tblChu.NgayCap, dbo.tblChu.NoiCap, 
                      dbo.tblTuDienDoiTuongSuDungDat.Nhom, dbo.tblChu.DiaChi AS diachinha,(SELECT     dbo.tblTuDienDonViHanhChinh.Ten
                            FROM          dbo.tblHoSoCapGCN LEFT OUTER JOIN
                                                   dbo.tblTuDienDonViHanhChinh ON dbo.tblHoSoCapGCN.MaXa = dbo.tblTuDienDonViHanhChinh.MaXa
                            WHERE      (dbo.tblHoSoCapGCN.MaHoSoCapGCN = @MaHoSoCapGCN)) AS Phuong
FROM         dbo.tblChuHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblChu INNER JOIN
                      dbo.tblTuDienDoiTuongSuDungDat ON dbo.tblChu.DoiTuongSDD = dbo.tblTuDienDoiTuongSuDungDat.KyHieu ON 
                      dbo.tblChuHoSoCapGCN.MaChu = dbo.tblChu.MaChu
WHERE     (dbo.tblChuHoSoCapGCN.MaHoSoCapGCN = @MaHoSoCapGCN)



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienDoiTuongSuDungDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: XÓA ĐỐI TƯỢNG SỬ DỤNG ĐẤT TRONG BẢNG TỪ ĐIỂN
CREATE PROC [dbo].[spDeleteTuDienDoiTuongSuDungDat]
	@KyHieu NVARCHAR (500) = NULL,
	@MoTa NVARCHAR (500) = NULL,
	@Nhom NVARCHAR (100) = NULL

AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	DELETE FROM tblTuDienDoiTuongSuDungDat
	WHERE KyHieu = @KyHieu
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetMaDVHC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		pham xuan chung
-- Create date: 14/04/2009
-- Description:	lay ma don vi hanh chinh ''''su dung trong clsUser
-- =============================================
CREATE PROCEDURE [dbo].[spGetMaDVHC]
AS
BEGIN
	SELECT MaDonViHanhChinh FROM tblTuDienDonViHanhChinh WHERE MaTinh<>0 AND MaHuyen=0 AND MaXa=0
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienDonViHanhChinhByMaXa]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Select Mã xã/Phường theo Mã Đơn vị hành chính
CREATE PROC [dbo].[spSelectTuDienDonViHanhChinhByMaXa]
	@MaDonViHanhChinh INT
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	BEGIN
		--Truong hop hien thi NGHIA VU TAI CHINH su dung
		SELECT MaXa,Ten FROM tblTuDienDonViHanhChinh
		WHERE 1 = 1
		AND (CASE @MaDonViHanhChinh
			WHEN '''' THEN @MaDonViHanhChinh  ELSE MaDonViHanhChinh END) = @MaDonViHanhChinh
	END
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectHuyenTinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Pham xuan chung
-- Create date: <11/11/2009>
-- Description:	<Lay thong tin tinh huyen >(Phan in quyet dinh)
-- =============================================
CREATE PROCEDURE [dbo].[spSelectHuyenTinh]
	@MaDVHC nvarchar(50) =null
AS
BEGIN
--	SELECT     dbo.tblDLieuKGianThuaDat.ToBanDo, dbo.tblDLieuKGianThuaDat.SoThua, a.Ten ,
--(SELECT distinct ten from   tblTuDienDonViHanhChinh where MaTinh =
--	(select distinct MaTinh from tblTuDienDonViHanhChinh where tblTuDienDonViHanhChinh.MaDonViHanhChinh =@MaDVHC) and mahuyen=0 and maxa=0) as TenTinh , 
--(SELECT distinct ten from   tblTuDienDonViHanhChinh where MaHuyen =
--	(select distinct MaHuyen from tblTuDienDonViHanhChinh where tblTuDienDonViHanhChinh.MaDonViHanhChinh =@MaDVHC) and maxa=0) as TenHuyen
--FROM         dbo.tblDLieuKGianThuaDat INNER JOIN  dbo.tblTuDienDonViHanhChinh AS a ON dbo.tblDLieuKGianThuaDat.MaDonViHanhChinh = a.MaDonViHanhChinh
-- where a.MaDonViHanhChinh=@MaDVHC
	SELECT      a.Ten ,
(SELECT distinct ten from   tblTuDienDonViHanhChinh where MaTinh =(select distinct MaTinh from tblTuDienDonViHanhChinh where tblTuDienDonViHanhChinh.MaDonViHanhChinh =@MaDVHC) and mahuyen=0 ) as TenTinh , 
(SELECT distinct ten from   tblTuDienDonViHanhChinh where MaHuyen =(select distinct MaHuyen from tblTuDienDonViHanhChinh where tblTuDienDonViHanhChinh.MaDonViHanhChinh =@MaDVHC) and maxa=0) as TenHuyen
FROM         dbo.tblTuDienDonViHanhChinh AS a  where a.MaDonViHanhChinh=@MaDVHC

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_LayDonViCon]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[proc_LayDonViCon] 
@MaDVHC int
As 
Begin
Declare @MaTinh int 
Declare @MaHuyen int
Declare @MaXa int 
	Select @Matinh=matinh, @MaHuyen=mahuyen,@MaXa=maxa from tblTuDienDonViHanhChinh where MaDonViHanhChinh=@MaDVHC
	if @MaTinh<>0 and @mahuyen=0 and @maxa=0 
		begin
			select DISTINCT * from tbltudiendonvihanhchinh where @matinh=matinh and mahuyen<>0 and maxa=0
			ORDER BY Ten
		end
	else if @matinh<>0 and @mahuyen<>0 and @maxa=0
		begin
			select DISTINCT * from tbltudiendonvihanhchinh where @matinh=matinh and mahuyen=@mahuyen and maxa<>0
			ORDER BY Ten
		end
	else if @matinh<>0 and @mahuyen<>0 and @maxa<>0 
		begin
			select DISTINCT * from tbltudiendonvihanhchinh where @matinh=matinh and @mahuyen=mahuyen and maxa=@maxa
			ORDER BY Ten
		end
End


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Test]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[proc_Test]
@MaDVHC1 int,
@MaDVHC2 int,
@Test bit output
As 
Begin
	declare @tam int
	declare @tam1 int
	Declare @MaTinh int 
	Declare @MaHuyen int
	Declare @MaXa int 
	Select @Matinh=matinh, @MaHuyen=mahuyen,@MaXa=maxa from tblTuDienDonViHanhChinh where MaDonViHanhChinh=@MaDVHC2
	if @MaTinh<>0 and @mahuyen=0 and @maxa=0 
		begin
		select @tam=madonvihanhchinh from tbltudiendonvihanhchinh where @matinh=matinh and mahuyen=0 and maxa=0
		end
	else if @matinh<>0 and @mahuyen<>0 and @maxa=0
		begin
		select  @tam=madonvihanhchinh from tbltudiendonvihanhchinh where @matinh=matinh and mahuyen=0 
		end
	else if @matinh<>0 and @mahuyen<>0 and @maxa<>0 
		begin
		select  @tam=madonvihanhchinh  from tbltudiendonvihanhchinh where @matinh=matinh and @mahuyen=mahuyen and maxa=0
		end
	if @tam=@madvhc1 
		begin
			set @test=1
		end
		begin
		select  @tam=madonvihanhchinh  from tbltudiendonvihanhchinh where @matinh=matinh and @mahuyen=mahuyen and maxa=0
		end
	
   if @tam=@madvhc1 
		begin
			set @test=1
		end
   else 
	Begin	
    Select @Matinh=matinh, @MaHuyen=mahuyen,@MaXa=maxa from tblTuDienDonViHanhChinh where MaDonViHanhChinh=@tam
    	if @MaTinh<>0 and @mahuyen=0 and @maxa=0 
			begin
			select @tam1=madonvihanhchinh from tbltudiendonvihanhchinh where @matinh=matinh and mahuyen=0 and maxa=0
			end
		else if @matinh<>0 and @mahuyen<>0 and @maxa=0
			begin
			select  @tam1=madonvihanhchinh from tbltudiendonvihanhchinh where @matinh=matinh and mahuyen=0 
			end
		else  if @matinh<>0 and @mahuyen<>0 and @maxa<>0 
			begin
			select  @tam1=madonvihanhchinh  from tbltudiendonvihanhchinh where @matinh=matinh and @mahuyen=mahuyen and maxa=0
			end
	if @tam1=@madvhc1 
		begin
			set @test=1
		end
     else
		if @maDVHC1=@maDVHC2 
			begin
				set @test=1
			end
		else
			begin
				set @test=0
		    end
	end	
End' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_LayDonViCha]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[proc_LayDonViCha] 
@MaDVHC int
As 
Begin
Declare @MaTinh int 
Declare @MaHuyen int
Declare @MaXa int 
	Select @Matinh=matinh, @MaHuyen=mahuyen,@MaXa=maxa from tblTuDienDonViHanhChinh where MaDonViHanhChinh=@MaDVHC
	if @MaTinh<>0 and @mahuyen=0 and @maxa=0 
		begin
			select DISTINCT * from tbltudiendonvihanhchinh where @matinh=matinh and mahuyen=0 and maxa=0
			ORDER BY Ten
		end
	else if @matinh<>0 and @mahuyen<>0 and @maxa=0
		begin
			select DISTINCT * from tbltudiendonvihanhchinh where @matinh=matinh and mahuyen=0 
			ORDER BY Ten
		end
	else if @matinh<>0 and @mahuyen<>0 and @maxa<>0 
		begin
			select DISTINCT * from tbltudiendonvihanhchinh where @matinh=matinh and @mahuyen=mahuyen and maxa=0
			ORDER BY Ten
		end

End


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Quach Van Phong
-- Create date: <28/4/2010>
-- Description:	<phan in so cap giay chung nhan>
-- =============================================
CREATE PROCEDURE [dbo].[spSoCapGCN]
	@Flag int =null,
	@MaHoSoCapGCN nvarchar(50) =null,
	@NamIn nvarchar (20) =null,
	@MaDVHC nvarchar (20)=null
AS
BEGIN
	IF @Flag=1 
		BEGIN
			IF (@NamIn=0)
				BEGIN
					SELECT MaHoSoCapGCN,MaDonViHanhChinh,TrangThaiHoSoCapGCN,SoPhatHanhGCN,NgayKyGCN,NgayTraGCN,NguoiKyGCN,GhiChuGCN 
                    FROM tblHoSoCapGCN,tblTuDienDonViHanhChinh 
					WHERE TrangThaiHoSoCapGCN =7  AND tblHoSoCapGCN.Maxa=tblTuDienDonViHanhChinh.Maxa and MaDonViHanhChinh=@MaDVHC
				END
			ELSE
				BEGIN
                    SELECT MaHoSoCapGCN,MaDonViHanhChinh,TrangThaiHoSoCapGCN,SoPhatHanhGCN,NgayKyGCN,NgayTraGCN,NguoiKyGCN,GhiChuGCN 
                    FROM tblHoSoCapGCN,tblTuDienDonViHanhChinh
                    WHERE TrangThaiHoSoCapGCN =7 and year(NgayHoanTatGCN)=@NamIn and tblHoSoCapGCN.Maxa=tblTuDienDonViHanhChinh.Maxa and MaDonViHanhChinh=@MaDVHC
				END
		END
	IF @Flag=2 
			BEGIN
				SELECT * FROM tblChu ORDER BY HoTen
			END
	IF @Flag=3 
		BEGIN
			IF(@NamIn=0)
				BEGIN
					SELECT tblChu.HoTen, tblChu.GioiTinh, tblChu.DoiTuongSDD 
					FROM dbo.tblChu 
					INNER JOIN  dbo.tblChuHoSoCapGCN ON dbo.tblChuHoSoCapGCN.MaChu = dbo.tblChu.MaChu 
					WHERE tblChuHoSoCapGCN.MaHoSoCapGCN =@MaHoSoCapGCN 
					ORDER BY HoTen
				END
			ELSE
				BEGIN
					SELECT tblChu.HoTen, tblChu.GioiTinh, tblChu.DoiTuongSDD 
					FROM dbo.tblChu 
					INNER JOIN  dbo.tblChuHoSoCapGCN ON dbo.tblChu.MaChu = dbo.tblChuHoSoCapGCN.MaChu 
					INNER JOIN  dbo.tblHoSoCapGCN ON dbo.tblHoSoCapGCN.MaHoSoCapGCN = dbo.tblChuHoSoCapGCN.MaHoSoCapGCN
					WHERE tblChuHoSoCapGCN.MaHoSoCapGCN =@MaHoSoCapGCN and year(tblHoSoCapGCN.NgayHoanTatGCN)=@NamIn 
					ORDER BY HoTen
				END
		END
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTuDienDonViHanhChinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Created:03/20/2009
--Author:Pham xuan chung

CREATE procedure [dbo].[spTuDienDonViHanhChinh]
@flag int,
@MaDonViHanhChinh as int=null,
@Ten as nvarchar(50)=null,
@MaTinh as int=null,
@MaHuyen as int=null,
@MaXa as int =null
 as 
--Thao tac de tim cac don vi hanh chinh ma nguoi dugn quan ly
if @flag=0
	begin
		select * from tbltudiendonvihanhchinh where @MaDonViHanhChinh= MaDonViHanhChinh
	end

if @flag=1
	begin
		select ten from tbltudiendonvihanhchinh where @MaTinh=MaTinh and mahuyen=''0'' and maxa=''0''
	end

if @flag=2
	begin
		select ten from tbltudiendonvihanhchinh where @MaHuyen=MaHuyen and maxa=''0''
	end

if @flag=3
	begin
		select ten from tbltudiendonvihanhchinh where @MaXa=MaXa
	end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_GetChaConDVHC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[proc_GetChaConDVHC]
@matinh int,
@mahuyen int,
@maxa int,
@maquyen int
as 
Begin

	if @matinh<>0 and @mahuyen=0 and @maxa=0
	  begin
	    select * from tblusers where maquyen=@maquyen+1 and mausers in( select mausers from tbluserstatus where madonvihanhchinh in (select madonvihanhchinh from tbltudiendonvihanhchinh where matinh=@matinh) )
	  end
	else if @matinh<>0 and @mahuyen<>0 and @maxa=0
	  begin
	   select * from tblusers where maquyen=@maquyen+1 and mausers in( select mausers from tbluserstatus where madonvihanhchinh in (select madonvihanhchinh from tbltudiendonvihanhchinh where matinh=@matinh and mahuyen=@mahuyen) )
	--  return  		
	  end
	else
 	  begin
	    select * from tblusers where maquyen=@maquyen+1 and mausers in( select mausers from tbluserstatus where madonvihanhchinh in (select madonvihanhchinh from tbltudiendonvihanhchinh where matinh=@matinh and mahuyen=@mahuyen and maxa=@maxa) )
	  --  return	
	end
End' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proc_GetTuDienDonViHanhChinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE Proc [dbo].[Proc_GetTuDienDonViHanhChinh]
@MaDVHC int
As
Begin
	select * from tbltudiendonvihanhchinh where madonvihanhchinh = @MaDVHC
End
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_GetCap]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[proc_GetCap]
@Cap int 
As 
Begin
	if @cap =1
		begin
			select DISTINCT * 
			from tbltudiendonvihanhchinh 
			where matinh<>0 and mahuyen=0 and maxa=0
			ORDER BY Ten
		end
	else if @cap=2
		begin
			select DISTINCT * 
			from tbltudiendonvihanhchinh 
			where matinh<>0 and mahuyen<>0 and maxa=0
			ORDER BY Ten
		end
	else if @cap=3
		begin
			select DISTINCT * 
			from tbltudiendonvihanhchinh 
			where matinh<>0 and mahuyen<>0 and maxa<>0
			ORDER BY Ten			
		end

End


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Cap]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[proc_Cap]
@MaDVHC int,
@Cap int output
As 
Begin
Declare @MaTinh int 
Declare @MaHuyen int
Declare @MaXa int 
	Select @Matinh=matinh, @MaHuyen=mahuyen,@MaXa=maxa from tblTuDienDonViHanhChinh where MaDonViHanhChinh=@MaDVHC
	if @MaTinh<>0 and @mahuyen=0 and @maxa=0 
		begin
		set @cap=1
		end
	else if @matinh<>0 and @mahuyen<>0 and @maxa=0
		begin
		set @cap=2
		end
	else if @matinh<>0 and @mahuyen<>0 and @maxa<>0 
		begin
		set @cap=3
		end

End' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_ChaConDVHC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[proc_ChaConDVHC]
@maDVHC int,
@maquyen int
as 
Begin
declare @matinh int
declare @mahuyen int
declare @maxa int
select @matinh=matinh,@mahuyen=mahuyen,@maxa=maxa from tbltudiendonvihanhchinh where madonvihanhchinh=@madvhc
	if @matinh<>0 and @mahuyen=0 and @maxa=0
	  begin
	    select * from tblusers where maquyen=@maquyen+1 and mausers in( select mausers from tbluserstatus where madonvihanhchinh in (select madonvihanhchinh from tbltudiendonvihanhchinh where matinh=@matinh) )
	  end
	else if @matinh<>0 and @mahuyen<>0 and @maxa=0
	  begin
	   select * from tblusers where maquyen=@maquyen+1 and mausers in( select mausers from tbluserstatus where madonvihanhchinh in (select madonvihanhchinh from tbltudiendonvihanhchinh where matinh=@matinh and mahuyen=@mahuyen) )
	--  return  		
	  end
	else
 	  begin
	    select * from tblusers where maquyen=@maquyen+1 and mausers in( select mausers from tbluserstatus where madonvihanhchinh in (select madonvihanhchinh from tbltudiendonvihanhchinh where matinh=@matinh and mahuyen=@mahuyen and maxa=@maxa) )
	  --  return	
	end
End' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectMaXaByMaDVHC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 29/12/2009
-- Description:	lay  ma xa khi biet ma bang cua don vi hanh chinh
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectMaXaByMaDVHC]
	@MaDonViHanhChinh nvarchar (50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaXa FROM tblTuDienDonViHanhChinh 
	WHERE MaDonViHanhChinh=@MaDonViHanhChinh
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectDonViHanhChinhByMaNguoiDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100114
-- Description:	Nhận danh sách đơn vị Hành chính
-- mà Nguời dùng có quyền tác nghiệp theo Mã Người dùng
-- =============================================
CREATE PROCEDURE [dbo].[spSelectDonViHanhChinhByMaNguoiDung]
	-- Add the parameters for the stored procedure here
	@MaNguoiDung uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT DISTINCT m.madonvihanhchinh,n.ten
	FROM tbluserstatus m, tbltudiendonvihanhchinh n 
	WHERE @MaNguoiDung=m.mausers and m.madonvihanhchinh=n.madonvihanhchinh
	ORDER BY n.Ten
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTuDienGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích:

CREATE PROC [dbo].[spTuDienGCN]
	@Ma nvarchar (100)
as 
	set nocount on
	declare @IsExit int
	set @IsExit = 1
	-- Liet ke Thong tin Tu Dien GCN
			select DonViQuanLy,CoQuanCapGCN, ChucVuLanhDaoCoQuanCapGCN,LanhDaoCoQuanCapGCN
			 from   tblTuDienGCN
			where  1 = 1
			and (case @Ma
				when '''' then @Ma  else DonViQuanLy end) = @Ma
	set nocount off' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienLoaiHinhBienDong]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày Hiệu chỉnh: 20100313
--Người tạo: Vũ Lê Thành,
--Mục đích: Thêm loại hình biến động
CREATE PROC [dbo].[spInsertTuDienLoaiHinhBienDong]
	@KyHieu NVARCHAR (500) = null,
	@MoTa NVARCHAR (500) = null,
	@Nhom NVARCHAR (100) = null

AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	IF NOT EXISTS(SELECT * FROM tblTuDienLoaiHinhBienDong
		WHERE KyHieu = @KyHieu)
		INSERT INTO tblTuDienMucDichSDD( KyHieu ,MoTa )
		VALUES (@KyHieu,@MoTa )
	ELSE 
		SET @IsExit = 0
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienMucDichSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày Hiệu chỉnh: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: THÊM MỤC ĐÍCH sử dụng vào bảng từ điển
CREATE PROC [dbo].[spInsertTuDienMucDichSuDung]
	@KyHieu NVARCHAR (500) = null,
	@MoTa NVARCHAR (500) = null,
	@Nhom NVARCHAR (100) = null

AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	IF NOT EXISTS(SELECT * FROM tblTuDienMucDichSDD
		WHERE KyHieu = @KyHieu)
		INSERT INTO tblTuDienMucDichSDD( KyHieu ,MoTa )
		VALUES (@KyHieu,@MoTa )
	ELSE 
		SET @IsExit = 0
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienMucDichSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày hiệu chỉnh: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Cập nhật bảng từ điển MỤC ĐÍCH SỬ DỤNG
CREATE PROC [dbo].[spUpdateTuDienMucDichSuDung]
	@KyHieu NVARCHAR (500) = null ,
	@MoTa NVARCHAR (500) = null,
	@Nhom NVARCHAR (100) = null

AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	UPDATE tblTuDienMucDichSDD
	SET KyHieu=@KyHieu ,MoTa=@MoTa 
	WHERE KyHieu = @KyHieu

	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectMucDich]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Select bảng tblMucDichSuDungDat ( Muc dich su dung)
CREATE PROC [dbo].[spSelectMucDich]
	@MaMucDichSuDung NVARCHAR (50) = NULL,
	@MaThuaDatCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR (10) = NULL,
	@KyHieuKiemKe NVARCHAR(50) = NULL,
	@KyHieuQuiHoach NVARCHAR(50) = NULL,
	@ChiTiet NVARCHAR(200) = NULL,
	@DienTichKeKhai NVARCHAR(50) = NULL,
	@DienTichRieng NVARCHAR(50) = NULL,
	@DienTichChung NVARCHAR(50) = NULL,
	@ThoiHan NVARCHAR(500) = NULL,
	@GhiChu NVARCHAR(200) = NULL
AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	SELECT MaMucDichSuDung,MaThuaDatCapGCN,a.KyHieu,a.KyHieuKiemKe
	,a.KyHieuQuiHoach,a.ChiTiet,DienTichKeKhai,DienTichRieng,DienTichChung
	,ThoiHan,GhiChu, b.MoTa
	FROM tblMucDichSuDungDat a
	--Lien ket voi bang tblTuDienMucDich
	JOIN tblTuDienMucDichSDD AS b ON (b.KyHieu = a.KyHieu)
	WHERE 1 = 1
	AND (CASE @MaThuaDatCapGCN
		WHEN '''' THEN @MaThuaDatCapGCN  ELSE MaThuaDatCapGCN END) = @MaThuaDatCapGCN
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinKiemKeByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091019
-- Description:	Select thông tin kiểm kê đất đai
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinKiemKeByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaThongTinKiemKe BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@KyHieu nvarchar (50) = NULL,
	@DienTich nvarchar(50) = NULL,
	@MoTa nvarchar(500) = NULL,
	@GhiChu nvarchar (200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaThongTinKiemKe, MaHoSoCapGCN, a.KyHieu, DienTich,a.MoTa, GhiChu, b.MoTa
                       FROM tblThongTinKiemKe a
	--Lien ket voi bang tblTuDienMucDichSDD
	JOIN tblTuDienMucDichSDD AS b ON (b.KyHieu = a.KyHieu)
	WHERE 1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN  ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
	AND (CASE @MaThongTinKiemKe
		WHEN '''' THEN @MaThongTinKiemKe  ELSE MaThongTinKiemKe END) = @MaThongTinKiemKe
	AND (CASE @KyHieu
		WHEN '''' THEN @KyHieu  ELSE a.KyHieu END) = @KyHieu
	AND (CASE @DienTich
		WHEN '''' THEN @DienTich  ELSE DienTich END) = @DienTich
	AND (CASE @GhiChu
		WHEN '''' THEN @GhiChu  ELSE GhiChu END) = @GhiChu
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienMucDichSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày HIEU: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Select MÃ MỤC ĐÍCH SỬ DỤNG ĐẤT
CREATE PROC [dbo].[spSelectTuDienMucDichSuDung]
	@KyHieu NVARCHAR (500)= NULL,
	@MoTa NVARCHAR (500) = NULL,
	@Nhom NVARCHAR (100) = NULL

AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	-- Bang ma Muc dich su dung

		BEGIN
			--Truong hop hien thi Muc dich su dung
			SELECT * FROM tblTuDienMucDichSDD
			WHERE 1 = 1
			AND (CASE @KyHieu
				WHEN '''' THEN @KyHieu  ELSE KyHieu END) = @KyHieu
			ORDER BY KyHieu
		END
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienMucDichSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: XÓA MỤC ĐÍCH SỬ DỤNG TRONG BẢNG TỪ ĐIỂN
CREATE PROC [dbo].[spDeleteTuDienMucDichSuDung]
	@KyHieu NVARCHAR (500) = NULL,
	@MoTa NVARCHAR (500) = NULL,
	@Nhom NVARCHAR (100) = NULL

AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	DELETE FROM tblTuDienMucDichSDD
	WHERE KyHieu = @KyHieu
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinQuiHoachByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091019
-- Description:	Select thông tin qui hoạch đất đai
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinQuiHoachByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaThongTinQuiHoach BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@KyHieu nvarchar (50) = NULL,
	@DienTich nvarchar(50) = NULL,
	@MoTa nvarchar(500) = NULL,
	@GhiChu nvarchar (200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaThongTinQuiHoach, MaHoSoCapGCN, a.KyHieu, DienTich,a.MoTa, GhiChu, b.MoTa
                       FROM tblThongTinQuiHoach a
	--Lien ket voi bang tblTuDienMucDichSDD
	JOIN tblTuDienMucDichSDD AS b ON (b.KyHieu = a.KyHieu)
	WHERE 1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN  ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
	AND (CASE @MaThongTinQuiHoach
		WHEN '''' THEN @MaThongTinQuiHoach  ELSE MaThongTinQuiHoach END) = @MaThongTinQuiHoach
	AND (CASE @KyHieu
		WHEN '''' THEN @KyHieu  ELSE a.KyHieu END) = @KyHieu
	AND (CASE @DienTich
		WHEN '''' THEN @DienTich  ELSE DienTich END) = @DienTich
	AND (CASE @GhiChu
		WHEN '''' THEN @GhiChu  ELSE GhiChu END) = @GhiChu
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienNghiaVuTaiChinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: XÓA NGHĨA VỤ TÀI CHÍNH TRONG BẢNG TỪ ĐIỂN
CREATE PROC [dbo].[spDeleteTuDienNghiaVuTaiChinh]
	@KyHieu NVARCHAR (500) = NULL,
	@MoTa NVARCHAR (500) = NULL,
	@Nhom NVARCHAR (100) = NULL

AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	DELETE FROM tblTuDienNghiaVuTaiChinh
	WHERE KyHieu = @KyHieu
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienNghiaVuTaiChinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Select TỪ ĐIỂN NGHĨA VỤ TÀI CHÍNH
CREATE PROC [dbo].[spSelectTuDienNghiaVuTaiChinh]
	@KyHieu NVARCHAR (500)= NULL,
	@MoTa NVARCHAR (500) = NULL,
	@Nhom NVARCHAR (100) = NULL

AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	BEGIN
		--Truong hop hien thi NGHIA VU TAI CHINH su dung
		SELECT * FROM tblTuDienNghiaVuTaiChinh
		WHERE 1 = 1
		AND (CASE @KyHieu
			WHEN '''' THEN @KyHieu  ELSE KyHieu END) = @KyHieu
		ORDER BY KyHieu
	END
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienNghiaVuTaiChinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Cập nhật bảng từ điển NGHĨA VỤ TÀI CHÍNH
CREATE PROC [dbo].[spUpdateTuDienNghiaVuTaiChinh]
	@KyHieu NVARCHAR (500) = null ,
	@MoTa NVARCHAR (500) = null,
	@Nhom NVARCHAR (100) = null

AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	UPDATE tblTuDienNghiaVuTaiChinh
	SET KyHieu=@KyHieu ,MoTa=@MoTa 
	WHERE KyHieu = @KyHieu

	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienNghiaVuTaiChinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: THÊM NGHĨA VỤ TÀI CHÍNH sử dụng vào bảng từ điển
CREATE PROC [dbo].[spInsertTuDienNghiaVuTaiChinh]
	@KyHieu NVARCHAR (500) = null,
	@MoTa NVARCHAR (500) = null,
	@Nhom NVARCHAR (100) = null

AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	IF NOT EXISTS(SELECT * FROM tblTuDienNghiaVuTaiChinh
		WHERE KyHieu = @KyHieu)
		INSERT INTO tblTuDienNghiaVuTaiChinh( KyHieu ,MoTa )
		VALUES (@KyHieu,@MoTa )
	ELSE 
		SET @IsExit = 0
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienNguoiKyGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100302
-- Description:	Thêm mới Người ký GCN
-- =============================================
CREATE PROCEDURE [dbo].[spInsertTuDienNguoiKyGCN]
	-- Add the parameters for the stored procedure here
	@Ma INT = NULL ,
	@GioiTinh NVARCHAR(10) = NULL,
	@HoTen NVARCHAR(200) = NULL,
	@ChucDanh NVARCHAR(200) = NULL,
	@ChucVu NVARCHAR(200)= NULL	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1

    -- Insert statements for procedure here
	IF not exists (SELECT * FROM tblTuDienNguoiKyGCN
		WHERE Ma = @Ma)
		INSERT INTO tblTuDienNguoiKyGCN(GioiTinh,HoTen
			,ChucDanh,ChucVu)
		VALUES (@GioiTinh,@HoTen,@ChucDanh,@ChucVu)
	ELSE 
		SET @IsExit = 0
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienNguoiKyGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100302
-- Description:	Cập nhật Từ điển Người ký GCN
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateTuDienNguoiKyGCN]
	-- Add the parameters for the stored procedure here
	@Ma INT = NULL ,
	@GioiTinh NVARCHAR(10) = NULL,
	@HoTen NVARCHAR(200) = NULL,
	@ChucDanh NVARCHAR(200) = NULL,	
	@ChucVu NVARCHAR(200)= NULL	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	UPDATE tblTuDienNguoiKyGCN
	SET GioiTinh=@GioiTinh,HoTen = @HoTen
		,ChucDanh = @ChucDanh,ChucVu = @ChucVu
	WHERE Ma = @Ma
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienNguoiKyGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090907
-- Description:	Lựa chọn Người ký GCN trong bảng từ điển Người ký GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTuDienNguoiKyGCN]
	-- Add the parameters for the stored procedure here
	@Ma INT = NULL ,
	@GioiTinh NVARCHAR(10) = NULL,
	@HoTen NVARCHAR(200) = NULL,
	@ChucDanh NVARCHAR(200) = NULL,
	@ChucVu NVARCHAR(200)= NULL	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Ma,GioiTinh,HoTen,ChucDanh,ChucVu
	FROM tblTuDienNguoiKyGCN
	WHERE 1 = 1
	ORDER BY Ma ASC

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienNguoiKyGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100302
-- Description:	Xóa thông tin Người ký GCN theo Mã
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteTuDienNguoiKyGCN]
	-- Add the parameters for the stored procedure here
	@Ma INT = NULL,
	@GioiTinh nvarchar(10) = NULL,
	@HoTen nvarchar(200) = NULL,
	@ChucDanh nvarchar(200) = NULL,
	@ChucVu nvarchar(200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	-- Xóa dữ liệu trên bảng Từ điển người ký GCN
	DELETE FROM tblTuDienNguoiKyGCN
	WHERE Ma = @Ma
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_NguoiLapBieu]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham xuan chung
-- Create date: <23/11/2009>
-- Description:	<xu ly cho chuc nang nguoi in bieu>(phan cap gcn)
-- =============================================
CREATE PROCEDURE [dbo].[sp_NguoiLapBieu]
	@flag int =null,
	@MaNguoiLap nvarchar(50)=null,
	@HoTen nvarchar(100)=null,
	@GioiTInh nvarchar(50)=null,
	@ChucVu nvarchar(200)=null
AS
BEGIN
	if @flag=1 
		begin
			select * from tblTuDienNguoiLapBieu	
		end
	if @flag=2 
		begin
			insert into tblTuDienNguoiLapBieu values(newid(),@HoTen,@ChucVu)
		end
	if @flag=3 
		begin
			update tblTuDienNguoiLapBieu set HoTen=@HoTen, ChucVu=@ChucVu where MaNguoiLap=@MaNguoiLap
		end
	if @flag=4 
		begin
			delete from tblTuDienNguoiLapBieu where MaNguoiLap=@MaNguoiLap
		end
	if @flag=5 
		begin
			select * from tblTuDienNguoiLapBieu	 where HoTen=@HoTen
		end
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienNguoiPheDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090807
-- Description:	Thêm mới Người PHÊ DUYỆT
-- =============================================
CREATE PROCEDURE [dbo].[spInsertTuDienNguoiPheDuyet]
	-- Add the parameters for the stored procedure here
	@Ma INT = NULL,
	@GioiTinh nvarchar(10) = NULL,
	@HoTen nvarchar(200) = NULL,
	@ChucDanh nvarchar(200) = NULL,
	@ChucVu nvarchar(200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1

    -- Insert statements for procedure here
	IF not exists (SELECT * FROM tblTuDienNguoiPheDuyet
		WHERE Ma = @Ma)

		INSERT INTO tblTuDienNguoiPheDuyet(GioiTinh,HoTen
			,ChucDanh,ChucVu)
		VALUES (@GioiTinh,@HoTen,@ChucDanh,@ChucVu)
	ELSE 
		SET @IsExit = 0
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienNguoiPheDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090907
-- Description:	Cập nhật Từ điển Người PHÊ DUYỆT
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateTuDienNguoiPheDuyet]
	-- Add the parameters for the stored procedure here
	@Ma INT = NULL,
	@GioiTinh nvarchar(10) = NULL,
	@HoTen nvarchar(200) = NULL,
	@ChucDanh nvarchar(200) = NULL,
	@ChucVu nvarchar(200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	UPDATE tblTuDienNguoiPheDuyet
	SET GioiTinh=@GioiTinh,HoTen = @HoTen
		,ChucDanh = @ChucDanh,ChucVu = @ChucVu
	WHERE Ma = @Ma
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienNguoiPheDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090907
-- Description:	Lựa chọn Người PHÊ DUYỆT trong bảng từ điển Người PHÊ DUYỆT
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTuDienNguoiPheDuyet]
	-- Add the parameters for the stored procedure here
	@Ma INT = NULL,
	@GioiTinh nvarchar(10) = NULL,
	@HoTen nvarchar(200) = NULL,
	@ChucDanh nvarchar(200) = NULL,
	@ChucVu nvarchar(200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Ma,GioiTinh,HoTen,ChucDanh,ChucVu
	FROM tblTuDienNguoiPheDuyet
	WHERE 1 = 1
	ORDER BY HoTen

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienNguoiPheDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100302
-- Description:	Xóa thông tin Người phê duyệt theo Mã
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteTuDienNguoiPheDuyet]
	-- Add the parameters for the stored procedure here
	@Ma INT = NULL,
	@GioiTinh nvarchar(10) = NULL,
	@HoTen nvarchar(200) = NULL,
	@ChucDanh nvarchar(200) = NULL,
	@ChucVu nvarchar(200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	-- Xóa dữ liệu trên bảng TỪ ĐIỂN NGƯỜI PHÊ DUYỆT
	DELETE FROM tblTuDienNguoiPheDuyet
	WHERE Ma = @Ma
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienNguoiThamDinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteTuDienNguoiThamDinh]
	-- Add the parameters for the stored procedure here
	@Ma INT = NULL,
	@GioiTinh nvarchar(10) = NULL,
	@HoTen nvarchar(200) = NULL,
	@ChucDanh nvarchar(200) = NULL,
	@ChucVu nvarchar(200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	-- Xóa dữ liệu trên bảng TỪ ĐIỂN NGƯỜI THẨM ĐỊNH
	DELETE FROM tblTuDienNguoiThamDinh
	WHERE Ma = @Ma
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienNguoiThamDinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090907
-- Description:	Lựa chọn Người THẨM ĐỊNH trong bảng từ điển Người THẨM ĐỊNH
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTuDienNguoiThamDinh]
	-- Add the parameters for the stored procedure here
	@Ma INT = NULL,
	@GioiTinh nvarchar(10) = NULL,
	@HoTen nvarchar(200) = NULL,
	@ChucDanh nvarchar(200) = NULL,
	@ChucVu nvarchar(200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Ma,GioiTinh,HoTen,ChucDanh,ChucVu
	FROM tblTuDienNguoiThamDinh
	WHERE 1 = 1
	ORDER BY HoTen

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienNguoiThamDinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090907
-- Description:	Cập nhật Từ điển Người THẨM ĐỊNH
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateTuDienNguoiThamDinh]
	-- Add the parameters for the stored procedure here
	@Ma INT = NULL,
	@GioiTinh nvarchar(10) = NULL,
	@HoTen nvarchar(200) = NULL,
	@ChucDanh nvarchar(200) = NULL,
	@ChucVu nvarchar(200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	UPDATE tblTuDienNguoiThamDinh
	SET GioiTinh=@GioiTinh,HoTen = @HoTen
		,ChucDanh = @ChucDanh,ChucVu = @ChucVu
	WHERE Ma = @Ma
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienNguoiThamDinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090807
-- Description:	Thêm mới Người THẨM ĐỊNH
-- =============================================
CREATE PROCEDURE [dbo].[spInsertTuDienNguoiThamDinh]
	-- Add the parameters for the stored procedure here
	@Ma INT = NULL,
	@GioiTinh nvarchar(10) = NULL,
	@HoTen nvarchar(200) = NULL,
	@ChucDanh nvarchar(200) = NULL,
	@ChucVu nvarchar(200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1

    -- Insert statements for procedure here
	IF not exists (SELECT * FROM tblTuDienNguoiThamDinh
		WHERE Ma = @Ma)

		INSERT INTO tblTuDienNguoiThamDinh(GioiTinh,HoTen
			,ChucDanh,ChucVu)
		VALUES (@GioiTinh,@HoTen,@ChucDanh,@ChucVu)
	ELSE 
		SET @IsExit = 0
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienNguoiXetDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100302
-- Description:	Thêm mới Người xét duyệt
-- =============================================
CREATE PROCEDURE [dbo].[spInsertTuDienNguoiXetDuyet]
	-- Add the parameters for the stored procedure here
	@Ma INT = NULL,
	@GioiTinh NVARCHAR(10) = NULL,
	@HoTen NVARCHAR(200) = NULL,
	@ChucDanh NVARCHAR(200) = NULL,
	@ChucVu NVARCHAR(200) = NULL	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1
    -- Insert statements for procedure here
	IF not exists (SELECT * FROM tblTuDienNguoiXetDuyet
		WHERE Ma = @Ma)
		INSERT INTO tblTuDienNguoiXetDuyet(GioiTinh,HoTen
			,ChucDanh,ChucVu)
		VALUES (@GioiTinh,@HoTen,@ChucDanh,@ChucVu)
	ELSE 
		SET @IsExit = 0
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectHoiDongXetDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100302
-- Description:	Lựa chọn Hội đồng xét duyệt
-- =============================================
CREATE PROCEDURE [dbo].[spSelectHoiDongXetDuyet]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT = NULL,
	@MaNguoiXetDuyet INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
		BEGIN				
			SELECT * FROM tblHoiDongXetDuyet AS HDXD
			INNER JOIN tblTuDienNguoiXetDuyet AS TDNXD ON HDXD.MaNguoiXetDuyet = TDNXD.Ma
			WHERE (HDXD.MaHoSoCapGCN = @MaHoSoCapGCN)
			PRINT ''Selected''
		END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectInHoiDongXetDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung 
-- Create date: <13/11/2009>
-- Description:	<Lay thogn tin hoi dong xet duyet theo moi ho so>(Phan in hoi dong xet duyet)
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectInHoiDongXetDuyet]
	@MaHoSoCapGCN nvarchar(50)=null
AS
BEGIN
SELECT DISTINCT 
                      dbo.tblHoiDongXetDuyet.MaHoSoCapGCN, dbo.tblTuDienNguoiXetDuyet.HoTen, dbo.tblTuDienNguoiXetDuyet.ChucDanh, 
                      dbo.tblTuDienNguoiXetDuyet.ChucVu, dbo.tblTuDienNguoiXetDuyet.GioiTinh
FROM         dbo.tblHoiDongXetDuyet INNER JOIN
                      dbo.tblTuDienNguoiXetDuyet ON dbo.tblHoiDongXetDuyet.MaNguoiXetDuyet = dbo.tblTuDienNguoiXetDuyet.Ma
where tblHoiDongXetDuyet.MaHoSoCapGCN=@MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienNguoiXetDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090907
-- Description:	Cập nhật Từ điển Người xét duyệt
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateTuDienNguoiXetDuyet]
	-- Add the parameters for the stored procedure here
	@Ma INT = NULL ,
	@GioiTinh NVARCHAR(10) = NULL,
	@HoTen NVARCHAR(200) = NULL,
	@ChucDanh NVARCHAR(200) = NULL,	
	@ChucVu NVARCHAR(200)= NULL	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	UPDATE tblTuDienNguoiXetDuyet
	SET GioiTinh=@GioiTinh,HoTen = @HoTen
		,ChucDanh = @ChucDanh,ChucVu = @ChucVu
	WHERE Ma = @Ma
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienNguoiXetDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090907
-- Description:	Lựa chọn Người xét duyệt trong bảng từ điển Người xét duyệt
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTuDienNguoiXetDuyet]
	-- Add the parameters for the stored procedure here
	@Ma INT = NULL,
	@GioiTinh NVARCHAR(10) = NULL,
	@HoTen NVARCHAR(200) = NULL,
	@ChucDanh NVARCHAR(200) = NULL,	
	@ChucVu NVARCHAR(200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Ma,GioiTinh,HoTen,ChucDanh,ChucVu
	FROM tblTuDienNguoiXetDuyet
	WHERE 1 = 1
	ORDER BY HoTen ASC

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienNguoiXetDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100302
-- Description:	Xóa người xét duyệt trong bảng Từ điển người xét duyệt
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteTuDienNguoiXetDuyet]
	-- Add the parameters for the stored procedure here
	@Ma INT = NULL,
	@GioiTinh NVARCHAR(10)=NULL,
	@HoTen NVARCHAR(200)=NULL,
	@ChucDanh NVARCHAR(200)=NULL,
	@ChucVu NVARCHAR(200)=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	-- Xóa dữ liệu trên bảng cha
	DELETE FROM tblHoiDongXetDuyet
	WHERE MaNguoiXetDuyet = CONVERT(INT, @Ma)
	-- Xóa dữ liệu trên bảng con
	DELETE FROM tblTuDienNguoiXetDuyet
	WHERE Ma = CONVERT(INT, @Ma)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienNguonGocSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Select MÃ NGUỒN GỐC SỬ DỤNG ĐẤT
CREATE PROC [dbo].[spSelectTuDienNguonGocSuDung]
	@KyHieu NVARCHAR (500)= NULL,
	@MoTa NVARCHAR (500) = NULL,
	@Nhom NVARCHAR (100) = NULL

AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	BEGIN
		--Truong hop hien thi NGUON GOC su dung
		SELECT * FROM tblTuDienNguonGocSDD
		WHERE 1 = 1
		AND (CASE @KyHieu
			WHEN '''' THEN @KyHieu  ELSE KyHieu END) = @KyHieu
		ORDER BY KyHieu
	END
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienNguonGocSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: XÓA NGUỒN GỐC SỬ DỤNG TRONG BẢNG TỪ ĐIỂN
CREATE PROC [dbo].[spDeleteTuDienNguonGocSuDung]
	@KyHieu NVARCHAR (500) = NULL,
	@MoTa NVARCHAR (500) = NULL,
	@Nhom NVARCHAR (100) = NULL

AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	DELETE FROM tblTuDienNguonGocSDD
	WHERE KyHieu = @KyHieu
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienNguonGocSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Cập nhật bảng từ điển NGUỒN GỐC SỬ DỤNG
CREATE PROC [dbo].[spUpdateTuDienNguonGocSuDung]
	@KyHieu NVARCHAR (500) = null ,
	@MoTa NVARCHAR (500) = null,
	@Nhom NVARCHAR (100) = null

AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	UPDATE tblTuDienNguonGocSDD
	SET KyHieu=@KyHieu ,MoTa=@MoTa 
	WHERE KyHieu = @KyHieu

	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectNguonGocSuDungDatByMaThuaDatCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: SELECT bảng tblNguonGocSuDungDat (Nguon goc su dung dat)
-- theo Mã thửa đất cấp GCN
CREATE PROC [dbo].[spSelectNguonGocSuDungDatByMaThuaDatCapGCN]
	@MaNguonGoc NVARCHAR(100) = NULL,
	@MaThuaDatCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR(10) = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@ChiTiet NVARCHAR(1500) = NULL,
	@GhiChu NVARCHAR(200) = NULL

AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	-- Liet ke danh sach Nguon goc su dung dat

	SELECT MaNguonGoc,MaThuaDatCapGCN,a.KyHieu,DienTich
		,ChiTiet, GhiChu, b.MoTa
    FROM tblNguonGocSuDungDat a
	--Lien ket voi bang tblTuDienNguonGocSDD
	JOIN tblTuDienNguonGocSDD AS b ON (b.KyHieu = a.KyHieu)
	WHERE 1 = 1
	AND(CASE @MaThuaDatCapGCN
		WHEN '''' THEN @MaThuaDatCapGCN  ELSE MaThuaDatCapGCN END) = @MaThuaDatCapGCN
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienNguonGocSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: THÊM NGUỒN GỐC sử dụng vào bảng từ điển
CREATE PROC [dbo].[spInsertTuDienNguonGocSuDung]
	@KyHieu NVARCHAR (500) = null,
	@MoTa NVARCHAR (500) = null,
	@Nhom NVARCHAR (100) = null

AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	IF NOT EXISTS(SELECT * FROM tblTuDienNguonGocSDD
		WHERE KyHieu = @KyHieu)
		INSERT INTO tblTuDienNguonGocSDD( KyHieu ,MoTa )
		VALUES (@KyHieu,@MoTa )
	ELSE 
		SET @IsExit = 0
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateChuHoSoCapGCNCQNNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100201
-- Description:	Cập nhật thông tin chủ Hồ sơ cấp GCN theo Mã Hồ sơ cấp GCN
-- thuộc đối tượng Cơ quan nhà nước vào bảng tblChu
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateChuHoSoCapGCNCQNNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT  = NULL
	,@MaChu BIGINT = NULL
	,@DoiTuongSDD NVARCHAR(100) = NULL
	,@HoTen NVARCHAR(200) = NULL
	,@DiaChi NVARCHAR(200) = NULL
	,@Dat NVARCHAR(50) = NULL
	,@NhaO NVARCHAR(50) = NULL
	,@CongTrinhXayDung NVARCHAR(50) = NULL
	,@RungCay NVARCHAR(50) = NULL
	,@CayLauNam NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRANSACTION 
		BEGIN
			Set DATEFORMAT DMY --,
			-- Cập nhật thông tin Chủ trong bảng từ điển Chủ 
			Update tblChu
			Set ThoiDiemKeKhaiDangKy= getdate () ,DoiTuongSDD = @DoiTuongSDD 
					,HoTen = @HoTen ,DiaChi = @DiaChi
			Where (MaChu = @MaChu)
			IF (@@ERROR <> 0)
				BEGIN
					ROLLBACK TRANSACTION
					RETURN
				END
			ELSE 
				-- Cập nhật thông tin trong bảng trung gian tblChuHoSoCapGCN
				BEGIN
					Update tblChuHoSoCapGCN
					Set Dat = @Dat
						,NhaO = @NhaO
						,CongTrinhXayDung = @CongTrinhXayDung
						,RungCay = @RungCay
						,CayLauNam = @CayLauNam
					Where (MaHoSoCapGCN = @MaHoSoCapGCN) AND (MaChu = @MaChu)									
					IF (@@ERROR <> 0)
						BEGIN 
							ROLLBACK TRANSACTION
							RETURN
						END
					ELSE
						BEGIN				
							COMMIT TRANSACTION
						END
				END
		End
	Print ''Updated successfuly!''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateChuHoSoCapGCNGDCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100201
-- Description:	Cập nhật thông tin Hồ sơ cấp GCN theo 
-- Mã Hồ sơ cấp GCN vào bảng tblChuHoSoCapGCN và bảng tblChu
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateChuHoSoCapGCNGDCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT  = NULL,
	@MaChu BIGINT = null,
	@QuanHe nvarchar (50) = null ,	
	@GioiTinh nvarchar(50)= null ,
	@HoTen nvarchar (50)= null ,	
	@NamSinh nvarchar(50)= null ,	
	@DiaChi nvarchar (200)= null ,	

	@QuocTich nvarchar (100)= null ,	
	@SoDinhDanh nvarchar (50)= null ,	
	@NgayCap nvarchar(50)= null ,	
	@NoiCap nvarchar (200)= null ,	

	@QuocTich2 nvarchar (100)= null ,	
	@SoDinhDanh2 nvarchar (50)= null ,	
	@NgayCap2 nvarchar(50)= null ,	
	@NoiCap2 nvarchar (200)= null ,	

	@SoHoKhau nvarchar (50)= null ,	
	@NgayCapHoKhau nvarchar(50)= null ,	
	@NoiCapHoKhau nvarchar (200)= null 
	,@Dat NVARCHAR(50) = NULL
	,@NhaO NVARCHAR(50) = NULL
	,@CongTrinhXayDung NVARCHAR(50) = NULL
	,@RungCay NVARCHAR(50) = NULL
	,@CayLauNam NVARCHAR(50) = NULL
	,@DaChet nvarchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRANSACTION
		BEGIN
			Set DATEFORMAT DMY --,
			-- Cập nhật thông tin Chủ trong bảng từ điển Chủ 
			UPDATE tblChu
			SET ThoiDiemKeKhaiDangKy= getdate () ,DoiTuongSDD = ''GDC'' ,QuanHe = @QuanHe 
					,GioiTinh = convert(bit,@GioiTinh),HoTen = @HoTen ,NamSinh = convert(int,@NamSinh)
					,QuocTich = @QuocTich ,SoDinhDanh = @SoDinhDanh ,NgayCap = convert(datetime,@NgayCap) ,NoiCap = @NoiCap
					,QuocTich2 = @QuocTich2 ,SoDinhDanh2 = @SoDinhDanh2,NgayCap2 = convert(datetime,@NgayCap2) ,NoiCap2 = @NoiCap2
					,DiaChi = @DiaChi,SoHoKhau = @SoHoKhau ,NgayCapHoKhau = convert(datetime,@NgayCapHoKhau)
					,NoiCapHoKhau = @NoiCapHoKhau ,DaChet=@DaChet
			WHERE (MaChu = @MaChu)
			IF (@@ERROR <> 0)
				BEGIN
					ROLLBACK TRANSACTION
					RETURN
				END
			ELSE 
				-- Cập nhật thông tin trong bảng trung gian tblChuHoSoCapGCN
				BEGIN
					Update tblChuHoSoCapGCN
					Set Dat = @Dat
						,NhaO = @NhaO
						,CongTrinhXayDung = @CongTrinhXayDung
						,RungCay = @RungCay
						,CayLauNam = @CayLauNam
					Where (MaHoSoCapGCN = @MaHoSoCapGCN) AND (MaChu = @MaChu)									
					IF (@@ERROR <> 0)
						BEGIN 
							ROLLBACK TRANSACTION
							RETURN
						END
					ELSE
						BEGIN				
							COMMIT TRANSACTION
						END
				END
		END
		Print ''Update''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateChuHoSoCapGCNTCDNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100201
-- Description:	Cập nhật thông tin chủ hồ sơ cấp GCN
-- thuộc đối tượng Tổ chức, doanh nghiệp vào bảng tblChu và 
-- bảng tblChuHoSoCapGCN theo Mã hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateChuHoSoCapGCNTCDNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT  = NULL,
	@MaChu BIGINT = NULL,
	--Những biến sau có thể không cần thiết
	@DoiTuongSDD nvarchar (10) = null,
	@HoTen nvarchar (50)= null ,	
	@SoDinhDanh nvarchar (50)= null,	
	@NgayCap nvarchar(50)= null ,	
	@NoiCap nvarchar (200)= null ,	
	@DiaChi nvarchar (200)= null 
	,@Dat NVARCHAR(50) = NULL
	,@NhaO NVARCHAR(50) = NULL
	,@CongTrinhXayDung NVARCHAR(50) = NULL
	,@RungCay NVARCHAR(50) = NULL
	,@CayLauNam NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	BEGIN TRANSACTION
		BEGIN
			Set DATEFORMAT DMY --,
			Update tblChu
			Set ThoiDiemKeKhaiDangKy= getdate () ,DoiTuongSDD = @DoiTuongSDD 
					,HoTen = @HoTen ,SoDinhDanh = @SoDinhDanh ,NgayCap = convert(datetime,@NgayCap)
					,NoiCap = @NoiCap,DiaChi = @DiaChi
			Where (MaChu = @MaChu)
			IF (@@ERROR <> 0)
				BEGIN
					ROLLBACK TRANSACTION
					RETURN
				END
			ELSE 
				-- Cập nhật thông tin trong bảng trung gian tblChuHoSoCapGCN
				BEGIN
					Update tblChuHoSoCapGCN
					Set Dat = @Dat
						,NhaO = @NhaO
						,CongTrinhXayDung = @CongTrinhXayDung
						,RungCay = @RungCay
						,CayLauNam = @CayLauNam
					Where (MaHoSoCapGCN = @MaHoSoCapGCN) AND (MaChu = @MaChu)									
					IF (@@ERROR <> 0)
						BEGIN 
							ROLLBACK TRANSACTION
							RETURN
						END
					ELSE
						BEGIN				
							COMMIT TRANSACTION
						END
				END
		END
		Print ''Update''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteChuByCQNN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090825
-- Description:	Xóa chủ sử dụng thuộc đối tượng Cơ quan nhà nước
-- trong bảng tblChu, tblChuSuDung, tblChuSoHuu
-- Note: Cần kiểm tra lại để tối ưu hơn
-- CÓ THỂ GỘP 3 STORE PROCEDURE LÀM MỘT VÌ LÚC NÀY KHÔNG CẦN 
-- QUAN TÂM CHỦ CẦN XÓA THUỘC NHÓM ĐỐI TƯỢNG NÀO
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteChuByCQNN]
	-- Add the parameters for the stored procedure here
	@MaChu BIGINT,
	--Những biến sau có thể không cần thiết
	@DoiTuongSDD NVARCHAR(10) = NULL,
	@HoTen NVARCHAR(50)= NULL,	
	@DiaChi NVARCHAR(200)= NULL,	
	@TonTai NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Begin
		-- XÓA CÁC BẢNG CON
		-- Xóa chủ sử dụng trong bảng tblChuSuDung
		If exists (Select * From tblChuSuDung Where MaChu = @MaChu)
			Begin
				Delete from tblChuSuDung
				Where (MaChu = @MaChu) 
				Print ''Đã xóa''
			End
		-- Xóa chủ sở hữu trong bảng tblChuSoHuu
		If exists (Select * From tblChuSoHuu Where MaChu = @MaChu)
			Begin
				Delete from tblChuSoHuu
				Where (MaChu = @MaChu) 
				Print ''Đã xóa''
			End
		-- XÓA BẢNG CHA
		-- Xóa Chủ sử dụng trong bảng tblChu
		If exists (Select * From tblChu Where MaChu = @MaChu)
			Begin
				Delete from tblChu
				Where (MaChu = @MaChu) 
				Print ''Đã xóa''
			End
	End
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChuDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100122
-- Description:	Lựa chọn danh sách Chủ 
-- đề nghị cấp GCN theo Mã Hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectChuDeNghiCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT * FROM tblChu AS C
	INNER JOIN tblChuDeNghiCapGCN  AS CDN ON (CDN.MaChu = C.MaChu) 
	WHERE ( CDN.MaHoSoCapGCN = @MaHoSoCapGCN )
	ORDER BY MaChuDeNghiCapGCN
	PRINT ''Selected''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_selectTenChu]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Pham xuan chung>
-- Create date: <23/11/2009>
-- Description:	<lay thogn tin chu su dung khi biet ma hosocapgcn>(phan tim kiem)
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectTenChu]
	@MaHoSoCapGCN NVARCHAR(50)=null
AS
BEGIN
	SELECT     C.HoTen
	FROM   	  tblChu AS C
			  INNER JOIN tblChuHoSoCapGCN AS CHS ON CHS.MaChu = C.MaChu
	WHERE CHS.MaHoSoCapGCN=@MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteChuByTCDN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090825
-- Description:	Xóa chủ sử dụng thuộc đối tượng Tổ chức, doanh nghiệp
-- trong các bảng tblChu, tblChuSuDung, tblChuSoHuu
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteChuByTCDN]
	-- Add the parameters for the stored procedure here
	@MaChu BIGINT,
	--Những biến sau có thể không cần thiết
	@DoiTuongSDD nvarchar (10) = null,
	@HoTen nvarchar (50)= null ,	
	@SoDinhDanh nvarchar (50)= null ,	
	@NgayCap nvarchar(50)= null ,	
	@NoiCap nvarchar (200)= null ,	
	@DiaChi nvarchar (200)= null ,	
	@TonTai nvarchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN
		-- XÓA CÁC BẢNG CON
		-- Xóa chủ sử dụng trong bảng tblChuSuDung
		If exists (Select * From tblChuSuDung Where MaChu = @MaChu)
			Begin
				Delete from tblChuSuDung
				Where (MaChu = @MaChu) 
				Print ''Da xoa''
			End
		-- Xóa chủ sở hữu trong bảng tblChuSoHuu
		If exists (Select * From tblChuSoHuu Where MaChu = @MaChu)
			Begin
				Delete from tblChuSoHuu
				Where (MaChu = @MaChu) 
				Print ''Da xoa''
			End
		-- XÓA BẢNG CHA
		-- Xóa Chủ sử dụng trong bảng tblChu
		If exists (Select * From tblChu Where MaChu = @MaChu)
			Begin
				Delete from tblChu
				Where (MaChu = @MaChu) 
				Print ''Da xoa''
			End
	END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteChuByGDCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090825
-- Description:	Xóa chủ sử dụng thuộc nhóm đối tượng GDCN
-- trong các bảng tblChu, tblChuSuDung, tblChuSoHuu
-- Note: Cần xem lại để tối ưu hóa hàm này.
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteChuByGDCN]
	-- Add the parameters for the stored procedure here
	@MaChu BIGINT,
	--Những biến sau có thể không cần thiết
	@QuanHe nvarchar (50) = null ,	
	@GioiTinh nvarchar(50)= null ,
	@HoTen nvarchar (50)= null ,	
	@NamSinh nvarchar(50)= null ,	
	@SoDinhDanh nvarchar (50)= null ,	
	@NgayCap nvarchar(50)= null ,	
	@NoiCap nvarchar (200)= null ,	
	@DiaChi nvarchar (200)= null ,	
	@QuocTich nvarchar (100)= null ,	
	@SoHoKhau nvarchar (50)= null ,	
	@NgayCapHoKhau nvarchar(50)= null ,	
	@NoiCapHoKhau nvarchar (200)= null ,
	@TonTai nvarchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Begin
		-- XÓA CÁC BẢNG CON
		-- Xóa chủ sử dụng trong bảng tblChuSuDung
		If exists (Select * From tblChuSuDung Where MaChu = @MaChu)
			Begin
				Delete from tblChuSuDung
				Where (MaChu = @MaChu) 
				Print ''Da xoa''
			End
		-- Xóa chủ sở hữu trong bảng tblChuSoHuu
		If exists (Select * From tblChuSoHuu Where MaChu = @MaChu)
			Begin
				Delete from tblChuSoHuu
				Where (MaChu = @MaChu) 
				Print ''Da xoa''
			End
		-- XÓA BẢNG CHA
		-- Xóa Chủ sử dụng trong bảng tblChu
		If exists (Select * From tblChu Where MaChu = @MaChu)
			Begin
				Delete from tblChu
				Where (MaChu = @MaChu) 
				Print ''Da xoa''
			End
	End
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinChuByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham xuan chung
-- Create date: 12/5/2010
-- Description:	lay thong tin chu su dung khi biet dc thong tin ho so cap giay chung nhan
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinChuByMaHoSoCapGCN]
	@MaHoSoCapGCN nvarchar(20)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  SELECT     dbo.tblChu.HoTen, dbo.tblChu.GioiTinh, dbo.tblChu.DiaChi, dbo.tblChuHoSoCapGCN.MaHoSoCapGCN
FROM         dbo.tblChuHoSoCapGCN INNER JOIN
                      dbo.tblChu ON dbo.tblChuHoSoCapGCN.MaChu = dbo.tblChu.MaChu
where MaHoSoCapGCN=@MaHoSoCapGCN
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertChuHoSoCapGCNTCDNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100201
-- Description:	Thêm chủ Hồ sơ cấp GCN vào bảng tblChu và 
-- bảng tblChuHoSoCapGCN theo Mã hồ sơ cấp GCN
-- bởi đối tượng Tổ chức doanh nghiệp
-- =============================================
CREATE PROCEDURE [dbo].[spInsertChuHoSoCapGCNTCDNByMaHoSoCapGCN] 
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT  = NULL,
	@MaChu BIGINT,
	--Những biến sau có thể không cần thiết
	@DoiTuongSDD nvarchar (10) = null,
	@HoTen nvarchar (50)= null ,	
	@SoDinhDanh nvarchar (50)= null ,	
	@NgayCap nvarchar(50)= null ,	
	@NoiCap nvarchar (200)= null ,	
	@DiaChi nvarchar (200)= null 
	,@Dat NVARCHAR(50) = NULL
	,@NhaO NVARCHAR(50) = NULL
	,@CongTrinhXayDung NVARCHAR(50) = NULL
	,@RungCay NVARCHAR(50) = NULL
	,@CayLauNam NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @MaChuMoi BIGINT;
	BEGIN TRANSACTION
	BEGIN				
		SET DATEFORMAT DMY
		IF NOT EXISTS (SELECT DISTINCT MaChu FROM tblChu WHERE DoiTuongSDD = @DoiTuongSDD 
					and HoTen = @HoTen and SoDinhDanh = @SoDinhDanh and 
					NoiCap =@NoiCap)
					BEGIN
						--truong hop da ton tai MaChuSuDung trong bang tblChuSuDung
						INSERT INTO tblChu(ThoiDiemKeKhaiDangKy ,DoiTuongSDD ,HoTen 
							,SoDinhDanh ,NgayCap ,NoiCap,DiaChi)
						VALUES (getdate(),@DoiTuongSDD ,@HoTen ,@SoDinhDanh
							 ,getdate() ,@NoiCap,@DiaChi)
					SET @MaChuMoi = @@IDENTITY;
					IF (@@ERROR <> 0)
						BEGIN
							ROLLBACK TRANSACTION
							RETURN
						END
					-- Chắc chắn rằng đã sinh ra một Chủ mới
					--(Mã chủ mới > 0)
					IF (@MaChuMoi <= 0 )
						BEGIN
							ROLLBACK TRANSACTION
							RETURN
						END
					ELSE
						BEGIN
							INSERT INTO tblChuHoSoCapGCN 
								(MaHoSoCapGCN,MaChu,Dat,NhaO
									,CongTrinhXayDung,RungCay,CayLauNam)
							VALUES (@MaHoSoCapGCN,@MaChuMoi,@Dat,@NhaO
									,@CongTrinhXayDung,@RungCay,@CayLauNam)
							IF (@@ERROR <> 0)
								BEGIN 
									ROLLBACK TRANSACTION
									RETURN
								END
							ELSE
								BEGIN
									COMMIT TRANSACTION 
								END
						END
					End
					Print ''Add New''
	
	END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertChuHoSoCapGCNGDCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100201
-- Description:	Thêm chủ Hồ sơ cấp GCN vào bảng tblChuHoSoCapGCN và bảng
-- tblChu theo Mã hồ sơ cấp GCN bởi nhóm đối tượng GDCN
-- =============================================
CREATE PROCEDURE [dbo].[spInsertChuHoSoCapGCNGDCNByMaHoSoCapGCN] 
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT  = NULL,
	@MaChu BIGINT = null,
	@QuanHe nvarchar (50) = null ,	
	@GioiTinh nvarchar(50)= null ,
	@HoTen nvarchar (50)= null ,	
	@NamSinh nvarchar(50)= null ,	
	@DiaChi nvarchar (200)= null ,	

	@QuocTich nvarchar (100)= null ,	
	@SoDinhDanh nvarchar (50)= null ,	
	@NgayCap nvarchar(50)= null ,	
	@NoiCap nvarchar (200)= null ,	

	@QuocTich2 nvarchar (100)= null ,	
	@SoDinhDanh2 nvarchar (50)= null ,	
	@NgayCap2 nvarchar(50)= null ,	
	@NoiCap2 nvarchar (200)= null ,	

	@SoHoKhau nvarchar (50)= null ,	
	@NgayCapHoKhau nvarchar(50)= null ,	
	@NoiCapHoKhau nvarchar (200)= null 
	,@Dat NVARCHAR(50) = NULL
	,@NhaO NVARCHAR(50) = NULL
	,@CongTrinhXayDung NVARCHAR(50) = NULL
	,@RungCay NVARCHAR(50) = NULL
	,@CayLauNam NVARCHAR(50) = NULL
	,@DaChet nvarchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @MaChuMoi BIGINT;
	BEGIN TRANSACTION
	BEGIN
		SET DATEFORMAT DMY
		IF NOT EXISTS (SELECT DISTINCT MaChu FROM tblChu WHERE DoiTuongSDD = ''GDC'' 
			and GioiTinh = @GioiTinh and HoTen = @HoTen
			and NamSinh = @NamSinh and SoDinhDanh = @SoDinhDanh and 
			NoiCap =@NoiCap and QuocTich=@QuocTich and SoHoKhau =@SoHoKhau
			and NoiCapHoKhau=@NoiCapHoKhau and DaChet=@DaChet)
			Begin
				--truong hop da ton tai MaChuSuDung trong bang tblChuSuDung
				Insert into tblChu(ThoiDiemKeKhaiDangKy ,DoiTuongSDD ,QuanHe ,GioiTinh,HoTen ,NamSinh 
					,SoDinhDanh ,NgayCap ,NoiCap,DiaChi,QuocTich
					,SoDinhDanh2,NgayCap2,NoiCap2,QuocTich2
					,SoHoKhau ,NgayCapHoKhau,NoiCapHoKhau,DaChet)
				Values (getdate() ,''GDC'' ,@QuanHe ,convert(bit,@GioiTinh),@HoTen ,convert(int,@NamSinh) 
					 ,@SoDinhDanh,CONVERT(DATETIME,@NgayCap) ,@NoiCap,@DiaChi,@QuocTich
					 ,@SoDinhDanh2,CONVERT(DATETIME,@NgayCap2) ,@NoiCap2,@QuocTich2
					,@SoHoKhau ,@NgayCapHoKhau,@NoiCapHoKhau,@DaChet)
				--Select @@IDENTITY as MaChu
				SET @MaChuMoi = @@IDENTITY;
				IF (@@ERROR <> 0)
					BEGIN
						ROLLBACK TRANSACTION
						RETURN
					END
				-- Chắc chắn rằng đã sinh ra một Chủ mới
				--(Mã chủ mới > 0)
				IF (@MaChuMoi <= 0 )
					BEGIN
						ROLLBACK TRANSACTION
						RETURN
					END
				ELSE
					BEGIN
						INSERT INTO tblChuHoSoCapGCN 
							(MaHoSoCapGCN,MaChu,Dat,NhaO
								,CongTrinhXayDung,RungCay,CayLauNam)
						VALUES (@MaHoSoCapGCN,@MaChuMoi,@Dat,@NhaO
								,@CongTrinhXayDung,@RungCay,@CayLauNam)
						IF (@@ERROR <> 0)
							BEGIN 
								ROLLBACK TRANSACTION
								RETURN
							END
						ELSE
							BEGIN
								COMMIT TRANSACTION 
							END
					END
			End
	END
	PRINT ''Add New''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertChuHoSoCapGCNCQNNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100201
-- Description:	Thêm chủ sử Hồ sơ cấp GCN vào bảng tblChu và
-- bảng tblChuHoSoCapGCN theo Mã hồ sơ cấp GCN
-- Ứng với các Chủ sử dụng thuộc nhóm Cơ quan nhà nước
-- =============================================
CREATE PROCEDURE [dbo].[spInsertChuHoSoCapGCNCQNNByMaHoSoCapGCN] 
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT  = NULL
	,@MaChu BIGINT = NULL
	,@DoiTuongSDD NVARCHAR(100) = NULL
	,@HoTen NVARCHAR(200) = NULL
	,@DiaChi NVARCHAR(200) = NULL
	,@Dat NVARCHAR(50) = NULL
	,@NhaO NVARCHAR(50) = NULL
	,@CongTrinhXayDung NVARCHAR(50) = NULL
	,@RungCay NVARCHAR(50) = NULL
	,@CayLauNam NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @MaChuMoi BIGINT;
	BEGIN TRANSACTION
		SET DATEFORMAT DMY

		IF NOT EXISTS(SELECT DISTINCT MaChu FROM tblChu 
						where DoiTuongSDD = @DoiTuongSDD and HoTen = @HoTen and DiaChi = @DiaChi)
		BEGIN
			--truong hop da ton tai MaChuSuDung trong bang tblChuSuDung
			INSERT INTO tblChu(ThoiDiemKeKhaiDangKy ,DoiTuongSDD
				 ,HoTen ,DiaChi)
			VALUES (GETDATE(),@DoiTuongSDD
				 ,@HoTen ,@DiaChi)
--			SELECT @@IDENTITY AS MaChu2
			SET @MaChuMoi = @@IDENTITY;
			IF (@@ERROR <> 0)
				BEGIN
					ROLLBACK TRANSACTION
					RETURN
				END
			-- Chắc chắn rằng đã sinh ra một Chủ mới
			--(Mã chủ mới > 0)
			IF (@MaChuMoi <= 0 )
				BEGIN
					ROLLBACK TRANSACTION
					RETURN
				END
			ELSE
				BEGIN
					INSERT INTO tblChuHoSoCapGCN 
						(MaHoSoCapGCN,MaChu,Dat,NhaO
							,CongTrinhXayDung,RungCay,CayLauNam)
					VALUES (@MaHoSoCapGCN,@MaChuMoi,@Dat,@NhaO
							,@CongTrinhXayDung,@RungCay,@CayLauNam)
					IF (@@ERROR <> 0)
						BEGIN 
							ROLLBACK TRANSACTION
							RETURN
						END
					ELSE
						BEGIN
							COMMIT TRANSACTION 
						END
				END
		END
		PRINT ''Add New''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertChuDeNghiCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100123
-- Description:	Thêm Chủ đề nghị cấp GCN vào bảng tblChuDeNghiCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spInsertChuDeNghiCapGCN]
	-- Add the parameters for the stored procedure here
	@xml XML
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET DATEFORMAT DMY
	DECLARE @idoc int
	EXEC sp_xml_preparedocument @idoc OUTPUT,@xml
	IF NOT EXISTS 
		(	SELECT CDN.MaHoSoCapGCN,CDN.MaChu
			FROM OPENXML(@idoc,''/root/tblChu'')
			WITH(
					MaHoSoCapGCN bigint ''MaHoSoCapGCN''
					,MaChu bigint ''MaChu''
				) AS xmlTable
			INNER JOIN tblChuDeNghiCapGCN AS CDN ON (CDN.MaHoSoCapGCN = xmlTable.MaHoSoCapGCN)
			WHERE (CDN.MaChu  = xmlTable.MaChu)
		)
		BEGIN
			INSERT INTO tblChuDeNghiCapGCN (MaHoSoCapGCN,MaChu)
			SELECT MaHoSoCapGCN,MaChu
			FROM OPENXML(@idoc,''/root/tblChu'')
			WITH(
					MaHoSoCapGCN bigint ''MaHoSoCapGCN''
					,MaChu bigint ''MaChu''
				) AS xmlTable
		END
	EXEC sp_xml_removedocument @idoc
	PRINT ''Đã thêm mới''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteChuDeNghiCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100125
-- Description:	Xóa Chủ đề nghị cấp GCN vào bảng tblChuDeNghiCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteChuDeNghiCapGCN]
	-- Add the parameters for the stored procedure here
	@xml XML
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET DATEFORMAT DMY
	DECLARE @idoc int
	EXEC sp_xml_preparedocument @idoc OUTPUT,@xml
	DELETE tblChuDeNghiCapGCN
	FROM OPENXML(@idoc,''/root/tblChu'')
	WITH(
			MaHoSoCapGCN bigint ''MaHoSoCapGCN''
			,MaChu bigint ''MaChu''
		) AS xmlTable
	WHERE (tblChuDeNghiCapGCN.MaHoSoCapGCN = xmlTable.MaHoSoCapGCN) 
		AND (tblChuDeNghiCapGCN.MaChu =  xmlTable.MaChu)
	EXEC sp_xml_removedocument @idoc
	PRINT ''Đã thêm mới''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienPhieuThamDinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Date Modified: 20100401
--Create by: Vũ Lê Thành
--Discription: 

CREATE PROC [dbo].[spSelectTuDienPhieuThamDinh]

AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	-- Liệt kê thông tin Từ điển phiếu thẩm định
	SELECT DonViQuanLy,DonViThucHien,LanhDaoDVTH ,ChucVuLanhDaoDVTH
	FROM   tblTuDienPhieuThamDinh
	WHERE  1 = 1
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinCanBoPheDuyetByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[spSelectThongTinCanBoPheDuyetByMaHoSoCapGCN](@MaHoSoCapGCN bigint)
as 

SELECT     dbo.tblHoSoPheDuyet.HoTenCanBoPheDuyet
FROM         dbo.tblChuHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblHoSoPheDuyet ON dbo.tblChuHoSoCapGCN.MaHoSoCapGCN = dbo.tblHoSoPheDuyet.MaHoSoCapGCN
WHERE     (dbo.tblChuHoSoCapGCN.MaHoSoCapGCN = @MaHoSoCapGCN)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteChuHoSoCapGCNCQNNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100201
-- Description:	Xóa chủ Hồ sơ cấp GCN theo Mã hồ sơ cấp GCN
-- thuộc đối tượng Cơ quan nhà nước
-- trong bảng tblChu, tblChuHoSoCapGCN
-- Note: Ở đây ta chỉ xóa trong bảng trung gian
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteChuHoSoCapGCNCQNNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT  = NULL
	,@MaChu BIGINT = NULL
	,@DoiTuongSDD NVARCHAR(100) = NULL
	,@HoTen NVARCHAR(200) = NULL
	,@DiaChi NVARCHAR(200) = NULL
	,@Dat NVARCHAR(50) = NULL
	,@NhaO NVARCHAR(50) = NULL
	,@CongTrinhXayDung NVARCHAR(50) = NULL
	,@RungCay NVARCHAR(50) = NULL
	,@CayLauNam NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN
		-- Xóa chủ Hồ sơ cấp GCN trong bảng trung gian tblChuHoSoCapGCN
		IF  EXISTS (SELECT * FROM tblChuHoSoCapGCN WHERE (MaChu = @MaChu) AND (MaHoSoCapGCN = @MaHoSoCapGCN) )
			BEGIN
				DELETE FROM tblChuHoSoCapGCN
				WHERE (MaChu = @MaChu) AND (MaHoSoCapGCN = @MaHoSoCapGCN)
				Print ''Da xoa''
			END
	END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteChuHoSoCapGCNTCDNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20010201
-- Description:	Xóa chủ Hồ sơ cấp GCN theo Mã hồ sơ cấp GCN
-- thuộc đối tượng Tổ chức, doanh nghiệp
-- trong các bảng tblChu, tblChuHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteChuHoSoCapGCNTCDNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT  = NULL,
	@MaChu BIGINT = NULL,
	--Những biến sau có thể không cần thiết
	@DoiTuongSDD nvarchar (10) = null,
	@HoTen nvarchar (50)= null ,	
	@SoDinhDanh nvarchar (50)= null ,	
	@NgayCap nvarchar(50)= null ,	
	@NoiCap nvarchar (200)= null ,	
	@DiaChi nvarchar (200)= null 
	,@Dat NVARCHAR(50) = NULL
	,@NhaO NVARCHAR(50) = NULL
	,@CongTrinhXayDung NVARCHAR(50) = NULL
	,@RungCay NVARCHAR(50) = NULL
	,@CayLauNam NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN
		-- Xóa chủ Hồ sơ cấp GCN trong bảng trung gian tblChuHoSoCapGCN
		IF  EXISTS (SELECT * FROM tblChuHoSoCapGCN WHERE (MaChu = @MaChu) AND (MaHoSoCapGCN = @MaHoSoCapGCN) )
			BEGIN
				DELETE FROM tblChuHoSoCapGCN
				WHERE (MaChu = @MaChu) AND (MaHoSoCapGCN = @MaHoSoCapGCN)
				Print ''Da xoa''
			END
	END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteChuHoSoCapGCNGDCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20010201
-- Description:	Xóa chủ Hồ sơ cấp GCN theo Mã Hồ sơ cấp GCN
-- thuộc nhóm đối tượng GDCN
-- trong các bảng tblChu, tblChuHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteChuHoSoCapGCNGDCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT  = NULL,
	@MaChu BIGINT = null,
	@QuanHe nvarchar (50) = null ,	
	@GioiTinh nvarchar(50)= null ,
	@HoTen nvarchar (50)= null ,	
	@NamSinh nvarchar(50)= null ,	
	@DiaChi nvarchar (200)= null ,	

	@QuocTich nvarchar (100)= null ,	
	@SoDinhDanh nvarchar (50)= null ,	
	@NgayCap nvarchar(50)= null ,	
	@NoiCap nvarchar (200)= null ,	

	@QuocTich2 nvarchar (100)= null ,	
	@SoDinhDanh2 nvarchar (50)= null ,	
	@NgayCap2 nvarchar(50)= null ,	
	@NoiCap2 nvarchar (200)= null ,	

	@SoHoKhau nvarchar (50)= null ,	
	@NgayCapHoKhau nvarchar(50)= null ,	
	@NoiCapHoKhau nvarchar (200)= null 
	,@Dat NVARCHAR(50) = NULL
	,@NhaO NVARCHAR(50) = NULL
	,@CongTrinhXayDung NVARCHAR(50) = NULL
	,@RungCay NVARCHAR(50) = NULL
	,@CayLauNam NVARCHAR(50) = NULL
	,@DaChet nvarchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	BEGIN
		-- Xóa chủ Hồ sơ cấp GCN trong bảng trung gian tblChuHoSoCapGCN
		IF  EXISTS (SELECT * FROM tblChuHoSoCapGCN WHERE (MaChu = @MaChu) AND (MaHoSoCapGCN = @MaHoSoCapGCN) )
			BEGIN
				DELETE FROM tblChuHoSoCapGCN
				WHERE (MaChu = @MaChu) AND (MaHoSoCapGCN = @MaHoSoCapGCN)
				Print ''Da xoa''
			END
	END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertChuDangKyCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100315
-- Description:	Thêm Chủ đăng ký cấp GCN vào bảng tblChuHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spInsertChuDangKyCapGCN]
	-- Add the parameters for the stored procedure here
	@xml XML
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET DATEFORMAT DMY
	DECLARE @idoc int
	EXEC sp_xml_preparedocument @idoc OUTPUT,@xml
	IF NOT EXISTS 
		(	SELECT CDK.MaHoSoCapGCN,CDK.MaChu
			FROM OPENXML(@idoc,''/root/tblChu'')
			WITH(
					MaHoSoCapGCN bigint ''MaHoSoCapGCN''
					,MaChu bigint ''MaChu''
				) AS xmlTable
			INNER JOIN tblChuHoSoCapGCN AS CDK ON (CDK.MaHoSoCapGCN = xmlTable.MaHoSoCapGCN)
			WHERE (CDK.MaChu  = xmlTable.MaChu)
		)
		BEGIN
			INSERT INTO tblChuHoSoCapGCN (MaHoSoCapGCN,MaChu)
			SELECT MaHoSoCapGCN,MaChu
			FROM OPENXML(@idoc,''/root/tblChu'')
			WITH(
					MaHoSoCapGCN bigint ''MaHoSoCapGCN''
					,MaChu bigint ''MaChu''
				) AS xmlTable
		END
	EXEC sp_xml_removedocument @idoc
	PRINT ''Đã thêm mới''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectCongTrinhXayDungByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100204
-- Description:	Truy vấn thông tin Công trình xây dựng theo 
-- Mã hồ sơ cấp GCN.
-- =============================================
CREATE PROCEDURE [dbo].[spSelectCongTrinhXayDungByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
		@MaCongTrinhXayDung	BIGINT = NULL
		,@MaHoSoCapGCN	BIGINT = NULL
		,@GiayPhep	NVARCHAR(500) = NULL
		,@Ten	NVARCHAR(500) = NULL
		,@MoTa	NVARCHAR(500) = NULL
		,@NguonGoc	NVARCHAR(500) = NULL
		,@DienTichXayDung	NVARCHAR(50) = NULL
		,@HinhThanhTrongTuongLai	NVARCHAR(50) = NULL
		,@ThoiDiemHinhThanh	NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
    -- Insert statements for procedure here
	SELECT *
	FROM tblCongTrinhXayDung 
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateCongTrinhXayDungByMaCongTrinhXayDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100210
-- Description:	Cập nhật thông tin Công trình xây dựng theo 
-- Công trình xây dựng.
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateCongTrinhXayDungByMaCongTrinhXayDung]
	-- Add the parameters for the stored procedure here
		@MaCongTrinhXayDung	BIGINT = NULL
		,@MaHoSoCapGCN	BIGINT = NULL
		,@GiayPhep	NVARCHAR(500) = NULL
		,@Ten	NVARCHAR(500) = NULL
		,@MoTa	NVARCHAR(500) = NULL
		,@NguonGoc	NVARCHAR(500) = NULL
		,@DienTichXayDung	NVARCHAR(50) = NULL
		,@HinhThanhTrongTuongLai	NVARCHAR(50) = NULL
		,@ThoiDiemHinhThanh	NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
    -- Insert statements for procedure here
	UPDATE tblCongTrinhXayDung 
	SET  GiayPhep = @GiayPhep
		,Ten = @Ten
		,MoTa = @MoTa
		,NguonGoc = @NguonGoc
		,DienTichXayDung = CONVERT(FLOAT,@DienTichXayDung)
		,HinhThanhTrongTuongLai = CONVERT(BIT,@HinhThanhTrongTuongLai)
		,ThoiDiemHinhThanh = CONVERT(DATETIME,@ThoiDiemHinhThanh)
	WHERE MaCongTrinhXayDung = @MaCongTrinhXayDung
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteCongTrinhXayDungByMaCongTrinhXayDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100210
-- Description:	Xóa mới thông tin Công trình xây dựng theo 
-- Mã Công trình xây dựng.
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteCongTrinhXayDungByMaCongTrinhXayDung]
	-- Add the parameters for the stored procedure here
		@MaCongTrinhXayDung	BIGINT = NULL
		,@MaHoSoCapGCN	BIGINT = NULL
		,@GiayPhep	NVARCHAR(500) = NULL
		,@Ten	NVARCHAR(500) = NULL
		,@MoTa	NVARCHAR(500) = NULL
		,@NguonGoc	NVARCHAR(500) = NULL
		,@DienTichXayDung	NVARCHAR(50) = NULL
		,@HinhThanhTrongTuongLai	NVARCHAR(50) = NULL
		,@ThoiDiemHinhThanh	NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	DELETE tblCongTrinhXayDung 
	WHERE MaCongTrinhXayDung =  @MaCongTrinhXayDung

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinHangMucCongTrinhDangKyCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100106
-- Description:	Lựa chọn danh sách Công trình xây dựng
-- đăng ký cấp GCN theo Mã Hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinHangMucCongTrinhDangKyCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT HM. *
	FROM tblHangMucCongTrinh AS HM
	INNER JOIN tblCongTrinhXayDung AS CT ON HM.MaCongTrinhXayDung = CT.MaCongTrinhXayDung
	WHERE (CT.MaHoSoCapGCN = @MaHoSoCapGCN)
	PRINT ''Selected''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertCongTrinhXayDungByMaCongTrinhXayDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100210
-- Description:	Thêm mới thông tin Công trình xây dựng theo 
-- Mã Công trình xây dựng.
-- =============================================
CREATE PROCEDURE [dbo].[spInsertCongTrinhXayDungByMaCongTrinhXayDung]
	-- Add the parameters for the stored procedure here
		@MaCongTrinhXayDung	BIGINT = NULL
		,@MaHoSoCapGCN	BIGINT = NULL
		,@GiayPhep	NVARCHAR(500) = NULL
		,@Ten	NVARCHAR(500) = NULL
		,@MoTa	NVARCHAR(500) = NULL
		,@NguonGoc	NVARCHAR(500) = NULL
		,@DienTichXayDung	NVARCHAR(50) = NULL
		,@HinhThanhTrongTuongLai	NVARCHAR(50) = NULL
		,@ThoiDiemHinhThanh	NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
    -- Insert statements for procedure here
	INSERT INTO tblCongTrinhXayDung 
		(MaHoSoCapGCN,GiayPhep,Ten
		,MoTa,NguonGoc,DienTichXayDung
		,HinhThanhTrongTuongLai,ThoiDiemHinhThanh)
		
	VALUES ( CONVERT(BIGINT,@MaHoSoCapGCN),@GiayPhep,@Ten
		,@MoTa,@NguonGoc,CONVERT(FLOAT,@DienTichXayDung)
		,CONVERT(BIT,@HinhThanhTrongTuongLai),CONVERT(DATETIME,@ThoiDiemHinhThanh))

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100114
-- Description:	Xác nhận người dùng theo UserName và Password
-- =============================================
CREATE PROCEDURE [dbo].[spSelectUser]
	-- Add the parameters for the stored procedure here
	@UserName NVARCHAR(50) = NULL,
	@Password NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF EXISTS(SELECT * FROM tblusers WHERE @UserName=tendangnhap AND @Password=matkhau)
		BEGIN
			SELECT m.mausers,m.maquyen, n.quyen
			FROM tblusers m, tbltudienquyendangnhap n 
			WHERE @UserName=m.tendangnhap and @Password=m.matkhau and m.maquyen=n.maquyen
		END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTaiKhoanNguoiDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Created:03/20/2009
--Author:pham xuan chung
CREATE procedure [dbo].[spTaiKhoanNguoiDung]
@flag as int,
@MaUsers as nvarchar(50),
@TenDangNhap as nvarchar(50),
@MaQuyen as int,
@MatKhau as nvarchar(50),
@NgayTaoUser as datetime,
@TenDayDu as nvarchar(50),
@ChucVu as nvarchar(50),
@PhongBan as nvarchar(50),
@DiaChi as nvarchar(200),
@SoDienThoai as nvarchar(50)
 as 
if @flag=0 
		begin
			update tblusers set MatKhau=@MatKhau,TenDayDu=@TenDayDu,ChucVu=@ChucVu,PhongBan=@PhongBan,Diachi=@DiaChi, Sodienthoai=@SoDienThoai where convert(uniqueidentifier,@MaUsers)=MaUsers
		end

if @flag=1 
	begin
		select * from tblTuDienQuyenDangNhap where @MaQuyen=MaQuyen
	end

if @flag=2 
	begin
		select * from tbluserstatus where convert(uniqueidentifier,@MaUsers)=MaUsers
	end

if @flag=3 
		begin 
			select * from tblUsers where @TenDangNhap=TenDangNhap 
		end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTuDienQuyenDangNhap]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 26/03/2009
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spTuDienQuyenDangNhap]
@maquyen nvarchar(50)
AS
BEGIN
select quyen from tbltudienquyendangnhap where @maquyen= maquyen
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinQuyetDinhCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100201
-- Description:	Thêm Quyết định cấp GCN vào bảng tblTuDienQuyetDinhCapGCN và
-- bảng tblHoSoQuyetDinhCapGCN theo Mã hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spInsertThongTinQuyetDinhCapGCNByMaHoSoCapGCN] 
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT = NULL
	,@MaQuyetDinhCapGCN BIGINT = NULL
	,@SoQuyetDinhCapGCN	NVARCHAR(50) = NULL	
	,@NgayQuyetDinhCapGCN	NVARCHAR(50) = NULL
	,@DonViQuyetDinhCapGCN	NVARCHAR(200) = NULL	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @MaQuyetDinhCapGCNMoi BIGINT;
	BEGIN TRANSACTION
		SET DATEFORMAT DMY

		IF NOT EXISTS(SELECT DISTINCT MaQuyetDinhCapGCN FROM tblTuDienQuyetDinhCapGCN
						where SoQuyetDinhCapGCN = @SoQuyetDinhCapGCN and NgayQuyetDinhCapGCN = @NgayQuyetDinhCapGCN and DonViQuyetDinhCapGCN = @DonViQuyetDinhCapGCN)
		BEGIN
			--truong hop da ton tai MaChuSuDung trong bang tblChuSuDung
			INSERT INTO tblTuDienQuyetDinhCapGCN(
				SoQuyetDinhCapGCN	
				,NgayQuyetDinhCapGCN
				,DonViQuyetDinhCapGCN)
			VALUES (
				@SoQuyetDinhCapGCN	
				,@NgayQuyetDinhCapGCN
				,@DonViQuyetDinhCapGCN)
--			SELECT @@IDENTITY AS MaChu2
			SET @MaQuyetDinhCapGCNMoi = @@IDENTITY;
			IF (@@ERROR <> 0)
				BEGIN
					ROLLBACK TRANSACTION
					RETURN
				END
			-- Chắc chắn rằng đã sinh ra một Chủ mới
			--(Mã chủ mới > 0)
			IF (@MaQuyetDinhCapGCNMoi <= 0 )
				BEGIN
					ROLLBACK TRANSACTION
					RETURN
				END
			ELSE
				BEGIN
					INSERT INTO tblHoSoQuyetDinhCapGCN 
						(MaHoSoCapGCN
							,MaQuyetDinhCapGCN)
					VALUES (@MaHoSoCapGCN,@MaQuyetDinhCapGCNMoi)
					IF (@@ERROR <> 0)
						BEGIN 
							ROLLBACK TRANSACTION
							RETURN
						END
					ELSE
						BEGIN
							COMMIT TRANSACTION 
						END
				END
		END
		PRINT ''Add New''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinQuyetDinhCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091217
-- Description:	Cập nhật thông tin Quyết định cấp GCN trong bảng
-- tblTuDienQuyetDinhCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinQuyetDinhCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT = NULL
	,@MaQuyetDinhCapGCN BIGINT = NULL
	,@SoQuyetDinhCapGCN	NVARCHAR(50) = NULL	
	,@NgayQuyetDinhCapGCN	NVARCHAR(50) = NULL
	,@DonViQuyetDinhCapGCN	NVARCHAR(200) = NULL	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
    -- Insert statements for procedure here
	UPDATE tblTuDienQuyetDinhCapGCN
	SET 
		SoQuyetDinhCapGCN = @SoQuyetDinhCapGCN
		,NgayQuyetDinhCapGCN = CONVERT(DATETIME,@NgayQuyetDinhCapGCN)
		,DonViQuyetDinhCapGCN = @DonViQuyetDinhCapGCN
	WHERE MaQuyetDinhCapGCN = @MaQuyetDinhCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinQuyetDinhCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091218
-- Description:	Truy vấn thông tin  Quyết định cấp GCN trong bảng
-- tblHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinQuyetDinhCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT = NULL
	,@MaQuyetDinhCapGCN BIGINT = NULL
	,@SoQuyetDinhCapGCN	NVARCHAR(50) = NULL	
	,@NgayQuyetDinhCapGCN	NVARCHAR(50) = NULL
	,@DonViQuyetDinhCapGCN	NVARCHAR(200) = NULL	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	MaHoSoCapGCN,TDQD.MaQuyetDinhCapGCN,SoQuyetDinhCapGCN,NgayQuyetDinhCapGCN,DonViQuyetDinhCapGCN
	FROM tblHoSoQuyetDinhCapGCN AS HSQD
	INNER JOIN tblTuDienQuyetDinhCapGCN AS TDQD ON TDQD.MaQuyetDinhCapGCN = HSQD.MaQuyetDinhCapGCN
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienTieuDeKyGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100302
-- Description:	Xóa thông tin Tiêu đề ký GCN theo Mã
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteTuDienTieuDeKyGCN]
	-- Add the parameters for the stored procedure here
	@Ma	INT = NULL
	,@TieuDeKyGCN	NVARCHAR(200) = NULL
	,@MoTa	NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	-- Xóa dữ liệu trên bảng Từ điển Tiêu đề ký GCN
	DELETE FROM tblTuDienTieuDeKyGCN
	WHERE Ma = @Ma
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienTieuDeKyGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100302
-- Description:	Cập nhật Từ điển Tiêu đề ký GCN
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateTuDienTieuDeKyGCN]
	-- Add the parameters for the stored procedure here
	@Ma	INT = NULL
	,@TieuDeKyGCN	NVARCHAR(200) = NULL
	,@MoTa	NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	UPDATE tblTuDienTieuDeKyGCN
	SET TieuDeKyGCN=@TieuDeKyGCN
		,MoTa = @MoTa
	WHERE Ma = @Ma
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienTieuDeKyGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100302
-- Description:	Thêm mới Tiêu đề ký GCN
-- =============================================
CREATE PROCEDURE [dbo].[spInsertTuDienTieuDeKyGCN]
	-- Add the parameters for the stored procedure here
	@Ma	INT = NULL
	,@TieuDeKyGCN	NVARCHAR(200) = NULL
	,@MoTa	NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1

    -- Insert statements for procedure here
	IF not exists (SELECT * FROM tblTuDienTieuDeKyGCN
		WHERE Ma = @Ma)
		INSERT INTO tblTuDienTieuDeKyGCN(TieuDeKyGCN,MoTa)
		VALUES (@TieuDeKyGCN,@MoTa)
	ELSE 
		SET @IsExit = 0
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienTieuDeKyGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090907
-- Description:	Lựa chọn Tiêu đề ký GCN trong bảng từ điển Tiêu đề ký GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTuDienTieuDeKyGCN]
	-- Add the parameters for the stored procedure here
	@Ma	INT = NULL
	,@TieuDeKyGCN	NVARCHAR(200) = NULL
	,@MoTa	NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Ma,TieuDeKyGCN,MoTa
	FROM tblTuDienTieuDeKyGCN
	WHERE 1 = 1
	ORDER BY Ma ASC

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DanhSachToaDo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 24/12/2009
-- Description:	xu ly danhs ach toa do (Phan soan ho so thua dat)
-- =============================================
CREATE PROCEDURE [dbo].[sp_DanhSachToaDo]
	@Flag int =null,
	@MaHoSoCapGCN nvarchar(50)=null,
	@SoThuTu nvarchar(50)=null,
	@ToaDoX nvarchar(50)=null,
	@ToaDoY nvarchar(50)=null,
	@HeSoGoc nvarchar(50)=null,
	@ChieuDai nvarchar(50)=null
AS
BEGIN
	if @Flag=1
		begin
			SELECT     SoThuTu, ToaDoX, ToaDoY, HeSoGoc, ChieuDai
			FROM         dbo.tblDanhSachToaDo
			where MaHoSoCapGCN=@MaHoSoCapGCN
		end
	if @Flag=2
		begin
			insert into tblDanhSachToaDo(MaHoSoCapGCN,SoThuTu, ToaDoX, ToaDoY, HeSoGoc, ChieuDai) values(@MaHoSoCapGCN, @SoThuTu, @ToaDoX, @ToaDoY, @HeSoGoc, @ChieuDai)
		end
	if @Flag=3
		begin
			delete from tblDanhSachToaDo 
			where MaHoSoCapGCN=@MaHoSoCapGCN
		end
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertDanhSachToaDoThuaDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 2/12/2009
-- Description:	<ghi danh sach toa do cua thua vao CSDL>(phan soan ho so thua dat)
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertDanhSachToaDoThuaDat]
	@Flag int =null,
	@MaHoSoCapGCN nvarchar(50)=null,
	@MaThuaDat nvarchar (50) = null,
	@SoThuTu nvarchar(50)=null,
	@ToaDoX nvarchar (50)=null,
	@ToaDoY	nvarchar(50)=null,
	@HeSoGoc nvarchar(50) =null,
	@ChieuDai	nvarchar (50)=null
AS
BEGIN
if @flag=1
	begin
		if NOT EXISTS ( select * from tblDanhSachToaDo where MaHoSoCapGCN=@MaHoSoCapGCN and MaTHuaDat =@MaThuaDat and SoThuTu=@SoThuTu and ToaDoX=@ToaDoX and ToaDoy=@ToaDoY and ChieuDai=@ChieuDai)
			begin
					insert into tblDanhSachToaDo values (@MaHoSoCapGCn,@MaThuaDat,@SoThuTu,@ToaDoX,@ToaDoY,@HeSoGoc,@ChieuDai)
			end
		else
			begin
				update tblDanhSachToaDo set SoThuTu=@SoThuTu, ToaDoX =@ToaDoX,ToaDoY =@ToaDoY, HeSoGoc=@HeSoGoc, ChieuDai=@ChieuDai where maHoSoCapGCN=@MaHoSoCapGCN and MaThuaDat=@MaThuaDat
			
			end 
	end
if @Flag =2 
	begin
	 delete from tblDanhSachToaDo where MaHoSoCapGCN=@MaHoSoCapGCN
	end
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectInHoSoKyThuat_DanhSachToaDo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		PhamXuan Chung
-- Create date: <2/12/2009>
-- Description:	insert danh sach toa do vao trong CSDL de de quan ly
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectInHoSoKyThuat_DanhSachToaDo]
	@Flag int =null,
	@MaHoSoCapGCN nvarchar(50)=null
AS
BEGIN
	if @Flag=1
		begin
			SELECT   distinct  MaHoSoCapGCN, MaThuaDat, SoThuTu, ToaDoX, ToaDoY, HeSoGoc, ChieuDai
			FROM         dbo.tblDanhSachToaDo where MahoSoCapGCN=@MaHoSoCapGCN 
		end
	if @Flag=2
		begin
			delete
			FROM         dbo.tblDanhSachToaDo where MahoSoCapGCN=@MaHoSoCapGCN 
		end
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectTongHopChuSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham xuan chung
-- Create date: 1/11/2009
-- Description:	Lay thong tin tong hop chu su dung (Phan cap giay chung nhan)
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectTongHopChuSuDung]
	@MaTongHop nvarchar(50) =null	
as
BEGIN
	SELECT     dbo.tblTuDienTongHopChuSuDungChiTiet.MaTongHop, dbo.tblTuDienTongHopChuSuDungChiTiet.MoTa, 
                      dbo.tblTuDienTongHopChuSuDungChiTiet.GiaTriThemVao
	FROM         dbo.tblTuDienTongHopChuSuDungChiTiet INNER JOIN
                      dbo.tblTuDienTongHopChuSuDung ON dbo.tblTuDienTongHopChuSuDungChiTiet.MaTongHop = dbo.tblTuDienTongHopChuSuDung.MaTongHop
Where tblTuDienTongHopChuSuDungChiTiet.MaTongHop=@MaTongHop
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectToTrinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 10/2/2009
-- Description:	Lay Thong Tin to trinh
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectToTrinh]
	@MaDVHC nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    select MaToTrinhDiaChinh, SoToTrinhDiaChinh, NgayLapToTrinhDiaChinh, DonViLapToTrinhDiaChinh,NgayTrinhDiaChinh from tblTuDienToTrinhDiaChinh Where DVHC=@MaDVHC
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_UpdateToTrinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 10/2/200910
-- Description:	Insert thogn tin vao bang to trinh
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateToTrinh]
	@MaToTrinhDiaChinh nvarchar(20)=null,
	@SoToTrinhDiaChinh nvarchar(50)=null,
	@NgayLapToTrinhDiaChinh	nvarchar(50)=null,
	@DonViLapToTrinhDiaChinh nvarchar(100)=null,
@NgayTrinhDiaChinh nvarchar (100)=null,
	@MaDVHC nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update tblTuDienToTrinhDiaChinh set  SoToTrinhDiaChinh = @SoToTrinhDiaChinh,NgayLapToTrinhDiaChinh = @NgayLapToTrinhDiaChinh,DonViLapToTrinhDiaChinh= @DonViLapToTrinhDiaChinh,NgayTrinhDiaChinh=@NgayTrinhDiaChinh
where MaToTrinhDiaChinh=@MaToTrinhDiaChinh
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_UpdateNhomHoSoTrinhPhuong]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Phạm Xuân Chung
-- Create date: 01/01/2010
-- Description:	Them so to trinh va ngay trinh vao mot mang cac ho so
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateNhomHoSoTrinhPhuong]

	@MaHoSoCapGCN nvarchar(50) = null,
	@SoToTrinhDiaChinh nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
declare @MaToTrinh nvarchar(50)
set @MaToTrinh = (select distinct MaToTrinhDiaChinh from tblTuDienToTrinhDiaChinh where SoToTrinhDiaChinh=@SoToTrinhDiaChinh)
if not exists(select * from tblHoSoTrinhDiaChinh where MaToTrinhDiaChinh=@MaToTrinh and MaHoSoCapGCN=@MaHoSoCapGCN)
	begin
		insert into tblHoSoTrinhDiaChinh(MaToTrinhDiaChinh,MaHoSoCapGCN) values(@MaToTrinh,@MaHoSoCapGCN)
	end
else
	begin
		update tblHoSoTrinhDiaChinh set MaHoSoCapGCN=@MaHoSoCapGCN where MaToTrinhDiaChinh=@MaToTrinh 
	end

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinToTrinhDiaChinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091217
-- Description:	Cập nhật thông tin Tờ trình địa chính trong bảng
-- tblTuDienToTrinhDiaChinh
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinToTrinhDiaChinhByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT
	,@MaToTrinhDiaChinh	BIGINT = NULL
	,@SoToTrinhDiaChinh	NVARCHAR(50) = NULL
	,@NgayLapToTrinhDiaChinh	NVARCHAR(50)  = NULL
	,@DonViLapToTrinhDiaChinh	NVARCHAR(200) = NULL
	,@NgayTrinhDiaChinh	NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
    -- Insert statements for procedure here
	UPDATE tblTuDienToTrinhDiaChinh
	SET 
		SoToTrinhDiaChinh = @SoToTrinhDiaChinh
		,NgayLapToTrinhDiaChinh = CONVERT(DATETIME,@NgayLapToTrinhDiaChinh)
		,DonViLapToTrinhDiaChinh = @DonViLapToTrinhDiaChinh
		,NgayTrinhDiaChinh = CONVERT(DATETIME,@NgayTrinhDiaChinh)
	WHERE MaToTrinhDiaChinh = @MaToTrinhDiaChinh
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertToTrinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 10/2/200910
-- Description:	Insert thogn tin vao bang to trinh
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertToTrinh]
	@MaToTrinhDiaChinh nvarchar(20)=null,
	@SoToTrinhDiaChinh nvarchar(50)=null,
	@NgayLapToTrinhDiaChinh	nvarchar(50)=null,
	@DonViLapToTrinhDiaChinh nvarchar(300)=null,
    @NgayTrinhDiaChinh nvarchar(100)=null,
	@MaDVHC nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into tblTuDienToTrinhDiaChinh ( SoToTrinhDiaChinh, NgayLapToTrinhDiaChinh, DonViLapToTrinhDiaChinh,NgayTrinhDiaChinh, DVHC)
	values ( @SoToTrinhDiaChinh, @NgayLapToTrinhDiaChinh,@DonViLapToTrinhDiaChinh,@NgayTrinhDiaChinh,@MaDVHC)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DeleteToTrinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 10/2/200910
-- Description:	delete thogn tin vao bang to trinh
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteToTrinh]
	@MaToTrinhDiaChinh nvarchar(20)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from  tblTuDienToTrinhDiaChinh 
	Where MaToTrinhDiaChinh=@MaToTrinhDiaChinh
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinToTrinhDiaChinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100201
-- Description:	Thêm Tờ trình địa chính vào bảng tblTuDienToTrinhDiaChinh và
-- bảng tblHoSoTrinhDiaChinh theo Mã hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spInsertThongTinToTrinhDiaChinhByMaHoSoCapGCN] 
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT
	,@MaToTrinhDiaChinh	BIGINT = NULL
	,@SoToTrinhDiaChinh	NVARCHAR(50) = NULL
	,@NgayLapToTrinhDiaChinh	NVARCHAR(50)  = NULL
	,@DonViLapToTrinhDiaChinh	NVARCHAR(200) = NULL
	,@NgayTrinhDiaChinh	NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @MaToTrinhDiaChinhMoi BIGINT;
	BEGIN TRANSACTION
		SET DATEFORMAT DMY

		IF NOT EXISTS(SELECT DISTINCT MaToTrinhDiaChinh FROM tblTuDienToTrinhDiaChinh
						where SoToTrinhDiaChinh = @SoToTrinhDiaChinh and NgayLapToTrinhDiaChinh = @NgayLapToTrinhDiaChinh
						and DonViLapToTrinhDiaChinh = @DonViLapToTrinhDiaChinh AND NgayTrinhDiaChinh = @NgayTrinhDiaChinh)
		BEGIN
			--truong hop da ton tai MaChuSuDung trong bang tblChuSuDung
			INSERT INTO tblTuDienToTrinhDiaChinh(
				SoToTrinhDiaChinh
				,NgayLapToTrinhDiaChinh
				,DonViLapToTrinhDiaChinh
				,NgayTrinhDiaChinh)
			VALUES (
				@SoToTrinhDiaChinh
				,CONVERT(DATETIME,@NgayLapToTrinhDiaChinh)
				,@DonViLapToTrinhDiaChinh
				,CONVERT(DATETIME,@NgayTrinhDiaChinh))
--			SELECT @@IDENTITY AS MaChu2
			SET @MaToTrinhDiaChinhMoi = @@IDENTITY;
			IF (@@ERROR <> 0)
				BEGIN
					ROLLBACK TRANSACTION
					RETURN
				END
			-- Chắc chắn rằng đã sinh ra một Chủ mới
			--(Mã chủ mới > 0)
			IF (@MaToTrinhDiaChinhMoi <= 0 )
				BEGIN
					ROLLBACK TRANSACTION
					RETURN
				END
			ELSE
				BEGIN
					INSERT INTO tblHoSoTrinhDiaChinh
						(MaHoSoCapGCN
							,MaToTrinhDiaChinh)
					VALUES (@MaHoSoCapGCN,@MaToTrinhDiaChinhMoi)
					IF (@@ERROR <> 0)
						BEGIN 
							ROLLBACK TRANSACTION
							RETURN
						END
					ELSE
						BEGIN
							COMMIT TRANSACTION 
						END
				END
		END
		PRINT ''Add New''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinToTrinhDiaChinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091218
-- Description:	Truy vấn thông tin  Tờ trình địa chính trong bảng
-- tblHoSoTrinhDiaChinh và bảng Từ điển Tờ trình địa chính
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinToTrinhDiaChinhByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT
	,@MaToTrinhDiaChinh	BIGINT = NULL
	,@SoToTrinhDiaChinh	NVARCHAR(50) = NULL
	,@NgayLapToTrinhDiaChinh	DATETIME  = NULL
	,@DonViLapToTrinhDiaChinh	NVARCHAR(200) = NULL
	,@NgayTrinhDiaChinh	DATETIME = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		MaHoSoCapGCN,TDTDC.MaToTrinhDiaChinh,SoToTrinhDiaChinh,NgayLapToTrinhDiaChinh
		,DonViLapToTrinhDiaChinh,NgayTrinhDiaChinh
	FROM tblHoSoTrinhDiaChinh AS HSTDC
	INNER JOIN tblTuDienToTrinhDiaChinh AS TDTDC ON TDTDC.MaToTrinhDiaChinh = HSTDC.MaToTrinhDiaChinh
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelect10ThuaDatMoiThaoTac]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[spSelect10ThuaDatMoiThaoTac]
@MaDonViHanhChinh int
as
begin
	select top 10  MaHoSoCapGCN,ToBanDo,SoThua,DienTich,DiaChiDat,MaThuaDat
	from tbl10ThuaDatMoiThaoTac as a
	where a.MaDonViHanhChinh = @MaDonViHanhChinh
	order by ThoiDiem desc
end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsert10ThuaDatMoiThaoTac]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[spInsert10ThuaDatMoiThaoTac] (@MaHoSoCapGCN bigint, @ToBanDo nvarchar(20),@SoThua nvarchar(10),@DienTich float,@DiaChiDat nvarchar(max),@MaThuaDat int,@MaDonViHanhChinh int)
as
insert into tbl10ThuaDatMoiThaoTac(MaHoSoCapGCN,ToBanDo,SoThua,DienTich,DiaChiDat,MaThuaDat,MaDonViHanhChinh)
values(@MaHoSoCapGCN,@ToBanDo,@SoThua,@DienTich,@DiaChiDat,@MaThuaDat,@MaDonViHanhChinh)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTrangThaiHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 23/07/2010
-- Description:	lay thong tin trang thai cap giay chung nhan
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTrangThaiHoSoCapGCN]
	@MaHoSoCapGCN nvarchar(20)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT     dbo.tblHoSoCapGCN.TrangThaiHoSoCapGCN, dbo.tblTuDienTrangThaiCapGCN.MoTa, dbo.tblTuDienTrangThaiCapGCN.R, 
                      dbo.tblTuDienTrangThaiCapGCN.G, dbo.tblTuDienTrangThaiCapGCN.B
FROM         dbo.tblHoSoCapGCN LEFT OUTER JOIN
                      dbo.tblTuDienTrangThaiCapGCN ON dbo.tblHoSoCapGCN.TrangThaiHoSoCapGCN = dbo.tblTuDienTrangThaiCapGCN.GiaTri where tblHoSoCapGCN.MaHoSOCapGCN =@MaHoSoCapGCN
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienLoaiHinhBienDong]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--Ngày hiệu chỉnh: 20100313
--Người tạo: Vũ Lê Thành,
--Mục đích: Select Loại hình biến động
CREATE PROC [dbo].[spSelectTuDienLoaiHinhBienDong]
	@KyHieu NVARCHAR (500)= NULL,
	@MoTa NVARCHAR (500) = NULL,
	@Nhom NVARCHAR (100) = NULL
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
		BEGIN
			SELECT Ma, KyHieu,MoTa,NoiDungGhiSo FROM tblTuDienLoaiHinhBienDong
			WHERE 1 = 1
			AND (CASE @KyHieu
				WHEN '''' THEN @KyHieu  ELSE KyHieu END) = @KyHieu
			ORDER BY KyHieu
		END
	SET NOCOUNT OFF
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienTrangThaiKeKhai]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091228
-- Description:	Truy vấn trạng thái Kê khai
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTuDienTrangThaiKeKhai]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MoTa
	FROM  tblTuDienTrangThaiKeKhai
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinQuiTrinhCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091217
-- Date modified: 20100211
-- Description:	Truy vấn thông tin Qui trình cấp GCN trong bảng
-- tblHoSoCapGCN và bảng tblHoSoThamDinh
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinQuiTrinhCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  
		 HSCGCN.MaHoSoCapGCN,ToTrinhPhuong,NgayTrinhPhuong 
		,NgayThamDinh,ThamDinh.MoTa AS KetQuaThamDinh,NgayPheDuyet 
		,PheDuyet.MoTa AS KetQuaPheDuyet
	FROM tblHoSoCapGCN AS HSCGCN
	INNER JOIN tblHoSoPheDuyet AS HSPD ON  HSPD.MaHoSoCapGCN = HSCGCN.MaHoSoCapGCN
	INNER JOIN tblTuDienTrangThaiPheDuyet AS PheDuyet ON HSPD.KetQuaPheDuyet = PheDuyet.KyHieu
	INNER JOIN tblHoSoThamDinh AS HSTD ON  HSTD.MaHoSoCapGCN = HSCGCN.MaHoSoCapGCN
	INNER JOIN tblTuDienTrangThaiThamDinh AS ThamDinh ON HSTD.KetQuaThamDinh = ThamDinh.KyHieu
	WHERE HSCGCN.MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinPheDuyetByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091222
-- Description:	Truy vấn cơ sở dữ liệu
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinPheDuyetByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoPheDuyet BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@HoTenCanBoPheDuyet nvarchar(50)  = NULL,
	@KetQuaPheDuyet nvarchar (50)  = NULL,
	@NgayPheDuyet nvarchar(50)  = NULL,
	@YKienPheDuyet nvarchar(500)  = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaHoSoPheDuyet,MaHoSoCapGCN,HoTenCanBoPheDuyet
		,KetQuaPheDuyet,TuDien.MoTa AS TrangThaiPheDuyet, NgayPheDuyet,YKienPheDuyet
	FROM tblHoSoPheDuyet
	INNER JOIN tblTuDienTrangThaiPheDuyet  AS TuDien
	ON  TuDien.KyHieu = KetQuaPheDuyet
	WHERE 1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienTrangThaiPheDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091226
-- Description:	Truy vấn trạng thái Phê duyệt
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTuDienTrangThaiPheDuyet]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MoTa
	FROM  tblTuDienTrangThaiPheDuyet
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienTrangThaiThamDinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091228
-- Description:	Truy vấn trạng thái Thẩm định
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTuDienTrangThaiThamDinh]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MoTa
	FROM  tblTuDienTrangThaiThamDinh
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinCanBoThamDinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091221
-- Date modified: 20100211
-- Description:	Truy vấn thông tin Cán bộ thẩm định trong bảng
-- tblHoSoThamDinh theo Mã Hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinCanBoThamDinhByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT
	,@DonViThamDinh NVARCHAR (200) = NULL
	,@HoTenCanBoThamDinh NVARCHAR (200) = NULL
	,@YKienThamDinh NVARCHAR (200) = NULL
	,@KetQuaThamDinh NVARCHAR (50) = NULL
	,@NgayThamDinh  NVARCHAR (50) = NULL
	,@LyDoKhongCap NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT  MaHoSoThamDinh,MaHoSoCapGCN, DonViThamDinh,HoTenCanBoThamDinh,YKienThamDinh
		,KetQuaThamDinh,NgayThamDinh,LyDoKhongCap,TuDien.MoTa AS TrangThaiThamDinh
	FROM tblHoSoThamDinh
	INNER JOIN tblTuDienTrangThaiThamDinh  AS TuDien
	ON  TuDien.KyHieu = KetQuaThamDinh
	WHERE	MaHoSoCapGCN = @MaHoSoCapGCN
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienTrangThaiXetDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091228
-- Description:	Truy vấn trạng thái Xét duyệt
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTuDienTrangThaiXetDuyet]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MoTa
	FROM  tblTuDienTrangThaiXetDuyet
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spThongTinXetDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích:

CREATE PROC [dbo].[spThongTinXetDuyet]
	@flag tinyint = NULL,
	@TrangThaiHoSoCapGCN INT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@ToTrinhPhuong nvarchar (50) =  NULL ,	
	@NgayTrinhPhuong nvarchar(100)=  NULL ,	
	@NgayXetDuyet nvarchar(100)=  NULL ,	
	@KetQuaXetDuyet nvarchar (50)=  NULL ,	
	@CanhBaoTranhChapKhieuKien nvarchar (50)=  NULL ,	
	@NoiDungTranhChapKhieuKien nvarchar (500)=  NULL ,	
	@YKienCanBoXetDuyet nvarchar (200)=  NULL ,
	@LyDoKhongCap nvarchar (200) = NULL -- Mới thêm vào

AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	-- Liet ke Thong tin Xet duyet
	IF @flag = 0 
			BEGIN
				SELECT TrangThaiHoSoCapGCN,MaHoSoCapGCN,ToTrinhPhuong,NgayTrinhPhuong
				,NgayXetDuyet,KetQuaXetDuyet,CanhBaoTranhChapKhieuKien
				,NoiDungTranhChapKhieuKien,YKienCanBoXetDuyet, LyDoKhongCap
				,TuDien.MoTa AS TrangThaiXetDuyet
				FROM  tblHoSoCapGCN
				INNER JOIN tblTuDienTrangThaiXetDuyet  AS TuDien
				ON  TuDien.KyHieu = KetQuaXetDuyet
				WHERE  1 = 1
				AND (CASE @MaHoSoCapGCN
					WHEN '''' THEN @MaHoSoCapGCN ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
			END
	--Cap nhat Thong tin thua Tham dinh trong Ho so cap GCN
	ELSE
		BEGIN
		--Truong hop them Thong tin Tham dinh thua dat trong Ho so cap GCN
		IF @flag = 1
			BEGIN
				SET DATEFORMAT DMY
				IF NOT EXISTS (SELECT MaHoSoCapGCN,ToTrinhPhuong,NgayTrinhPhuong
						 ,NgayXetDuyet,KetQuaXetDuyet,CanhBaoTranhChapKhieuKien
						,NoiDungTranhChapKhieuKien,YKienCanBoXetDuyet, LyDoKhongCap
					FROM tblHoSoCapGCN
					WHERE ( MaHoSoCapGCN = @MaHoSoCapGCN ) )
					BEGIN					
						UPDATE tblHoSoCapGCN
						SET 
							TrangThaiHoSoCapGCN = CONVERT(INT, @TrangThaiHoSoCapGCN	)
							,ToTrinhPhuong  = @ToTrinhPhuong,NgayTrinhPhuong  = CONVERT(DATETIME,@NgayTrinhPhuong),
							NgayXetDuyet = CONVERT(DATETIME,@NgayXetDuyet) ,KetQuaXetDuyet = @KetQuaXetDuyet
							,CanhBaoTranhChapKhieuKien = CONVERT(BIT,@CanhBaoTranhChapKhieuKien)
							,NoiDungTranhChapKhieuKien = @NoiDungTranhChapKhieuKien,YKienCanBoXetDuyet= @YKienCanBoXetDuyet
							,LyDoKhongCap = @LyDoKhongCap
						WHERE MaHoSoCapGCN = @MaHoSoCapGCN
					END
				ELSE 
					SET @IsExit = 0
			END
		--Truong hop cap nhat Thong tin xet duyet 
		IF @flag  = 2
			BEGIN
				SET DATEFORMAT DMY
				UPDATE tblHoSoCapGCN
				SET TrangThaiHoSoCapGCN = CONVERT(INT,@TrangThaiHoSoCapGCN)
					,ToTrinhPhuong  = @ToTrinhPhuong,NgayTrinhPhuong  = CONVERT(DATETIME,@NgayTrinhPhuong)
					,NgayXetDuyet = CONVERT(DATETIME,@NgayXetDuyet) ,KetQuaXetDuyet = @KetQuaXetDuyet 
					,CanhBaoTranhChapKhieuKien = CONVERT(BIT,@CanhBaoTranhChapKhieuKien)
					,NoiDungTranhChapKhieuKien = @NoiDungTranhChapKhieuKien,YKienCanBoXetDuyet= @YKienCanBoXetDuyet
					,LyDoKhongCap = @LyDoKhongCap
				WHERE MaHoSoCapGCN = @MaHoSoCapGCN
			END
		--Truong hop xoa mot ban ghi trong bang Thong tin xet duyet
		IF @flag = 3
			BEGIN	
				SET DATEFORMAT DMY
				UPDATE tblHoSoCapGCN
				SET
					TrangThaiHoSoCapGCN = CONVERT(INT,@TrangThaiHoSoCapGCN)	
					,ToTrinhPhuong  = NULL,NgayTrinhPhuong  = GETDATE()
					,NgayXetDuyet = GETDATE() ,KetQuaXetDuyet = NULL
					,CanhBaoTranhChapKhieuKien = NULL,NoiDungTranhChapKhieuKien = NULL
					,YKienCanBoXetDuyet= NULL, LyDoKhongCap = NULL
				WHERE MaHoSoCapGCN = @MaHoSoCapGCN
			END
		SELECT @IsExit
	END
		SET NOCOUNT OFF
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateDangKyBienDongByMaDangKyBienDong]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--Ngày tạo gần nhất: 200807
--Người tạo: Quách Văn Phong,
--Mục đích: Cập nhật thông tin đăng ký biến động 
--theo Mã đăng ký biến động

CREATE PROC [dbo].[spUpdateDangKyBienDongByMaDangKyBienDong]
	@MaDangKyBienDong BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
@MaThuaDat BIGINT = NULL,
	@MaCoQuanChinhLyGCN NVARCHAR(50) = NULL,
	@ThuTuHoSoBienDong	NVARCHAR(50) = NULL,
	@MaLoaiBienDong NVARCHAR (50) = NULL,
	@ThoiDiemDangKy NVARCHAR(50) = NULL,
	@LoaiThoiHanBienDong NVARCHAR(50) = NULL,
	@NgayBatDau	NVARCHAR(50) = NULL,
	@NgayKetThuc NVARCHAR(50) = NULL,
	@NoidungSoDiaChinh NVARCHAR(500) = NULL,
	@NoidungSoBienDong NVARCHAR(500) = NULL,
	@NoiDungSoMucKe	NVARCHAR(500) = NULL,
	@NoiDungSoCapGCN NVARCHAR(500) = NULL,	
	@NoiDungMatBonGCN NVARCHAR(500) = NULL,
	@TenNguoiDangKy	NVARCHAR(50) = NULL,	
	@SoCMTNguoiDangKy NVARCHAR(50) = NULL,
	@DiaChiNguoiDangKy NVARCHAR(200) = NULL,
	@HoanTatDangKyBienDong NVARCHAR(50) = NULL,
    @Chon NVARCHAR(50)=NULL
AS
	SET NOCOUNT ON
	BEGIN
		SET DATEFORMAT DMY
		UPDATE tblDangKyBienDong
		SET MaCoQuanChinhLyGCN =  @MaCoQuanChinhLyGCN,ThuTuHoSoBienDong= convert(int,@ThuTuHoSoBienDong)
			,MaLoaiBienDong =@MaLoaiBienDong,ThoiDiemDangKy= CONVERT(DATETIME,@ThoiDiemDangKy)
			,LoaiThoiHanBienDong = CONVERT(BIT,@LoaiThoiHanBienDong),NgayBatDau = CONVERT(DATETIME,@NgayBatDau)
			,NgayKetThuc= CONVERT(DATETIME,@NgayKetThuc),TenNguoiDangKy = @TenNguoiDangKy,NoidungSoDiaChinh = @NoidungSoDiaChinh
			,NoidungSoBienDong = @NoidungSoBienDong,NoiDungSoMucKe = @NoiDungSoMucKe,NoiDungSoCapGCN = @NoiDungSoCapGCN
			,NoiDungMatBonGCN = @NoiDungMatBonGCN,SoCMTNguoiDangKy = @SoCMTNguoiDangKy,DiaChiNguoiDangKy = @DiaChiNguoiDangKy
			,HoanTatDangKyBienDong = CONVERT(BIT,@HoanTatDangKyBienDong),Chon=CONVERT(BIT,@Chon),
MaThuaDat =@MaThuaDat
		WHERE MaDangKyBienDong = @MaDangKyBienDong
	END
	SET NOCOUNT OFF
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectDangKyBienDongByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Truy vấn thông tin kê khai đăng ký biến động
-- theo Mã hồ sơ cấp GCN

CREATE PROC [dbo].[spSelectDangKyBienDongByMaHoSoCapGCN]
	@MaDangKyBienDong BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@MaThuaDat BIGINT = NULL,
	@MaCoQuanChinhLyGCN NVARCHAR(50) = NULL,
	@ThuTuHoSoBienDong	NVARCHAR(50) = NULL,
	@MaLoaiBienDong NVARCHAR (50) = NULL,
	@ThoiDiemDangKy NVARCHAR(50) = NULL,
	@LoaiThoiHanBienDong NVARCHAR(50) = NULL,
	@NgayBatDau	NVARCHAR(50) = NULL,
	@NgayKetThuc NVARCHAR(50) = NULL,
	@NoidungSoDiaChinh NVARCHAR(500) = NULL,
	@NoidungSoBienDong NVARCHAR(500) = NULL,
	@NoiDungSoMucKe	NVARCHAR(500) = NULL,
	@NoiDungSoCapGCN NVARCHAR(500) = NULL,	
	@NoiDungMatBonGCN NVARCHAR(500) = NULL,
	@TenNguoiDangKy	NVARCHAR(50) = NULL,	
	@SoCMTNguoiDangKy NVARCHAR(50) = NULL,
	@DiaChiNguoiDangKy NVARCHAR(200) = NULL,
	@HoanTatDangKyBienDong NVARCHAR(50) = NULL,
    @Chon nvarchar(50)=NULL

AS 
	SET NOCOUNT ON
	BEGIN
		SELECT MaDangKyBienDong,MaThuaDat, MaHoSoCapGCN,MaCoQuanChinhLyGCN,ThuTuHoSoBienDong,MaLoaiBienDong,ThoiDiemDangKy,LoaiThoiHanBienDong,NgayBatDau,NgayKetThuc
			,NoidungSoDiaChinh,NoidungSoBienDong,NoiDungSoMucKe,NoiDungSoCapGCN,	NoiDungMatBonGCN
			,TenNguoiDangKy,SoCMTNguoiDangKy,DiaChiNguoiDangKy,HoanTatDangKyBienDong,Chon
		FROM tblDangKyBienDong
		WHERE  1 = 1
		AND(CASE @MaHoSoCapGCN
			WHEN '''' THEN @MaHoSoCapGCN  ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
	END
	SET NOCOUNT OFF

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertDangKyBienDongByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--Ngày tạo gần nhất: 20100406
--Người tạo: Vũ Lê Thành,
--Mục đích: Thêm mới thông tin đăng ký biến động

CREATE PROC [dbo].[spInsertDangKyBienDongByMaHoSoCapGCN]
	@MaDangKyBienDong BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@MaThuaDat BIGINT = NULL,
	@MaCoQuanChinhLyGCN NVARCHAR(50) = NULL,
	@ThuTuHoSoBienDong	NVARCHAR(50) = NULL,
	@MaLoaiBienDong NVARCHAR (50) = NULL,
	@ThoiDiemDangKy NVARCHAR(50) = NULL,
	@LoaiThoiHanBienDong NVARCHAR(50) = NULL,
	@NgayBatDau	NVARCHAR(50) = NULL,
	@NgayKetThuc NVARCHAR(50) = NULL,
	@NoidungSoDiaChinh NVARCHAR(500) = NULL,
	@NoidungSoBienDong NVARCHAR(500) = NULL,
	@NoiDungSoMucKe	NVARCHAR(500) = NULL,
	@NoiDungSoCapGCN NVARCHAR(500) = NULL,	
	@NoiDungMatBonGCN NVARCHAR(500) = NULL,
	@TenNguoiDangKy	NVARCHAR(50) = NULL,	
	@SoCMTNguoiDangKy NVARCHAR(50) = NULL,
	@DiaChiNguoiDangKy NVARCHAR(200) = NULL,
	@HoanTatDangKyBienDong NVARCHAR(50) = NULL,
    @Chon NVARCHAR(50)=NULL
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	BEGIN
			SET DATEFORMAT DMY
--			IF NOT EXISTS (SELECT MaHoSoCapGCN,MaCoQuanChinhLyGCN,ThuTuHoSoBienDong
--				,MaLoaiBienDong,ThoiDiemDangKy,LoaiThoiHanBienDong,NgayBatDau,NgayKetThuc
--				,TenNguoiDangKy,SoCMTNguoiDangKy,DiaChiNguoiDangKy,HoanTatDangKyBienDong
--				FROM tblDangKyBienDong
--				WHERE MaHoSoCapGCN = @MaHoSoCapGCN )
				BEGIN			
					INSERT INTO tblDangKyBienDong(MaThuaDat,MaHoSoCapGCN,MaCoQuanChinhLyGCN,ThuTuHoSoBienDong
						,MaLoaiBienDong,ThoiDiemDangKy,LoaiThoiHanBienDong, NgayBatDau,NgayKetThuc
						,NoidungSoDiaChinh,NoidungSoBienDong,NoiDungSoMucKe,NoiDungSoCapGCN
						,NoiDungMatBonGCN,TenNguoiDangKy,SoCMTNguoiDangKy,DiaChiNguoiDangKy
						,HoanTatDangKyBienDong,Chon)
					VALUES(CONVERT(BIGINT,@MaThuaDat),CONVERT(BIGINT,@MaHoSoCapGCN),@MaCoQuanChinhLyGCN,CONVERT(INT,@ThuTuHoSoBienDong)
						,@MaLoaiBienDong,CONVERT(DATETIME,@ThoiDiemDangKy),CONVERT(BIT,@LoaiThoiHanBienDong)
						,CONVERT(DATETIME,@NgayBatDau),CONVERT(DATETIME,@NgayKetThuc),@NoidungSoDiaChinh
						,@NoidungSoBienDong,@NoiDungSoMucKe,@NoiDungSoCapGCN,@NoiDungMatBonGCN
						,@TenNguoiDangKy,@SoCMTNguoiDangKy,@DiaChiNguoiDangKy,CONVERT(BIT,@HoanTatDangKyBienDong),CONVERT(BIT,@Chon))
				END
--			ELSE
--				SET @IsExit = 0
	END
	SET NOCOUNT OFF
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertDangKyBienDong]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Thêm mới thông tin đăng ký biến động

CREATE PROC [dbo].[spInsertDangKyBienDong]
	@MaDangKyBienDong BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@MaThuaDat BIGINT = NULL,
	@MaCoQuanChinhLyGCN NVARCHAR(50) = NULL,
	@ThuTuHoSoBienDong	NVARCHAR(50) = NULL,
	@MaLoaiBienDong NVARCHAR (50) = NULL,
	@ThoiDiemDangKy NVARCHAR(50) = NULL,
	@LoaiThoiHanBienDong NVARCHAR(50) = NULL,
	@NgayBatDau	NVARCHAR(50) = NULL,
	@NgayKetThuc NVARCHAR(50) = NULL,
	@NoidungSoDiaChinh NVARCHAR(500) = NULL,
	@NoidungSoBienDong NVARCHAR(500) = NULL,
	@NoiDungSoMucKe	NVARCHAR(500) = NULL,
	@NoiDungSoCapGCN NVARCHAR(500) = NULL,	
	@NoiDungMatBonGCN NVARCHAR(500) = NULL,
	@TenNguoiDangKy	NVARCHAR(50) = NULL,	
	@SoCMTNguoiDangKy NVARCHAR(50) = NULL,
	@DiaChiNguoiDangKy NVARCHAR(200) = NULL,
	@HoanTatDangKyBienDong NVARCHAR(50) = NULL
	
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	BEGIN
			SET DATEFORMAT DMY
			IF NOT EXISTS (SELECT MaThuaDat,MaHoSoCapGCN,MaCoQuanChinhLyGCN,ThuTuHoSoBienDong
				,MaLoaiBienDong,ThoiDiemDangKy,LoaiThoiHanBienDong,NgayBatDau,NgayKetThuc
				,TenNguoiDangKy,SoCMTNguoiDangKy,DiaChiNguoiDangKy,HoanTatDangKyBienDong
				FROM tblDangKyBienDong
				WHERE MaHoSoCapGCN = @MaHoSoCapGCN )
				BEGIN			
					INSERT INTO tblDangKyBienDong(MaThuaDat,MaHoSoCapGCN,MaCoQuanChinhLyGCN,ThuTuHoSoBienDong
						,MaLoaiBienDong,ThoiDiemDangKy,LoaiThoiHanBienDong, NgayBatDau,NgayKetThuc
						,NoidungSoDiaChinh,NoidungSoBienDong,NoiDungSoMucKe,NoiDungSoCapGCN
						,NoiDungMatBonGCN,TenNguoiDangKy,SoCMTNguoiDangKy,DiaChiNguoiDangKy
						,HoanTatDangKyBienDong)
					VALUES(CONVERT(BIGINT,@MaThuaDat),CONVERT(BIGINT,@MaHoSoCapGCN),@MaCoQuanChinhLyGCN,CONVERT(INT,@ThuTuHoSoBienDong)
						,@MaLoaiBienDong,CONVERT(DATETIME,@ThoiDiemDangKy),CONVERT(BIT,@LoaiThoiHanBienDong)
						,CONVERT(DATETIME,@NgayBatDau),CONVERT(DATETIME,@NgayKetThuc),@NoidungSoDiaChinh
						,@NoidungSoBienDong,@NoiDungSoMucKe,@NoiDungSoCapGCN,@NoiDungMatBonGCN
						,@TenNguoiDangKy,@SoCMTNguoiDangKy,@DiaChiNguoiDangKy,CONVERT(BIT,@HoanTatDangKyBienDong))
				END
			ELSE
				SET @IsExit = 0
	END
	SET NOCOUNT OFF

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteDangKyBienDongByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Xóa thông tin đăng ký biến động theo
--Mã Hồ sơ cấp GCN

CREATE PROC [dbo].[spDeleteDangKyBienDongByMaHoSoCapGCN]
	@MaDangKyBienDong BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@MaThuaDat BIGINT = NULL,
	@MaCoQuanChinhLyGCN NVARCHAR(50) = NULL,
	@ThuTuHoSoBienDong	NVARCHAR(50) = NULL,
	@MaLoaiBienDong NVARCHAR (50) = NULL,
	@ThoiDiemDangKy NVARCHAR(50) = NULL,
	@LoaiThoiHanBienDong NVARCHAR(50) = NULL,
	@NgayBatDau	NVARCHAR(50) = NULL,
	@NgayKetThuc NVARCHAR(50) = NULL,
	@NoidungSoDiaChinh NVARCHAR(500) = NULL,
	@NoidungSoBienDong NVARCHAR(500) = NULL,
	@NoiDungSoMucKe	NVARCHAR(500) = NULL,
	@NoiDungSoCapGCN NVARCHAR(500) = NULL,	
	@NoiDungMatBonGCN NVARCHAR(500) = NULL,
	@TenNguoiDangKy	NVARCHAR(50) = NULL,	
	@SoCMTNguoiDangKy NVARCHAR(50) = NULL,
	@DiaChiNguoiDangKy NVARCHAR(200) = NULL,
	@HoanTatDangKyBienDong NVARCHAR(50) = NULL
AS
	SET NOCOUNT ON
	BEGIN
		DELETE FROM tblDangKyBienDong
		WHERE MaHoSoCapGCN = @MaHoSoCapGCN
	END
	SET NOCOUNT OFF
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteDangKyBienDongByMaDangKyBienDong]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--Ngày tạo gần nhất: 20100412
--Người tạo: Quách Văn Phong,
--Mục đích: Xóa thông tin đăng ký biến động theo
--Mã đăng ký biến động

CREATE PROC [dbo].[spDeleteDangKyBienDongByMaDangKyBienDong]
	@MaDangKyBienDong BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@MaThuaDat BIGINT = NULL,
	@MaCoQuanChinhLyGCN NVARCHAR(50) = NULL,
	@ThuTuHoSoBienDong	NVARCHAR(50) = NULL,
	@MaLoaiBienDong NVARCHAR (50) = NULL,
	@ThoiDiemDangKy NVARCHAR(50) = NULL,
	@LoaiThoiHanBienDong NVARCHAR(50) = NULL,
	@NgayBatDau	NVARCHAR(50) = NULL,
	@NgayKetThuc NVARCHAR(50) = NULL,
	@NoidungSoDiaChinh NVARCHAR(500) = NULL,
	@NoidungSoBienDong NVARCHAR(500) = NULL,
	@NoiDungSoMucKe	NVARCHAR(500) = NULL,
	@NoiDungSoCapGCN NVARCHAR(500) = NULL,	
	@NoiDungMatBonGCN NVARCHAR(500) = NULL,
	@TenNguoiDangKy	NVARCHAR(50) = NULL,	
	@SoCMTNguoiDangKy NVARCHAR(50) = NULL,
	@DiaChiNguoiDangKy NVARCHAR(200) = NULL,
	@HoanTatDangKyBienDong NVARCHAR(50) = NULL,
    @Chon NVARCHAR(50)=NULL
AS
	SET NOCOUNT ON
	BEGIN
		DELETE FROM tblDangKyBienDong
		WHERE MaDangKyBienDong = @MaDangKyBienDong
	END
	SET NOCOUNT OFF
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserChucNang]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Created:03/20/2009
--Author:Pham Xuan CHung
--Thuc hien mot so chuc nang trong viec phan quyen
CREATE procedure [dbo].[spUserChucNang]
@flag int,
@MaUsers as nvarchar(50)=null,
@iMaChucNang as int = null,
@dNgayPhanChucNang as datetime = null,
@TenDangNhap as nvarchar(50) =null
as 
		if @flag=0
			begin
				insert into dbo.tblUserChucNang
				values(
					newid(),
					convert(uniqueidentifier,@mausers),
					@iMaChucNang,
					getdate())
			end

		if @flag=1
			begin
				select * from tbluserchucnang where Mausers in (select mausers from tblusers where @TenDangNhap= tendangnhap)
			end

		if @flag=2
			begin
				insert into tbluserchucnang values(newid(),@MaUsers,@iMaChucNang,getdate())
			end

		if @flag=3
			begin
				delete tblUserChucNang where convert(uniqueidentifier,@MaUsers) = MaUsers and @iMaChucNang = iMaChucNang
			end

		if @flag=4
			begin
				delete tbluserchucnang where MaUsers in(select MaUsers from tblusers where @TenDangNhap=tendangnhap)
			end

		if @flag=5
			begin	
			declare @us nvarchar (50) 
			set @us=(select Mausers from tblUsers where @TenDangNhap=TenDangNhap)
				select * from tbluserchucnang where convert(uniqueidentifier, @us)=Mausers
			end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChucNangByMaNguoiDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100114
-- Description:	Liệt kê các chức năng mà 
-- người dùng có thể tác nghiệp theo Mã người dùng
-- =============================================
CREATE PROCEDURE [dbo].[spSelectChucNangByMaNguoiDung]
	-- Add the parameters for the stored procedure here
		@MaNguoiDung NVARCHAR(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT * 
	FROM tbluserchucnang
	WHERE @MaNguoiDung = MaUsers
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procUserStatus_add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Created:03/20/2009
--Author:Pham xuan chung
--thuc hien mot so chuc nang trong dieu khien phan quyen
CREATE procedure [dbo].[procUserStatus_add]
@flag int,
@MaUserStatus as uniqueidentifier,
@MaUsers as uniqueidentifier,
@MaDonViHanhChinh as int,
@NgayPhanQuyen as datetime,
@TenDangNhap as nvarchar(50)
 as 
	if @flag=0 
		begin	
			select mausers from tblusers where @TenDangNhap=tendangnhap
			select @MaUsers as Mausers
			select * from tbluserstatus where @mausers=Mausers
		end
	if @flag=1
		begin
			insert into tbluserstatus values(newid(),@MaUsers,@MaDonViHanhChinh,getdate())
		end
	if @flag=2 
		begin
			delete tbluserstatus where @MaUsers= MaUsers and @MaDonViHanhChinh=madonvihanhchinh
		end
	if @flag=3
		begin
			select mausers from tblusers where @TenDangNhap=tendangnhap
			select @MaUsers as MaUsers
			delete tbluserstatus where @MaUsers= MaUsers
		end
	if @flag=4
		begin	
			select * from tbluserstatus where @mausers=Mausers
		end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pro_AddUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[pro_AddUser]
@Flag int =null,
@NguoiQuanLy nvarchar(50)=null,
@TenDangNhap nvarchar(50)=null,
@MaQuyen int=null,
 @MatKhau nvarchar(50)=null,
@Tendaydu nvarchar(50)=null,
@Chucvu nvarchar(50)=null,
@Phongban nvarchar(50)=null,
@Diachi nvarchar(50)=null,
@Sodienthoai nvarchar(50)=null,
@Mausers uniqueidentifier output 
as 
if @Flag=0
Begin
	declare @QuanLy nvarchar(50)
	set @QuanLy= (select MaUsers from tblusers where TenDangNhap= @NguoiQuanLy)
	insert into tblusers values ( newid(),@TenDangNhap,@MaQuyen,@QuanLy,@MatKhau,getdate(),@Tendaydu,@Chucvu ,@Phongban,@Diachi,@Sodienthoai)
	select @mausers=mausers from tblusers where tendangnhap=@tendangnhap
end
if @Flag=1
begin
	select * from tblusers where tendangnhap=@tendangnhap and MatKhau = @MatKhau
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proc_KiemTraSuTonTai]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[Proc_KiemTraSuTonTai]
@TenDangNhap nvarchar(50),
@Result int output
as
begin
	if exists(select * from tblusers where @tendangnhap=tendangnhap)
	     set @result=1
	else
	     set @result=0
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUsers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Created:03/20/2009
--Author:Pham Xuan Chung
-- Thuc hien mot so chuc nang trong dieu khien phan quyen
CREATE procedure [dbo].[spUsers]
@flag int,
@MaUsers as nvarchar(50)=null,
@TenDangNhap as nvarchar(50)=null,
@MaQuyen as int=null,
@NguoiQuanLy as nvarchar(50)=null,
@MatKhau as nvarchar(50)=null,
@NgayTaoUser as datetime=null,
@TenDayDu as nvarchar(50)=null,
@ChucVu as nvarchar(50)=null,
@PhongBan as nvarchar(50)=null,
@DiaChi as nvarchar(200)=null,
@SoDienThoai as nvarchar(50)=null
 as 
		if @flag=0 
			begin
				update tblusers set tendaydu=@TenDayDu,chucvu=@ChucVu,phongban=@PhongBan,diachi=@DiaChi,sodienthoai=@SoDienThoai,MatKhau=@MatKhau where @TenDangNhap = tendangnhap
					end
		if @flag=1
			begin
				delete tblusers where @TenDangNhap = tendangnhap
			end
		if @flag=2
			begin
				select * from tblusers where @TenDangNhap = tendangnhap
			end
		if @flag=3
			begin	
			
				select TenDangNhap,NgayTaoUser,TenDayDU, ChucVu, PhongBan, DiaChi, SoDienThoai from tblusers where @MaQuyen = maquyen and  NguoiQuanLy=(select Mausers from tblUsers where @NguoiQuanLy=TenDangNhap)
			
			end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Created:03/20/2009
--Author:Pham xuan chung
--thuc hien mot so chuc nang trong dieu khien phan quyen
CREATE procedure [dbo].[spUserStatus]

@flag int,
@MaUsers as nvarchar(50)=null,
@MaDonViHanhChinh as int=null,
@NgayPhanQuyen as datetime=null,
@TenDangNhap as nvarchar(50)=null
 as 
	if @flag=0 
		begin	
			select * from tbluserstatus where Mausers in (select mausers from tblusers where @TenDangNhap=tendangnhap)
		end
	if @flag=1
		begin
			insert into tbluserstatus values(newid(),convert(uniqueidentifier,@MaUsers),@MaDonViHanhChinh,getdate())
		end
	if @flag=2 
		begin
			delete tbluserstatus where convert(uniqueidentifier,@MaUsers)= MaUsers and @MaDonViHanhChinh=madonvihanhchinh
		end
	if @flag=3
		begin
			delete tbluserstatus where MaUsers in (select mausers from tblusers where @TenDangNhap=tendangnhap)
		end
	if @flag=4
		begin	
		declare @us nvarchar (50) 
		set @us=(select Mausers from tblUsers where @TenDangNhap=TenDangNhap)
			select * from tbluserstatus where convert(uniqueidentifier, @us)=Mausers
		end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pro_AddUserStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[pro_AddUserStatus]
@Mausers nvarchar(50),
@MaDVHC int
as 
Begin
	insert into tbluserstatus values ( newid(),convert(uniqueidentifier,@mausers),@Madvhc,getdate())
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinBoXung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: INSERT tblYeuCauBoXung ( Thong tin bo xung)
CREATE PROC [dbo].[spInsertThongTinBoXung]
	@MaYeuCauBoXung	NVARCHAR (50) = NULL,
	@MaHoSoCapGCN	BIGINT = NULL,
	@SoCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NgayCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NoiDungYeuCauBoXung	NVARCHAR (200) = NULL,
	@ThoiHanYeuCauBoXung	NVARCHAR (50) = NULL ,
	@YeuCauBoXungTuNgay	NVARCHAR (50) = NULL,
	@SoCongVanBoXung	NVARCHAR (50) = NULL ,
	@NgayCongVanBoXung	 NVARCHAR (50) =NULL ,
	@NoiDungBoXung	NVARCHAR(200)  =NULL,
	@NgayBoXung	NVARCHAR(50) =NULL,
	@HoanTatBoXung	NVARCHAR(50) = NULL
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	BEGIN
		SET DATEFORMAT DMY
		SET @MaYeuCauBoXung = NEWID()	
		IF NOT EXISTS (SELECT * FROM tblYeuCauBoXung WHERE (MaYeuCauBoXung = @MaYeuCauBoXung))
			BEGIN
				INSERT INTO tblYeuCauBoXung(MaYeuCauBoXung,MaHoSoCapGCN
					,SoCongVanBoXung,NgayCongVanBoXung,NoiDungBoXung,NgayBoXung,HoanTatBoXung)
				VALUES (CONVERT(UNIQUEIDENTIFIER,@MaYeuCauBoXung),CONVERT(BIGINT,@MaHoSoCapGCN) 
					,@SoCongVanBoXung,CONVERT(DATETIME,@NgayCongVanBoXung)
					,@NoiDungBoXung,CONVERT(DATETIME,@NgayBoXung),CONVERT(BIT,@HoanTatBoXung))
			END
		ELSE
			SET @IsExit = 0
	END
	SELECT @IsExit
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectYeuCauBoXung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: SELECT tblYeuCauBoXung ( Yeu cau bo xung)
CREATE PROC [dbo].[spSelectYeuCauBoXung]
	@MaYeuCauBoXung	NVARCHAR (50) = NULL,
	@MaHoSoCapGCN	BIGINT = NULL,
	@SoCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NgayCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NoiDungYeuCauBoXung	NVARCHAR (200) = NULL,
	@ThoiHanYeuCauBoXung	NVARCHAR (50) = NULL ,
	@YeuCauBoXungTuNgay	NVARCHAR (50) = NULL,
	@SoCongVanBoXung	NVARCHAR (50) = NULL ,
	@NgayCongVanBoXung	 NVARCHAR (50) =NULL ,
	@NoiDungBoXung	NVARCHAR(200)  =NULL,
	@NgayBoXung	NVARCHAR(50) =NULL,
	@HoanTatBoXung	NVARCHAR(50) = NULL
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	-- Liet ke danh sach Bang Ma
	SELECT MaYeuCauBoXung,MaHoSoCapGCN,SoCongVanYeuCauBoXung,NgayCongVanYeuCauBoXung
	,NoiDungYeuCauBoXung,ThoiHanYeuCauBoXung,YeuCauBoXungTuNgay,SoCongVanBoXung
	,NgayCongVanBoXung,NoiDungBoXung,NgayBoXung,HoanTatBoXung
	FROM tblYeuCauBoXung
	WHERE 1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN  ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
	
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinBoXung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Cập nhật bảng tblYeuCauBoXung (Thong tin bo xung)
CREATE PROC [dbo].[spUpdateThongTinBoXung]
	@MaYeuCauBoXung	NVARCHAR (50) = NULL,
	@MaHoSoCapGCN	BIGINT = NULL,
	@SoCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NgayCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NoiDungYeuCauBoXung	NVARCHAR (200) = NULL,
	@ThoiHanYeuCauBoXung	NVARCHAR (50) = NULL ,
	@YeuCauBoXungTuNgay	NVARCHAR (50) = NULL,
	@SoCongVanBoXung	NVARCHAR (50) = NULL ,
	@NgayCongVanBoXung	 NVARCHAR (50) =NULL ,
	@NoiDungBoXung	NVARCHAR(200)  =NULL,
	@NgayBoXung	NVARCHAR(50) =NULL,
	@HoanTatBoXung	NVARCHAR(50) = NULL
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	BEGIN	
		SET DATEFORMAT DMY
		UPDATE tblYeuCauBoXung
		SET MaYeuCauBoXung =  CONVERT(UNIQUEIDENTIFIER, @MaYeuCauBoXung) , MaHoSoCapGCN =  convert (BIGINT,@MaHoSoCapGCN)
			,SoCongVanBoXung =  @SoCongVanBoXung, NgayCongVanBoXung = CONVERT(DATETIME,@NgayCongVanBoXung)
			,NoiDungBoXung =  @NoiDungBoXung, NgayBoXung =  convert(datetime,@NgayBoXung) , HoanTatBoXung = CONVERT(BIT,@HoanTatBoXung)
		WHERE (MaYeuCauBoXung = @MaYeuCauBoXung) 
	END
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertYeuCauBoXung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: INSERT tblYeuCauBoXung ( Yeu cau bo xung)
CREATE PROC [dbo].[spInsertYeuCauBoXung]
	@MaYeuCauBoXung	NVARCHAR (50) = NULL,
	@MaHoSoCapGCN	BIGINT = NULL,
	@SoCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NgayCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NoiDungYeuCauBoXung	NVARCHAR (200) = NULL,
	@ThoiHanYeuCauBoXung	NVARCHAR (50) = NULL ,
	@YeuCauBoXungTuNgay	NVARCHAR (50) = NULL,
	@SoCongVanBoXung	NVARCHAR (50) = NULL ,
	@NgayCongVanBoXung	 NVARCHAR (50) =NULL ,
	@NoiDungBoXung	NVARCHAR(200)  =NULL,
	@NgayBoXung	NVARCHAR(50) =NULL,
	@HoanTatBoXung	NVARCHAR(50) = NULL
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	BEGIN
		SET DATEFORMAT DMY
		SET @MaYeuCauBoXung = NEWID()	
		IF NOT EXISTS (SELECT * FROM tblYeuCauBoXung WHERE (MaYeuCauBoXung = @MaYeuCauBoXung))
			BEGIN
				INSERT INTO tblYeuCauBoXung(MaYeuCauBoXung,MaHoSoCapGCN,SoCongVanYeuCauBoXung,NgayCongVanYeuCauBoXung
					,NoiDungYeuCauBoXung,ThoiHanYeuCauBoXung,YeuCauBoXungTuNgay,SoCongVanBoXung
					,NgayCongVanBoXung,NoiDungBoXung,NgayBoXung,HoanTatBoXung)
				VALUES (CONVERT(UNIQUEIDENTIFIER,@MaYeuCauBoXung),CONVERT(BIGINT,@MaHoSoCapGCN) , @SoCongVanYeuCauBoXung
					,CONVERT(DATETIME,@NgayCongVanYeuCauBoXung),@NoiDungYeuCauBoXung,CONVERT(INT,@ThoiHanYeuCauBoXung)
					,CONVERT(DATETIME,@YeuCauBoXungTuNgay), @SoCongVanBoXung,CONVERT(DATETIME,@NgayCongVanBoXung)
					,@NoiDungBoXung,CONVERT(DATETIME,@NgayBoXung),CONVERT(BIT,@HoanTatBoXung))
			END
		ELSE
			SET @IsExit = 0
	END
	SELECT @IsExit
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateYeuCauBoXung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Cập nhật bảng tblYeuCauBoXung ( Yeu cau bo xung)
CREATE PROC [dbo].[spUpdateYeuCauBoXung]
	@MaYeuCauBoXung	NVARCHAR (50) = NULL,
	@MaHoSoCapGCN	BIGINT = NULL,
	@SoCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NgayCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NoiDungYeuCauBoXung	NVARCHAR (200) = NULL,
	@ThoiHanYeuCauBoXung	NVARCHAR (50) = NULL ,
	@YeuCauBoXungTuNgay	NVARCHAR (50) = NULL,
	@SoCongVanBoXung	NVARCHAR (50) = NULL ,
	@NgayCongVanBoXung	 NVARCHAR (50) =NULL ,
	@NoiDungBoXung	NVARCHAR(200)  =NULL,
	@NgayBoXung	NVARCHAR(50) =NULL,
	@HoanTatBoXung	NVARCHAR(50) = NULL
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	BEGIN	
		SET DATEFORMAT DMY
		UPDATE tblYeuCauBoXung
		SET MaYeuCauBoXung =  CONVERT(UNIQUEIDENTIFIER, @MaYeuCauBoXung) , MaHoSoCapGCN =  convert (BIGINT,@MaHoSoCapGCN) , SoCongVanYeuCauBoXung = @SoCongVanYeuCauBoXung
			,NgayCongVanYeuCauBoXung = CONVERT(DATETIME,@NgayCongVanYeuCauBoXung), NoiDungYeuCauBoXung =  @NoiDungYeuCauBoXung, ThoiHanYeuCauBoXung = CONVERT(INT,@ThoiHanYeuCauBoXung)
			,YeuCauBoXungTuNgay = CONVERT(DATETIME,@YeuCauBoXungTuNgay), SoCongVanBoXung =  @SoCongVanBoXung, NgayCongVanBoXung = CONVERT(DATETIME,@NgayCongVanBoXung)
			,NoiDungBoXung =  @NoiDungBoXung, NgayBoXung =  convert(datetime,@NgayBoXung) , HoanTatBoXung = CONVERT(BIT,@HoanTatBoXung)
		WHERE (MaYeuCauBoXung = @MaYeuCauBoXung) 
	END
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spYeuCauBoXung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Cập nhật bảng tblYeuCauBoXung ( Yeu cau bo xung)
CREATE PROC [dbo].[spYeuCauBoXung]
	@Flag  TINYINT,
	@MaYeuCauBoXung	NVARCHAR (50) = NULL,
	@MaHoSoCapGCN	BIGINT = NULL,
	@SoCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NgayCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NoiDungYeuCauBoXung	NVARCHAR (200) = NULL,
	@ThoiHanYeuCauBoXung	NVARCHAR (50) = NULL ,
	@YeuCauBoXungTuNgay	NVARCHAR (50) = NULL,
	@SoCongVanBoXung	NVARCHAR (50) = NULL ,
	@NgayCongVanBoXung	 NVARCHAR (50) =NULL ,
	@NoiDungBoXung	NVARCHAR(200)  =NULL,
	@NgayBoXung	NVARCHAR(50) =NULL,
	@HoanTatBoXung	NVARCHAR(50) = NULL
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	-- Liet ke danh sach Bang Ma
	IF @flag = 0 
		SELECT MaYeuCauBoXung,MaHoSoCapGCN,SoCongVanYeuCauBoXung,NgayCongVanYeuCauBoXung
		,NoiDungYeuCauBoXung,ThoiHanYeuCauBoXung,YeuCauBoXungTuNgay,SoCongVanBoXung
		,NgayCongVanBoXung,NoiDungBoXung,NgayBoXung,HoanTatBoXung
		FROM tblYeuCauBoXung
		WHERE 1 = 1
		AND (case @MaHoSoCapGCN
			when '''' then @MaHoSoCapGCN  else MaHoSoCapGCN end) = @MaHoSoCapGCN
	ELSE 
		BEGIN
		--Truong hop them 
		IF @flag = 1
			BEGIN
				SET DATEFORMAT DMY
				SET @MaYeuCauBoXung = newid()	
				IF NOT EXISTS (select * from tblYeuCauBoXung where (MaYeuCauBoXung = @MaYeuCauBoXung))
					BEGIN
						INSERT INTO tblYeuCauBoXung(MaYeuCauBoXung,MaHoSoCapGCN,SoCongVanYeuCauBoXung,NgayCongVanYeuCauBoXung
							,NoiDungYeuCauBoXung,ThoiHanYeuCauBoXung,YeuCauBoXungTuNgay,SoCongVanBoXung
							,NgayCongVanBoXung,NoiDungBoXung,NgayBoXung,HoanTatBoXung)
						VALUES (	convert (uniqueidentifier, @MaYeuCauBoXung) , convert (BIGINT,@MaHoSoCapGCN) , @SoCongVanYeuCauBoXung
							,convert (datetime,@NgayCongVanYeuCauBoXung),@NoiDungYeuCauBoXung, convert (int,@ThoiHanYeuCauBoXung)
							, convert (datetime,@YeuCauBoXungTuNgay), @SoCongVanBoXung, convert(datetime,@NgayCongVanBoXung)
							,@NoiDungBoXung, convert(datetime,@NgayBoXung) , convert (bit,@HoanTatBoXung))
					END
				ELSE
					SET @IsExit = 0
			END
		--Truong hop cap nhat 
		IF @flag  = 2
			BEGIN	
				SET DATEFORMAT DMY
				UPDATE tblYeuCauBoXung
				SET MaYeuCauBoXung =  convert (uniqueidentifier, @MaYeuCauBoXung) , MaHoSoCapGCN =  convert (BIGINT,@MaHoSoCapGCN) , SoCongVanYeuCauBoXung = @SoCongVanYeuCauBoXung
					, NgayCongVanYeuCauBoXung =  convert (datetime,@NgayCongVanYeuCauBoXung), NoiDungYeuCauBoXung =  @NoiDungYeuCauBoXung, ThoiHanYeuCauBoXung =  convert (int,@ThoiHanYeuCauBoXung)
					, YeuCauBoXungTuNgay =  convert (datetime,@YeuCauBoXungTuNgay), SoCongVanBoXung =  @SoCongVanBoXung, NgayCongVanBoXung = convert(datetime,@NgayCongVanBoXung)
					, NoiDungBoXung =  @NoiDungBoXung, NgayBoXung =  convert(datetime,@NgayBoXung) , HoanTatBoXung = convert (bit,@HoanTatBoXung)
				WHERE (MaYeuCauBoXung = @MaYeuCauBoXung) 
			END
		--Truong hop xoa mot ban ghi voi MaYeuCauBoXung
		IF @flag = 3
			BEGIN
				DELETE FROM tblYeuCauBoXung
				WHERE (MaYeuCauBoXung = @MaYeuCauBoXung)
			END
		--Truong hop xoa nhieu ban ghi voi MaHoSoCapGCN
		IF @flag = 4 
			BEGIN			
				DELETE FROM tblYeuCauBoXung
				WHERE (MaHoSoCapGCN = @MaHoSoCapGCN)
			END
--			set nocount off 
		SELECT @IsExit
	END
	
	set nocount off' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinBoXung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: SELECT tblYeuCauBoXung ( Thong tin bo xung)
CREATE PROC [dbo].[spSelectThongTinBoXung]
	@MaYeuCauBoXung	NVARCHAR (50) = NULL,
	@MaHoSoCapGCN	BIGINT = NULL,
	@SoCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NgayCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NoiDungYeuCauBoXung	NVARCHAR (200) = NULL,
	@ThoiHanYeuCauBoXung	NVARCHAR (50) = NULL ,
	@YeuCauBoXungTuNgay	NVARCHAR (50) = NULL,
	@SoCongVanBoXung	NVARCHAR (50) = NULL ,
	@NgayCongVanBoXung	 NVARCHAR (50) =NULL ,
	@NoiDungBoXung	NVARCHAR(200)  =NULL,
	@NgayBoXung	NVARCHAR(50) =NULL,
	@HoanTatBoXung	NVARCHAR(50) = NULL
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	-- Liet ke danh sach Bang Ma
	SELECT MaYeuCauBoXung,MaHoSoCapGCN,SoCongVanYeuCauBoXung,NgayCongVanYeuCauBoXung
	,NoiDungYeuCauBoXung,ThoiHanYeuCauBoXung,YeuCauBoXungTuNgay,SoCongVanBoXung
	,NgayCongVanBoXung,NoiDungBoXung,NgayBoXung,HoanTatBoXung
	FROM tblYeuCauBoXung
	WHERE 1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN  ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
	
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinBoXungByMaYeuCauBoXung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: DELETE tblYeuCauBoXung BY MaYeuCauBoXung ( Yeu cau bo xung)
CREATE PROC [dbo].[spDeleteThongTinBoXungByMaYeuCauBoXung]
	@MaYeuCauBoXung	NVARCHAR (50) = NULL,
	@MaHoSoCapGCN	BIGINT = NULL,
	@SoCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NgayCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NoiDungYeuCauBoXung	NVARCHAR (200) = NULL,
	@ThoiHanYeuCauBoXung	NVARCHAR (50) = NULL ,
	@YeuCauBoXungTuNgay	NVARCHAR (50) = NULL,
	@SoCongVanBoXung	NVARCHAR (50) = NULL ,
	@NgayCongVanBoXung	 NVARCHAR (50) =NULL ,
	@NoiDungBoXung	NVARCHAR(200)  =NULL,
	@NgayBoXung	NVARCHAR(50) =NULL,
	@HoanTatBoXung	NVARCHAR(50) = NULL
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	BEGIN
		DELETE FROM tblYeuCauBoXung
		WHERE (MaYeuCauBoXung = @MaYeuCauBoXung)
	END
	
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinBoXungByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: DELETE tblYeuCauBoXung BY MaHoSoCapGCN ( Yeu cau bo xung)
CREATE PROC [dbo].[spDeleteThongTinBoXungByMaHoSoCapGCN]
	@MaYeuCauBoXung	NVARCHAR (50) = NULL,
	@MaHoSoCapGCN	BIGINT = NULL,
	@SoCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NgayCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NoiDungYeuCauBoXung	NVARCHAR (200) = NULL,
	@ThoiHanYeuCauBoXung	NVARCHAR (50) = NULL ,
	@YeuCauBoXungTuNgay	NVARCHAR (50) = NULL,
	@SoCongVanBoXung	NVARCHAR (50) = NULL ,
	@NgayCongVanBoXung	 NVARCHAR (50) =NULL ,
	@NoiDungBoXung	NVARCHAR(200)  =NULL,
	@NgayBoXung	NVARCHAR(50) =NULL,
	@HoanTatBoXung	NVARCHAR(50) = NULL
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	BEGIN
		DELETE FROM tblYeuCauBoXung
		WHERE (MaHoSoCapGCN = @MaHoSoCapGCN)
	END
	
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteYeuCauBoXungByMaYeuCauBoXung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: DELETE tblYeuCauBoXung BY MaYeuCauBoXung ( Yeu cau bo xung)
CREATE PROC [dbo].[spDeleteYeuCauBoXungByMaYeuCauBoXung]
	@MaYeuCauBoXung	NVARCHAR (50) = NULL,
	@MaHoSoCapGCN	BIGINT = NULL,
	@SoCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NgayCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NoiDungYeuCauBoXung	NVARCHAR (200) = NULL,
	@ThoiHanYeuCauBoXung	NVARCHAR (50) = NULL ,
	@YeuCauBoXungTuNgay	NVARCHAR (50) = NULL,
	@SoCongVanBoXung	NVARCHAR (50) = NULL ,
	@NgayCongVanBoXung	 NVARCHAR (50) =NULL ,
	@NoiDungBoXung	NVARCHAR(200)  =NULL,
	@NgayBoXung	NVARCHAR(50) =NULL,
	@HoanTatBoXung	NVARCHAR(50) = NULL
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	BEGIN
		DELETE FROM tblYeuCauBoXung
		WHERE (MaYeuCauBoXung = @MaYeuCauBoXung)
	END
	
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteYeuCauBoXungByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: DELETE tblYeuCauBoXung BY MaHoSoCapGCN ( Yeu cau bo xung)
CREATE PROC [dbo].[spDeleteYeuCauBoXungByMaHoSoCapGCN]
	@MaYeuCauBoXung	NVARCHAR (50) = NULL,
	@MaHoSoCapGCN	BIGINT = NULL,
	@SoCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NgayCongVanYeuCauBoXung	NVARCHAR (50) = NULL,
	@NoiDungYeuCauBoXung	NVARCHAR (200) = NULL,
	@ThoiHanYeuCauBoXung	NVARCHAR (50) = NULL ,
	@YeuCauBoXungTuNgay	NVARCHAR (50) = NULL,
	@SoCongVanBoXung	NVARCHAR (50) = NULL ,
	@NgayCongVanBoXung	 NVARCHAR (50) =NULL ,
	@NoiDungBoXung	NVARCHAR(200)  =NULL,
	@NgayBoXung	NVARCHAR(50) =NULL,
	@HoanTatBoXung	NVARCHAR(50) = NULL
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	BEGIN
		DELETE FROM tblYeuCauBoXung
		WHERE (MaHoSoCapGCN = @MaHoSoCapGCN)
	END
	
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGroupFunction]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Created:03/20/2009
--Author:Pham Xuan Chung
--thuc hien mot so chuc nang trong dieu khien phan quyen
CREATE procedure [dbo].[spGroupFunction]
@flag int
 as 
if @flag=0 
	BEGIN
		SELECT * FROM tblGroupFunction
	END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteHangMucCongTrinhByMaCongTrinhXayDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100105
-- Description:	Xóa Hạng mục công trình bởi Mã Công trình xây dựng
-- Cần xem lại Store này để có thể xóa được cả các bảng con
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteHangMucCongTrinhByMaCongTrinhXayDung]
	-- Add the parameters for the stored procedure here
	@MaHangMucCongTrinh	BIGINT = NULL,	
	@MaCongTrinhXayDung	BIGINT = NULL,	
	@TenHangMucCongTrinh	NVARCHAR(500) = NULL,
	@DienTichXayDung	FLOAT =NULL,	
	@CongSuat	NVARCHAR(500) = NULL,	
	@KetCau	NVARCHAR(50)	 = NULL,
	@CapHang	NVARCHAR(50) = NULL,
	@SoTang	FLOAT = NULL,	
	@NamXayDung	INT =NULL,
	@ThoiHanSoHuu	NVARCHAR(500)=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	DELETE from tblHangMucCongTrinh
	--INNER JOIN tblChuSoHuu AS b ON (MaTaiSan = b.MaTaiSan )
	WHERE (MaCongTrinhXayDung = @MaCongTrinhXayDung) 
	SET NOCOUNT OFF

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteHangMucCongTrinhByMaHangMucCongTrinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100105
-- Description:	Xóa Hạng mục công trình bởi Mã Hạng mục công trình
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteHangMucCongTrinhByMaHangMucCongTrinh]
	-- Add the parameters for the stored procedure here
	-- Cần xem lại sự cần thiết của các biến sau để tối ưu hóa
	@MaHangMucCongTrinh	BIGINT = NULL,	
	@MaCongTrinhXayDung	BIGINT = NULL,	
	@TenHangMucCongTrinh	NVARCHAR(500) = NULL,
	@DienTichXayDung	FLOAT =NULL,	
	@CongSuat	NVARCHAR(500) = NULL,	
	@KetCau	NVARCHAR(50)	 = NULL,
	@CapHang	NVARCHAR(50) = NULL,
	@SoTang	FLOAT = NULL,	
	@NamXayDung	INT =NULL,
	@ThoiHanSoHuu	NVARCHAR(500)=NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
--    -- Insert statements for procedure here
--	--Xóa bảng Con
--	DELETE FROM tblChuSoHuu
--	WHERE (MaTaiSan = @MaCongTrinhXayDung)
	--Xóa bảng Cha
	DELETE FROM tblHangMucCongTrinh
	WHERE (MaHangMucCongTrinh = @MaHangMucCongTrinh) 
	SET NOCOUNT OFF
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectHangMucCongTrinhByMaCongTrinhXayDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100105
-- Description:	HIỂN THỊ THÔNG TIN Hạng mục công trình
-- theo Mã Công trình xây dựng
-- =============================================
CREATE PROCEDURE [dbo].[spSelectHangMucCongTrinhByMaCongTrinhXayDung]
	-- Add the parameters for the stored procedure here
	@MaHangMucCongTrinh	BIGINT = NULL,	
	@MaCongTrinhXayDung	BIGINT = NULL,	
	@TenHangMucCongTrinh	NVARCHAR(500) = NULL,
	@DienTichXayDung	FLOAT =NULL,	
	@CongSuat	NVARCHAR(500) = NULL,	
	@KetCau	NVARCHAR(50)	 = NULL,
	@CapHang	NVARCHAR(50) = NULL,
	@SoTang	FLOAT = NULL,	
	@NamXayDung	INT =NULL,
	@ThoiHanSoHuu	NVARCHAR(500)=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaHangMucCongTrinh,MaCongTrinhXayDung,ThoiDiemKeKhaiDangKy,
		TenHangMucCongTrinh,DienTichXayDung,CongSuat,KetCau,CapHang,
		SoTang,NamXayDung,ThoiHanSoHuu
	FROM tblHangMucCongTrinh
	WHERE 1 = 1
	AND (case @MaCongTrinhXayDung
		WHEN '''' THEN @MaCongTrinhXayDung  ELSE MaCongTrinhXayDung END) = @MaCongTrinhXayDung
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertHangMucCongTrinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:	 Vũ Lê Thành
-- Create date: 20100105
-- Description:	Thêm Hạng mục công trình vào hồ sơ cấp GCN

-- =============================================
CREATE PROCEDURE [dbo].[spInsertHangMucCongTrinh]
	-- Add the parameters for the stored procedure here
	@MaHangMucCongTrinh	BIGINT = NULL,	
	@MaCongTrinhXayDung	BIGINT = NULL,	
	@TenHangMucCongTrinh	NVARCHAR(500) = NULL,
	@DienTichXayDung	FLOAT =NULL,	
	@CongSuat	NVARCHAR(500) = NULL,	
	@KetCau	NVARCHAR(50)	 = NULL,
	@CapHang	NVARCHAR(50) = NULL,
	@SoTang	FLOAT = NULL,	
	@NamXayDung	INT =NULL,
	@ThoiHanSoHuu	NVARCHAR(500)=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1
    -- Insert statements for procedure here
	SET DATEFORMAT DMY
	IF NOT EXISTS (SELECT   MaHangMucCongTrinh,MaCongTrinhXayDung,ThoiDiemKeKhaiDangKy,
		TenHangMucCongTrinh,DienTichXayDung,CongSuat,KetCau,CapHang,
		SoTang,NamXayDung,ThoiHanSoHuu
		FROM tblHangMucCongTrinh
		WHERE ( MaHangMucCongTrinh = @MaHangMucCongTrinh) )
		BEGIN					
			INSERT INTO tblHangMucCongTrinh(MaCongTrinhXayDung,ThoiDiemKeKhaiDangKy,
				TenHangMucCongTrinh,DienTichXayDung,CongSuat,KetCau,CapHang,
				SoTang,NamXayDung,ThoiHanSoHuu)
			VALUES (@MaCongTrinhXayDung,GETDATE(),
				@TenHangMucCongTrinh,CONVERT(FLOAT,@DienTichXayDung),@CongSuat
				,@KetCau,@CapHang,@SoTang,CONVERT(INT,@NamXayDung),@ThoiHanSoHuu)
			SET @MaHangMucCongTrinh = @@IDENTITY
			SELECT @MaHangMucCongTrinh as MaHangMucCongTrinh
		END
	ELSE
		SET @IsExit = 0
	SET NOCOUNT OFF
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateHangMucCongTrinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100105
-- Description:	Cập nhật thông tin Hạng mục công trình
-- theo Mã Hạng mục công trình
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateHangMucCongTrinh]
	-- Add the parameters for the stored procedure here
	@MaHangMucCongTrinh	BIGINT = NULL,	
	@MaCongTrinhXayDung	BIGINT = NULL,	
	@TenHangMucCongTrinh	NVARCHAR(500) = NULL,
	@DienTichXayDung	FLOAT =NULL,	
	@CongSuat	NVARCHAR(500) = NULL,	
	@KetCau	NVARCHAR(50)	 = NULL,
	@CapHang	NVARCHAR(50) = NULL,
	@SoTang	FLOAT = NULL,	
	@NamXayDung	INT =NULL,
	@ThoiHanSoHuu	NVARCHAR(500)=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET DATEFORMAT DMY
	UPDATE tblHangMucCongTrinh 
	SET MaCongTrinhXayDung = CONVERT(BIGINT,@MaCongTrinhXayDung),
		ThoiDiemKeKhaiDangKy = GETDATE(),
		TenHangMucCongTrinh = @TenHangMucCongTrinh,
		DienTichXayDung = CONVERT(FLOAT,@DienTichXayDung),
		CongSuat = @CongSuat,
		KetCau = @KetCau,
		CapHang = @CapHang,
		SoTang = @SoTang,
		NamXayDung = CONVERT(INT,@NamXayDung),
		ThoiHanSoHuu = @ThoiHanSoHuu
		WHERE (MaHangMucCongTrinh = @MaHangMucCongTrinh) 
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertHoiDongXetDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090908
-- Description:	Thêm mới Người xét duyệt vào bảng Hội đồng xét duyệt
-- =============================================
CREATE PROCEDURE [dbo].[spInsertHoiDongXetDuyet] 
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT = NULL,
	@MaNguoiXetDuyet INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	IF NOT  EXISTS (SELECT * FROM tblHoiDongXetDuyet WHERE ((MaNguoiXetDuyet = @MaNguoiXetDuyet) AND  (MaHoSoCapGCN=@MaHoSoCapGCN)))
	BEGIN
		INSERT INTO tblHoiDongXetDuyet(MaHoSoCapGCN,MaNguoiXetDuyet)
		VALUES (CONVERT(BIGINT,@MaHoSoCapGCN),CONVERT(INT,@MaNguoiXetDuyet))
	END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteHoiDongXetDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090908
-- Description:	Xóa Người xét duyệt trong bảng Hội đồng xét duyệt
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteHoiDongXetDuyet]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN bigint,
	@MaNguoiXetDuyet nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM tblHoiDongXetDuyet 
	WHERE (MaHoSoCapGCN = @MaHoSoCapGCN) AND (MaNguoiXetDuyet = @MaNguoiXetDuyet)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinPheDuyetByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091222
-- Description:	Xóa thông tin Phê duyệt theo 
-- Mã hồ sơ cấp GCN.
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinPheDuyetByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoPheDuyet BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@HoTenCanBoPheDuyet nvarchar(50)  = NULL,
	@KetQuaPheDuyet nvarchar (50)  = NULL,
	@NgayPheDuyet nvarchar(50)  = NULL,
	@YKienPheDuyet nvarchar(500)  = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM tblHoSoPheDuyet
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinPheDuyetByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091222
-- Description:	Cập nhật thông tin Phê duyệt theo 
-- Mã hồ sơ cấp GCN.
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinPheDuyetByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoPheDuyet BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@HoTenCanBoPheDuyet nvarchar(50)  = NULL,
	@KetQuaPheDuyet nvarchar (50)  = NULL,
	@NgayPheDuyet nvarchar(50)  = NULL,
	@YKienPheDuyet nvarchar(500)  = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
    -- Insert statements for procedure here
	UPDATE tblHoSoPheDuyet
	SET
		HoTenCanBoPheDuyet = @HoTenCanBoPheDuyet
		,KetQuaPheDuyet = @KetQuaPheDuyet
		,NgayPheDuyet = CONVERT(DATETIME,@NgayPheDuyet)
		,YKienPheDuyet = @YKienPheDuyet
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinPheDuyetByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091221
-- Description:	Thêm thông tin Cán bô Phê duyệt vào
-- Hồ sơ Phê duyệt
-- =============================================
CREATE PROCEDURE [dbo].[spInsertThongTinPheDuyetByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoPheDuyet BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@HoTenCanBoPheDuyet nvarchar(50)  = NULL,
	@KetQuaPheDuyet nvarchar (50)  = NULL,
	@NgayPheDuyet nvarchar(50)  = NULL,
	@YKienPheDuyet nvarchar(500)  = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
	INSERT INTO tblHoSoPheDuyet
		(
			MaHoSoCapGCN,
			KetQuaPheDuyet,
			HoTenCanBoPheDuyet,
			NgayPheDuyet,
			YKienPheDuyet
		)
	VALUES 
		(
			@MaHoSoCapGCN,
			@KetQuaPheDuyet,
			@HoTenCanBoPheDuyet,
			@NgayPheDuyet,
			@YKienPheDuyet
		)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinQuyetDinhCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091218
-- Description:	Xóa thông tin quyết định cấp GCN trong bảng
-- tblHoSoQuyetDinhCapGCN.
-- Note: Ở đây ta chỉ xóa bảng trung gian
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinQuyetDinhCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT = NULL
	,@MaQuyetDinhCapGCN BIGINT = NULL
	,@SoQuyetDinhCapGCN	NVARCHAR(50) = NULL	
	,@NgayQuyetDinhCapGCN	NVARCHAR(50) = NULL
	,@DonViQuyetDinhCapGCN	NVARCHAR(200) = NULL	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	IF EXISTS (SELECT * FROM tblHoSoQuyetDinhCapGCN WHERE (MaHoSoCapGCN = @MaHoSoCapGCN) AND (MaQuyetDinhCapGCN = @MaQuyetDinhCapGCN))
	BEGIN
		DELETE FROM tblHoSoQuyetDinhCapGCN
		WHERE (MaHoSoCapGCN = @MaHoSoCapGCN) AND (MaQuyetDinhCapGCN = @MaQuyetDinhCapGCN)
	END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectKetQuaThamDinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất : 20100512
--Người tạo : Quách Văn Phong ,
--Mục đích : Hiển thị thông kết quả thẩm định


CREATE PROCEDURE [dbo].[spSelectKetQuaThamDinh]
@MaHoSoCapGCN bigint=NULL,
@KetQuaThamDinh nvarchar(50) =NULL
AS
  BEGIN
    SELECT KetQuaThamDinh 
    FROM tblHoSoThamDinh
    WHERE MaHoSoCapGCN=@MaHoSoCapGCN AND KetQuaThamDinh=@KetQuaThamDinh
  END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinCanBoThamDinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091221
-- Date modified: 20100211
-- Description:	Xóa thông tin Cán bộ thẩm định trong bảng
-- tblHoSoThamDinh
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinCanBoThamDinhByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT
	,@DonViThamDinh NVARCHAR (200) = NULL
	,@HoTenCanBoThamDinh NVARCHAR (200) = NULL
	,@YKienThamDinh NVARCHAR (200) = NULL
	,@KetQuaThamDinh NVARCHAR (50) = NULL
	,@NgayThamDinh  NVARCHAR (50) = NULL
	,@HoanTatThamDinh NVARCHAR (50) = NULL  
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
	DELETE tblHoSoThamDinh
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinCanBoThamDinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091221
-- Description:	Thêm thông tin Cán bô thẩm định vào
-- Hồ sơ thẩm định
-- =============================================
CREATE PROCEDURE [dbo].[spInsertThongTinCanBoThamDinhByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT
	,@DonViThamDinh NVARCHAR (200) = NULL
	,@HoTenCanBoThamDinh NVARCHAR (200) = NULL
	,@YKienThamDinh NVARCHAR (200) = NULL
	,@KetQuaThamDinh NVARCHAR (50) = NULL
	,@NgayThamDinh  NVARCHAR (50) = NULL
	,@LyDoKhongCap NVARCHAR(500) = NULL -- Mới thêm vào
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
	INSERT INTO tblHoSoThamDinh
		(
			MaHoSoCapGCN
			,DonViThamDinh
			,KetQuaThamDinh
			,HoTenCanBoThamDinh
			,NgayThamDinh
			,YKienThamDinh
			,LyDoKhongCap
		)
	VALUES 
		(
			@MaHoSoCapGCN
			,@DonViThamDinh
			,@KetQuaThamDinh
			,@HoTenCanBoThamDinh
			,@NgayThamDinh
			,@YKienThamDinh
			,@LyDoKhongCap
		)
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinCanBoThamDinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091221
-- Description:	Sửa thông tin Cán bộ thẩm định trong bảng
-- tblHoSoThamDinh

-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinCanBoThamDinhByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT
	,@DonViThamDinh NVARCHAR (200) = NULL
	,@HoTenCanBoThamDinh NVARCHAR (200) = NULL
	,@YKienThamDinh NVARCHAR (200) = NULL
	,@KetQuaThamDinh NVARCHAR (50) = NULL
	,@NgayThamDinh  NVARCHAR (50) = NULL
	,@LyDoKhongCap NVARCHAR(500)=NULL -- Mới thêm vào
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
	UPDATE tblHoSoThamDinh
	SET 
		DonViThamDinh = @DonViThamDinh
		,HoTenCanBoThamDinh = @HoTenCanBoThamDinh
		,YKienThamDinh  = @YKienThamDinh
		,KetQuaThamDinh  = @KetQuaThamDinh
		,NgayThamDinh  = CONVERT(DATETIME,@NgayThamDinh)
		,LyDoKhongCap = @LyDoKhongCap
	WHERE
		MaHoSoCapGCN = @MaHoSoCapGCN
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinTiepNhanByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090910
-- Description:	Cập nhật thông tin tiếp nhận hồ sơ trong bảng
-- tblHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinTiepNhanByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	-- Add the parameters for the stored procedure here
	@MaHoSoTiepNhan BIGINT = NULL
	,@MaHoSoCapGCN BIGINT = NULL
	,@SoHoSoTiepNhan INT = NULL
	,@ThuTuTiepNhan INT = NULL
	,@ThoiDiemTiepNhan NVARCHAR (50) = NULL
	,@NgayNhanDuHoSo NVARCHAR (50) = NULL
	,@NoiNhanHoSo NVARCHAR (500) = NULL
	,@TenNguoiTiepNhan	NVARCHAR(100)	= NULL
	,@TenNguoiDiKeKhai	NVARCHAR(100)	= NULL
	,@CMTNguoiDiKeKhai	NVARCHAR(50)	= NULL
	,@SoDienThoaiNguoiDiKeKhai NVARCHAR(50)	= NULL
	,@DiaChiNguoiDiKeKhai NVARCHAR(200)	= NULL
	,@NguoiVietDon	NVARCHAR(100) = NULL
	,@ThoiDiemVietDon NVARCHAR(50)	= NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
    -- Insert statements for procedure here
	BEGIN
		SET DATEFORMAT DMY
		UPDATE tblHoSoTiepNhan
		SET SoHoSoTiepNhan  = CONVERT(INT,@SoHoSoTiepNhan), ThuTuTiepNhan = CONVERT(INT,@ThuTuTiepNhan)
			,ThoiDiemTiepNhan = CONVERT(DATETIME,@ThoiDiemTiepNhan)
			,NoiNhanHoSo =  @NoiNhanHoSo, NgayNhanDuHoSo = CONVERT(DATETIME,@NgayNhanDuHoSo)
			,TenNguoiTiepNhan = @TenNguoiTiepNhan		
			,TenNguoiDiKeKhai = @TenNguoiDiKeKhai
			,CMTNguoiDiKeKhai = @CMTNguoiDiKeKhai
			,SoDienThoaiNguoiDiKeKhai	=@SoDienThoaiNguoiDiKeKhai
			,DiaChiNguoiDiKeKhai	= @DiaChiNguoiDiKeKhai
			,NguoiVietDon	= @NguoiVietDon
			,ThoiDiemVietDon = CONVERT(DATETIME,@ThoiDiemVietDon)
		WHERE MaHoSoCapGCN = @MaHoSoCapGCN
	END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinTiepNhanByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100211
-- Description:	Thêm thông tin tiếp nhận hồ sơ
-- bởi Mã hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spInsertThongTinTiepNhanByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoTiepNhan BIGINT = NULL
	,@MaHoSoCapGCN BIGINT = NULL
	,@SoHoSoTiepNhan INT = NULL
	,@ThuTuTiepNhan INT = NULL
	,@ThoiDiemTiepNhan NVARCHAR (50) = NULL
	,@NgayNhanDuHoSo NVARCHAR (50) = NULL
	,@NoiNhanHoSo NVARCHAR (500) = NULL
	,@TenNguoiTiepNhan	NVARCHAR(100)	= NULL
	,@TenNguoiDiKeKhai	NVARCHAR(100)	= NULL
	,@CMTNguoiDiKeKhai	NVARCHAR(50)	= NULL
	,@SoDienThoaiNguoiDiKeKhai NVARCHAR(50)	= NULL
	,@DiaChiNguoiDiKeKhai NVARCHAR(200)	= NULL
	,@NguoiVietDon	NVARCHAR(100) = NULL
	,@ThoiDiemVietDon NVARCHAR(50)	= NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET DATEFORMAT DMY
	INSERT INTO tblHoSoTiepNhan 
		( MaHoSoCapGCN
			,SoHoSoTiepNhan
			,ThuTuTiepNhan
			,ThoiDiemTiepNhan
			,NgayNhanDuHoSo
			,NoiNhanHoSo
			,TenNguoiTiepNhan
			,TenNguoiDiKeKhai
			,CMTNguoiDiKeKhai
			,SoDienThoaiNguoiDiKeKhai
			,DiaChiNguoiDiKeKhai
			,NguoiVietDon
			,ThoiDiemVietDon
		)
	VALUES 
		(
			CONVERT(BIGINT,@MaHoSoCapGCN)
			,@SoHoSoTiepNhan
			,@ThuTuTiepNhan
			,CONVERT(DATETIME,@ThoiDiemTiepNhan)
			,CONVERT(DATETIME,@NgayNhanDuHoSo)
			,@NoiNhanHoSo
			,@TenNguoiTiepNhan
			,@TenNguoiDiKeKhai
			,@CMTNguoiDiKeKhai
			,@SoDienThoaiNguoiDiKeKhai
			,@DiaChiNguoiDiKeKhai
			,@NguoiVietDon
			,CONVERT(DATETIME,@ThoiDiemVietDon)
    	 )


END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinTiepNhanByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090910
-- Description:	Xóa thông tin tiếp nhận hồ sơ
-- bởi Mã hồ sơ cấp GCN
-- Khi xóa trong phần này, mọi thông tin hồ sơ cấp GCN sẽ bị xóa hết
-- tblHoSoCapGCN
-- CẦN XEM LẠI THỦ TỤC:Xem có cho phép xóa toàn bộ thông tin không
-- vì trường hợp cán bộ cấp dưới lỡ tay xóa thì mọi thông tin sẽ bị xóa sạch
-- CẦN XEM LẠI TRẠNG THÁI HỒ SƠ CẤP GCN
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinTiepNhanByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoTiepNhan BIGINT = NULL
	,@MaHoSoCapGCN BIGINT = NULL
	,@SoHoSoTiepNhan INT = NULL
	,@ThuTuTiepNhan INT = NULL
	,@ThoiDiemTiepNhan NVARCHAR (50) = NULL
	,@NgayNhanDuHoSo NVARCHAR (50) = NULL
	,@NoiNhanHoSo NVARCHAR (500) = NULL
	,@TenNguoiTiepNhan	NVARCHAR(100)	= NULL
	,@TenNguoiDiKeKhai	NVARCHAR(100)	= NULL
	,@CMTNguoiDiKeKhai	NVARCHAR(50)	= NULL
	,@SoDienThoaiNguoiDiKeKhai NVARCHAR(50)	= NULL
	,@DiaChiNguoiDiKeKhai NVARCHAR(200)	= NULL
	,@NguoiVietDon	NVARCHAR(100)	= NULL
	,@ThoiDiemVietDon NVARCHAR = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM tblHoSoTiepNhan
	WHERE MaHoSoCapGCN = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinTiepNhanHoSoByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090910
-- Date modified: 201400211
-- Description:	Select thông tin tiếp nhận hồ sơ
-- bởi Mã hồ sơ cấp GCN
-- tblHoSoCapGCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinTiepNhanHoSoByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	-- Add the parameters for the stored procedure here
	@MaHoSoTiepNhan BIGINT = NULL
	,@MaHoSoCapGCN BIGINT = NULL
	,@SoHoSoTiepNhan INT = NULL
	,@ThuTuTiepNhan INT = NULL
	,@ThoiDiemTiepNhan NVARCHAR (50) = NULL
	,@NgayNhanDuHoSo NVARCHAR (50) = NULL
	,@NoiNhanHoSo NVARCHAR (500) = NULL
	,@TenNguoiTiepNhan	NVARCHAR(100)	= NULL
	,@TenNguoiDiKeKhai	NVARCHAR(100)	= NULL
	,@CMTNguoiDiKeKhai	NVARCHAR(50)	= NULL
	,@SoDienThoaiNguoiDiKeKhai NVARCHAR(50)	= NULL
	,@DiaChiNguoiDiKeKhai NVARCHAR(200)	= NULL
	,@NguoiVietDon	NVARCHAR(100) = NULL
	,@ThoiDiemVietDon DATETIME	= NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaHoSoTiepNhan,MaHoSoCapGCN,SoHoSoTiepNhan, ThuTuTiepNhan, ThoiDiemTiepNhan, NgayNhanDuHoSo, NoiNhanHoSo
		,TenNguoiTiepNhan,TenNguoiDiKeKhai,CMTNguoiDiKeKhai	
		,SoDienThoaiNguoiDiKeKhai,DiaChiNguoiDiKeKhai,NguoiVietDon,ThoiDiemVietDon
	FROM   tblHoSoTiepNhan
	WHERE  1 = 1
	AND (CASE @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN  ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinToTrinhDiaChinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091218
-- Description:	Xóa thông tin Tờ trình địa chính trong bảng
-- tblHoSoTrinhDiaChinh.
-- Note: Ở đây ta chỉ xóa bảng trung gian
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinToTrinhDiaChinhByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN  BIGINT
	,@MaToTrinhDiaChinh	BIGINT = NULL
	,@SoToTrinhDiaChinh	NVARCHAR(50) = NULL
	,@NgayLapToTrinhDiaChinh	DATETIME  = NULL
	,@DonViLapToTrinhDiaChinh	NVARCHAR(200) = NULL
	,@NgayTrinhDiaChinh	DATETIME = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	IF EXISTS (SELECT * FROM tblHoSoTrinhDiaChinh WHERE (MaHoSoCapGCN = @MaHoSoCapGCN) AND (MaToTrinhDiaChinh = @MaToTrinhDiaChinh))
	BEGIN
		DELETE FROM tblHoSoTrinhDiaChinh
		WHERE (MaHoSoCapGCN = @MaHoSoCapGCN) AND (MaToTrinhDiaChinh = @MaToTrinhDiaChinh)
	END
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_QuanLyLog]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham xuan chung	
-- Create date: 18/12/2008
-- Description:	quan ly log (ghi lai nhat ky nguoi su dung chuong trinh)
-- =============================================
CREATE PROCEDURE [dbo].[sp_QuanLyLog]
	@UserName nvarchar(200)=null,
	@ModulName nvarchar(200)=null,
	@TimeStart nvarchar(50) =null,
	@EndTime nvarchar(50)=null,
	@ActionName nvarchar(200)=null,
	@ObjName nvarchar(200) =null,
	@Mota nvarchar(500)=null
AS
BEGIN
	insert into tblLog values(@UserName,@ModulName,@TimeStart,@EndTime,@ActionName,@ObjName,@Mota)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateMucDich]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Cập nhật bảng tblMucDichSuDungDat ( Muc dich su dung)
CREATE PROC [dbo].[spUpdateMucDich]
	@MaMucDichSuDung NVARCHAR (50) = NULL,
	@MaThuaDatCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR (10) = NULL,
	@KyHieuKiemKe NVARCHAR(50) = NULL,
	@KyHieuQuiHoach NVARCHAR(50) = NULL,
	@ChiTiet NVARCHAR(200) = NULL,
	@DienTichKeKhai NVARCHAR(50) = NULL,
	@DienTichRieng NVARCHAR(50) = NULL,
	@DienTichChung NVARCHAR(50) = NULL,
	@ThoiHan NVARCHAR(500) = NULL,
	@GhiChu NVARCHAR(200) = NULL
AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
		--Truong hop cap nhat Bang Ma
	BEGIN	
		SET DATEFORMAT DMY
		UPDATE tblMucDichSuDungDat
		SET MaThuaDatCapGCN =  CONVERT(BIGINT,@MaThuaDatCapGCN),ThoiDiemKeKhaiDangKy = getdate()
		,KyHieu = @KyHieu,KyHieuKiemKe = @KyHieuKiemKe,KyHieuQuiHoach=@KyHieuQuiHoach,ChiTiet=@ChiTiet
		,DienTichKeKhai=CONVERT(FLOAT,@DienTichKeKhai),DienTichRieng=CONVERT(FLOAT,@DienTichRieng)
		,DienTichChung=CONVERT(FLOAT,@DienTichChung)
		,ThoiHan = @ThoiHan,GhiChu = @GhiChu
		WHERE (MaMucDichSuDung = @MaMucDichSuDung) 
	END

	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertMucDich]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: INSERT tblMucDichSuDungDat ( Muc dich su dung)
CREATE PROC [dbo].[spInsertMucDich]
	@MaMucDichSuDung NVARCHAR (50) = NULL,
	@MaThuaDatCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR (10) = NULL,
	@KyHieuKiemKe NVARCHAR(50) = NULL,
	@KyHieuQuiHoach NVARCHAR(50) = NULL,
	@ChiTiet NVARCHAR(200) = NULL,
	@DienTichKeKhai NVARCHAR(50) = NULL,
	@DienTichRieng NVARCHAR(50) = NULL,
	@DienTichChung NVARCHAR(50) = NULL,
	@ThoiHan NVARCHAR(500) = NULL,
	@GhiChu NVARCHAR(200) = NULL
AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	BEGIN
		SET DATEFORMAT DMY
		SET @MaMucDichSuDung = NEWID()	
		IF NOT EXISTS (SELECT * FROM tblMucDichSuDungDat WHERE (MaMucDichSuDung = @MaMucDichSuDung))
			BEGIN
				INSERT INTO tblMucDichSuDungDat(MaMucDichSuDung, MaThuaDatCapGCN , ThoiDiemKeKhaiDangKy,KyHieu
				,KyHieuKiemKe,KyHieuQuiHoach,ChiTiet,DienTichKeKhai,DienTichRieng,DienTichChung,ThoiHan,GhiChu)
				VALUES (CONVERT(UNIQUEIDENTIFIER,@MaMucDichSuDung),CONVERT(BIGINT,@MaThuaDatCapGCN),GETDATE(),@KyHieu
				,@KyHieuKiemKe,@KyHieuQuiHoach,@ChiTiet,CONVERT(FLOAT,@DienTichKeKhai)
				,CONVERT(FLOAT,@DienTichRieng),CONVERT(FLOAT,@DienTichChung) ,@ThoiHan,@GhiChu)
			END
		ELSE 
			SET @IsExit = 0
	END
	SELECT @IsExit
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteMucDichByMaMucDichSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Cập nhật bảng tblMucDichSuDungDat ( Muc dich su dung)
CREATE PROC [dbo].[spDeleteMucDichByMaMucDichSuDung]
	@MaMucDichSuDung NVARCHAR (50) = NULL,
	@MaThuaDatCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR (10) = NULL,
	@KyHieuKiemKe NVARCHAR(50) = NULL,
	@KyHieuQuiHoach NVARCHAR(50) = NULL,
	@ChiTiet NVARCHAR(200) = NULL,
	@DienTichKeKhai NVARCHAR(50) = NULL,
	@DienTichRieng NVARCHAR(50) = NULL,
	@DienTichChung NVARCHAR(50) = NULL,
	@ThoiHan NVARCHAR(500) = NULL,
	@GhiChu NVARCHAR(200) = NULL
AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	--Truong hop xoa mot ban ghi voi MaMucDichSuDung
	BEGIN
		DELETE FROM tblMucDichSuDungDat
		WHERE (MaMucDichSuDung = @MaMucDichSuDung)
	END

	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteNguonGocSuDungDatByMaThuaDatCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích:	Xóa dữ liệu bảng tblNguonGocSuDungDat ( Nguon goc su dung dat)
-- theo Mã Thửa đất cấp GCN
-- BỞI MÃ HỒ SƠ CÂP GCN
CREATE PROC [dbo].[spDeleteNguonGocSuDungDatByMaThuaDatCapGCN]
	@MaNguonGoc NVARCHAR(100) = NULL,
	@MaThuaDatCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR(10) = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@ChiTiet NVARCHAR(1500) = NULL,
	@GhiChu NVARCHAR(200) = NULL

AS
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
		-- Trường hợp xóa nhiều bản ghi theo Mã thửa đất cấp GCN
	BEGIN
		DELETE FROM tblNguonGocSuDungDat
		WHERE (MaThuaDatCapGCN = @MaThuaDatCapGCN)
	END
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteNguonGocSuDungDatByMaNguonGoc]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: XÓA bảng tblNguonGocSuDungDat BỞI MÃ NGUỒN GỐC
-- SỬ DỤNG ĐẤT ( Nguon goc su dung dat)
CREATE PROC [dbo].[spDeleteNguonGocSuDungDatByMaNguonGoc]
	@MaNguonGoc NVARCHAR(100) = NULL,
	@MaThuaDatCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR(10) = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@ChiTiet NVARCHAR(1500) = NULL,
	@GhiChu NVARCHAR(200) = NULL
AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
		--Truong hop xoa mot bang ghi MaNguonGocSuDung
	BEGIN
		DELETE FROM tblNguonGocSuDungDat
		WHERE (MaNguonGoc = @MaNguonGoc)
	END
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertNguonGocSuDungDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: THÊM MỚI Nguồn gốc sử dụng đất vào 
--bảng tblNguonGocSuDungDat (Nguon goc su dung dat)
CREATE PROC [dbo].[spInsertNguonGocSuDungDat]
	@MaNguonGoc NVARCHAR(100) = NULL,
	@MaThuaDatCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR(10) = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@ChiTiet NVARCHAR(1500) = NULL,
	@GhiChu NVARCHAR(200) = NULL
AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	BEGIN
		SET DATEFORMAT DMY
		SET @MaNguonGoc = NEWID()
		IF NOT EXISTS (SELECT * FROM tblNguonGocSuDungDat
			WHERE (MaNguonGoc = @MaNguonGoc))
			BEGIN
				INSERT INTO tblNguonGocSuDungDat(MaNguonGoc, MaThuaDatCapGCN , ThoiDiemKeKhaiDangKy,KyHieu,DienTich
					,ChiTiet,GhiChu)
				VALUES (convert(UNIQUEIDENTIFIER,@MaNguonGoc),CONVERT(BIGINT,@MaThuaDatCapGCN),GETDATE(),@KyHieu,CONVERT(FLOAT,@DienTich)
					,@ChiTiet,@GhiChu)
			END
		ELSE 
			SET @IsExit = 0
	END
	
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateNguonGocSuDungDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Cập nhật bảng tblNguonGocSuDungDat ( Nguon goc su dung dat)
-- theo Mã Nguồn gốc sử dụng đất
CREATE PROC [dbo].[spUpdateNguonGocSuDungDat]
	@MaNguonGoc NVARCHAR(100) = NULL,
	@MaThuaDatCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR(10) = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@ChiTiet NVARCHAR(1500) = NULL,
	@GhiChu NVARCHAR(200) = NULL
AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1
	--Truong hop cap nhat
	BEGIN
		SET DATEFORMAT DMY
		UPDATE tblNguonGocSuDungDat
		SET MaThuaDatCapGCN =  CONVERT(BIGINT,@MaThuaDatCapGCN) ,ThoiDiemKeKhaiDangKy = GETDATE(),KyHieu = @KyHieu,DienTich = CONVERT(FLOAT,@DienTich)
			,ChiTiet = @ChiTiet,GhiChu = @GhiChu 
		WHERE (MaNguonGoc = @MaNguonGoc)
	END
	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateNhaO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090828
-- Description:	Cập nhật thông tin Tài sản LÀ NHÀ Ở
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateNhaO]
	-- Add the parameters for the stored procedure here
	@MaNhaO BIGINT,
	@MaHoSoCapGCN BIGINT,
	@LoaiNha NVARCHAR(100) = NULL,
	@CapHangNha NVARCHAR(50) = NULL,
	@KetCauNha NVARCHAR(50) = NULL,
	@SoTang NVARCHAR(50) = NULL,
	@NamXayDung NVARCHAR(50) = NULL,
	@NamHoanThanhXayDung INT = NULL,
	@ThoiHanSoHuu NVARCHAR(500) = NULL,
	@DiaChiNha NVARCHAR(50) = NULL,
	@DienTichXayDung NVARCHAR(50) = NULL,
	@DienTichSanXayDung NVARCHAR(50) = NULL,
	@DienTichSanPhu NVARCHAR(50) = NULL,
	@SoGiayPhepXayDung	NVARCHAR(50) = NULL,	
	@NgayCapPhepXayDung NVARCHAR(50) = NULL,
	@CoQuanCapGPXD NVARCHAR(200) = NULL,
	@ThongTinXuLyViPham	NVARCHAR(500) = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET DATEFORMAT DMY
	UPDATE tblNhaO 
	SET MaHoSoCapGCN=CONVERT(BIGINT,@MaHoSoCapGCN) ,ThoiDiemKeKhaiDangKy=getdate(),LoaiNha  = @LoaiNha ,CapHangNha=@CapHangNha,KetCauNha=@KetCauNha
		,SoTang=@SoTang,NamXayDung = convert(int,@NamXayDung),NamHoanThanhXayDung = CONVERT(INT,@NamHoanThanhXayDung)
		,ThoiHanSoHuu = @ThoiHanSoHuu,DiaChiNha=@DiaChiNha ,DienTichXayDung=convert(float,@DienTichXayDung)
		,DienTichSanPhu = CONVERT(FLOAT,@DienTichSanPhu) ,DienTichSanXayDung = convert(float,@DienTichSanXayDung)  ,SoGiayPhepXayDung = @SoGiayPhepXayDung
		,NgayCapPhepXayDung = CONVERT(DATETIME,@NgayCapPhepXayDung),CoQuanCapGPXD = @CoQuanCapGPXD,ThongTinXuLyViPham = @ThongTinXuLyViPham
		WHERE (MaNhaO = @MaNhaO) 
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertNhaO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:	 Vũ Lê Thành
-- Create date: 20090828
-- Description:	THÊM MỘT TÀI SẢN (NHÀ Ở) vào hồ sơ cấp GCN

-- =============================================
CREATE PROCEDURE [dbo].[spInsertNhaO]
	-- Add the parameters for the stored procedure here
	@MaNhaO BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@LoaiNha NVARCHAR(100) = NULL,
	@CapHangNha NVARCHAR(50) = NULL,
	@KetCauNha NVARCHAR(50) = NULL,
	@SoTang NVARCHAR(50) = NULL,
	@NamXayDung NVARCHAR(50) = NULL,
	@NamHoanThanhXayDung INT = NULL,
	@ThoiHanSoHuu NVARCHAR(500) = NULL,
	@DiaChiNha NVARCHAR(50) = NULL,
	@DienTichXayDung NVARCHAR(50) = NULL,
	@DienTichSanXayDung NVARCHAR(50) = NULL,
	@DienTichSanPhu NVARCHAR(50) = NULL,
	@SoGiayPhepXayDung	NVARCHAR(50) = NULL,	
	@NgayCapPhepXayDung NVARCHAR(50) = NULL,
	@CoQuanCapGPXD NVARCHAR(200) = NULL,
	@ThongTinXuLyViPham	NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1
    -- Insert statements for procedure here
	SET DATEFORMAT DMY
	IF NOT EXISTS (SELECT ThoiDiemKeKhaiDangKy, CapHangNha, KetCauNha, SoTang, DiaChiNha, DienTichXayDung
		,DienTichSanPhu ,SoGiayPhepXayDung,NgayCapPhepXayDung,CoQuanCapGPXD,ThongTinXuLyViPham
		FROM tblNhaO
		WHERE (MaNhaO = @MaNhaO))
		BEGIN					
			INSERT INTO tblNhaO( MaHoSoCapGCN ,ThoiDiemKeKhaiDangKy,LoaiNha,CapHangNha ,KetCauNha ,
				SoTang , NamXayDung,NamHoanThanhXayDung,ThoiHanSoHuu,DiaChiNha ,DienTichXayDung
				 ,DienTichSanPhu ,DienTichSanXayDung,SoGiayPhepXayDung,NgayCapPhepXayDung,CoQuanCapGPXD,ThongTinXuLyViPham)
			VALUES (@MaHoSoCapGCN, GETDATE(),@LoaiNha,@CapHangNha ,@KetCauNha
				,@SoTang,CONVERT(INT,@NamXayDung),CONVERT(INT,@NamHoanThanhXayDung),@ThoiHanSoHuu,@DiaChiNha ,CONVERT(FLOAT,@DienTichXayDung)
				,CONVERT(FLOAT,@DienTichSanPhu),CONVERT(FLOAT,@DienTichSanXayDung) ,@SoGiayPhepXayDung,CONVERT(DATETIME, @NgayCapPhepXayDung),@CoQuanCapGPXD,@ThongTinXuLyViPham)
			SET @MaNhaO = @@IDENTITY
			SELECT @MaNhaO as MaNhaO
		END
	ELSE
		SET @IsExit = 0
	SET NOCOUNT OFF
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectTaiSanBienBanXetDuyet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- Author: Pham xuan chung -- Create date: <17/11/2009> 
-- Description: <lay phan tai san de in ra bien ban xet duyet cap giay chung nhan> 
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_SelectTaiSanBienBanXetDuyet] @MaHoSoCapGCN nvarchar (50)=null AS
-- BEGIN SELECT DISTINCT ThoiDiemKeKhaiDangKy, LoaiNha, CapHangNha, NamXayDung, LoaiThoiHanSoHuu, NgayBatDau, NgayKetThuc, KetCauNha, SoTang, TongSoCanHo, DiaChiNha, DienTichXayDung as DienTichXD,  DienTichSanXayDung as DienTichSanXD,
BEGIN SELECT DISTINCT ThoiDiemKeKhaiDangKy, LoaiNha, CapHangNha, NamXayDung, KetCauNha, SoTang,  DiaChiNha, DienTichXayDung as DienTichXD,  DienTichSanXayDung as DienTichSanXD,
 DienTichSanPhu, SoGiayPhepXayDung, NgayCapPhepXayDung, CoQuanCapGPXD FROM dbo.tblNhaO 
where MaHoSoCapGCN=@MaHoSoCapGCN END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinNhaODangKyCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091231
-- Description:	Lựa chọn danh sách NHÀ Ở
-- đăng ký cấp GCN theo Mã Hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinNhaODangKyCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT *
	FROM tblNhaO
	WHERE (MaHoSoCapGCN = @MaHoSoCapGCN)
	PRINT ''Selected''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteNhaOByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090828
-- Description:	Xóa Tài sản bởi Mã Hồ sơ cấp GCN
-- Cần xem lại Store này để có thể xóa được cả các bảng con
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteNhaOByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaNhaO BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@LoaiNha NVARCHAR(100) = NULL,
	@CapHangNha NVARCHAR(50) = NULL,
	@KetCauNha NVARCHAR(50) = NULL,
	@SoTang NVARCHAR(50) = NULL,
	@NamXayDung NVARCHAR(50) = NULL,
	@NamHoanThanhXayDung INT = NULL,
	@ThoiHanSoHuu NVARCHAR(500) = NULL,
	@DiaChiNha NVARCHAR(50) = NULL,
	@DienTichXayDung NVARCHAR(50) = NULL,
	@DienTichSanXayDung NVARCHAR(50) = NULL,
	@DienTichSanPhu NVARCHAR(50) = NULL,
	@SoGiayPhepXayDung	NVARCHAR(50) = NULL,	
	@NgayCapPhepXayDung NVARCHAR(50) = NULL,
	@CoQuanCapGPXD NVARCHAR(200) = NULL,
	@ThongTinXuLyViPham	NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	DELETE from tblNhaO
	--INNER JOIN tblChuSoHuu AS b ON (MaTaiSan = b.MaTaiSan )
	WHERE (MaHoSoCapGCN = @MaHoSoCapGCN) 
	SET NOCOUNT OFF
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteNhaOByMaNhaO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090828
-- Description:	Xóa Tài sản bởi Mã Tài sản
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteNhaOByMaNhaO]
	-- Add the parameters for the stored procedure here
	-- Cần xem lại sự cần thiết của các biến sau để tối ưu hóa
	@MaNhaO BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@LoaiNha NVARCHAR(100) = NULL,
	@CapHangNha NVARCHAR(50) = NULL,
	@KetCauNha NVARCHAR(50) = NULL,
	@SoTang NVARCHAR(50) = NULL,
	@NamXayDung NVARCHAR(50) = NULL,
	@NamHoanThanhXayDung INT = NULL,
	@ThoiHanSoHuu NVARCHAR(500) = NULL,
	@DiaChiNha NVARCHAR(50) = NULL,
	@DienTichXayDung NVARCHAR(50) = NULL,
	@DienTichSanXayDung NVARCHAR(50) = NULL,
	@DienTichSanPhu NVARCHAR(50) = NULL,
	@SoGiayPhepXayDung	NVARCHAR(50) = NULL,	
	@NgayCapPhepXayDung NVARCHAR(50) = NULL,
	@CoQuanCapGPXD NVARCHAR(200) = NULL,
	@ThongTinXuLyViPham	NVARCHAR(500) = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
--	--Xóa bảng Con 
-- Note: co le ko dung cau lenh nay
--	DELETE FROM tblChuSoHuu
--	WHERE (MaTaiSan = @MaNhaO)
	--Xóa bảng Cha
	DELETE FROM tblNhaO
	WHERE (MaNhaO = @MaNhaO) 
	SET NOCOUNT OFF
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectNhaOByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090828
-- Description:	HIỂN THỊ THÔNG TIN TÀI SẢN
-- LÀ NHÀ Ở THEO MÃ HỒ SƠ CẤP GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectNhaOByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaNhaO BIGINT,
	@MaHoSoCapGCN BIGINT = NULL,
	@LoaiNha NVARCHAR(100) = NULL,
	@CapHangNha NVARCHAR(50) = NULL,
	@KetCauNha NVARCHAR(50) = NULL,
	@SoTang NVARCHAR(50) = NULL,
	@NamXayDung NVARCHAR(50) = NULL,
	@NamHoanThanhXayDung INT = NULL,
	@ThoiHanSoHuu NVARCHAR(500) = NULL,
	@DiaChiNha NVARCHAR(50) = NULL,
	@DienTichXayDung NVARCHAR(50) = NULL,
	@DienTichSanXayDung NVARCHAR(50) = NULL,
	@DienTichSanPhu NVARCHAR(50) = NULL,
	@SoGiayPhepXayDung	NVARCHAR(50) = NULL,	
	@NgayCapPhepXayDung NVARCHAR(50) = NULL,
	@CoQuanCapGPXD NVARCHAR(200) = NULL,
	@ThongTinXuLyViPham	NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaNhaO ,MaHoSoCapGCN
	,LoaiNha, CapHangNha, KetCauNha,SoTang
	,DiaChiNha, DienTichXayDung,NamXayDung,NamHoanThanhXayDung
	,ThoiHanSoHuu ,DienTichSanXayDung ,DienTichSanPhu ,SoGiayPhepXayDung
	,NgayCapPhepXayDung,CoQuanCapGPXD,ThongTinXuLyViPham
	FROM tblNhaO
	WHERE 1 = 1
	AND (case @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN  ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTaiLieuKemTheoByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091001
-- Description:	Select tài liệu kèm theo theo Mã Hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTaiLieuKemTheoByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaTaiLieuKemTheo	NVARCHAR(50) = null,	
	@MaHoSoCapGCN	BIGINT = null,
	@TenTepDuLieuNguon	NVARCHAR (500) = null,
	@MoTa	 NVARCHAR(500) = null,
	@TaiLieu IMAGE = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1
    -- Insert statements for procedure here
	SELECT MaTaiLieuKemTheo, MoTa, TenTepDuLieuNguon,TaiLieu FROM tblTaiLieuKemTheo
	WHERE (MaHoSoCapGCN = @MaHoSoCapGCN)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTaiLieuKemTheoByMaTaiLieuKemTheo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091001
-- Description:	Select tài liệu kèm theo theo Mã Tài liệu kèm theo
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTaiLieuKemTheoByMaTaiLieuKemTheo]
	-- Add the parameters for the stored procedure here
	@MaTaiLieuKemTheo	NVARCHAR(50) = null,	
	@MaHoSoCapGCN	BIGINT = null,
	@TenTepDuLieuNguon	NVARCHAR(500) = null,
	@MoTa	 NVARCHAR(500) = null,
	@TaiLieu IMAGE = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1
    -- Insert statements for procedure here
	SELECT MaTaiLieuKemTheo, MoTa, TenTepDuLieuNguon,TaiLieu FROM tblTaiLieuKemTheo
	WHERE (MaTaiLieuKemTheo = @MaTaiLieuKemTheo)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTaiLieuKemTheoByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091001
-- Description:	Xóa thông tin Tài liệu kèm theo theo Mã Hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteTaiLieuKemTheoByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaTaiLieuKemTheo	NVARCHAR(50),	
	@MaHoSoCapGCN	BIGINT,
	@TenTepDuLieuNguon	NVARCHAR(500),
	@MoTa	 NVARCHAR(500),
	@TaiLieu IMAGE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1
    -- Insert statements for procedure here
	DELETE FROM tblTaiLieuKemTheo
	WHERE (MaHoSoCapGCN = @MaHoSoCapGCN)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTaiLieuKemTheoByMaTaiLieuKemTheo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091001
-- Description:	Cập nhật thông tin Tài liệu kèm theo
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteTaiLieuKemTheoByMaTaiLieuKemTheo]
	-- Add the parameters for the stored procedure here
	@MaTaiLieuKemTheo	NVARCHAR(50),	
	@MaHoSoCapGCN	BIGINT,
	@TenTepDuLieuNguon	NVARCHAR(500),
	@MoTa	 NVARCHAR(500),
	@TaiLieu IMAGE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1
    -- Insert statements for procedure here
	DELETE FROM tblTaiLieuKemTheo
	WHERE (MaTaiLieuKemTheo = @MaTaiLieuKemTheo)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTaiLieuKemTheoByMaTaiLieuKemTheo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091001
-- Description:	Cập nhật thông tin Tài liệu kèm theo
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateTaiLieuKemTheoByMaTaiLieuKemTheo]
	-- Add the parameters for the stored procedure here
	@MaTaiLieuKemTheo	nvarchar (50),	
	@MaHoSoCapGCN	BIGINT,
	@TenTepDuLieuNguon	nvarchar (200),
	@MoTa	 nvarchar (200),
	@TaiLieu varbinary (MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1
    -- Insert statements for procedure here
	SET DATEFORMAT DMY
	UPDATE tblTaiLieuKemTheo
	SET  MaTaiLieuKemTheo = convert(uniqueidentifier,@MaTaiLieuKemTheo),MaHoSoCapGCN = convert(BIGINT,@MaHoSoCapGCN) ,TenTepDuLieuNguon = @TenTepDuLieuNguon
	,MoTa = @MoTa,TaiLieu = @TaiLieu,NgayCapNhat = getdate()
	WHERE (MaTaiLieuKemTheo = @MaTaiLieuKemTheo) 
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTaiLieuKemTheo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091001
-- Description:	Thêm mới thông tin Tài liệu kèm theo
-- =============================================
CREATE PROCEDURE [dbo].[spInsertTaiLieuKemTheo]
	-- Add the parameters for the stored procedure here
	@MaTaiLieuKemTheo	nvarchar (50),	
	@MaHoSoCapGCN	BIGINT,
	@TenTepDuLieuNguon	nvarchar (500),
	@MoTa	 nvarchar (500),
	@TaiLieu IMAGE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1
    -- Insert statements for procedure here
		SET DATEFORMAT DMY
		SET @MaTaiLieuKemTheo = newid()	
		IF NOT EXISTS (SELECT * FROM tblTaiLieuKemTheo WHERE (MaTaiLieuKemTheo = @MaTaiLieuKemTheo))
			BEGIN
				INSERT INTO tblTaiLieuKemTheo(MaTaiLieuKemTheo,MaHoSoCapGCN,TenTepDuLieuNguon,MoTa,TaiLieu,NgayCapNhat) 
				VALUES (convert( UNIQUEIDENTIFIER,@MaTaiLieuKemTheo),CONVERT(BIGINT,@MaHoSoCapGCN)
					,@TenTepDuLieuNguon,@MoTa,@TaiLieu,GETDATE())
			END
		ELSE 
			SET @IsExit = 0
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinCayLauNam0]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:	 Vũ Lê Thành
-- Create date: 20091212
-- Description:	THÊM MỚI THÔNG TIN CÂY LÂU NĂM vào hồ sơ cấp GCN

-- =============================================
CREATE PROCEDURE [dbo].[spInsertThongTinCayLauNam0]
	-- Add the parameters for the stored procedure here
	@MaThongTinCayLauNam BIGINT,
	@MaHoSoCapGCN BIGINT = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@LoaiCay NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1
    -- Insert statements for procedure here
	SET DATEFORMAT DMY
	IF NOT EXISTS (SELECT MaThongTinCayLauNam,MaHoSoCapGCN
		,DienTich,LoaiCay
		FROM tblThongTinCayLauNam
		WHERE ( MaThongTinCayLauNam = @MaThongTinCayLauNam))
		BEGIN					
			INSERT INTO tblThongTinCayLauNam(MaHoSoCapGCN
				,DienTich,LoaiCay)
			VALUES (CONVERT(BIGINT,@MaHoSoCapGCN)
				,CONVERT(FLOAT,@DienTich),@LoaiCay)
		END
	ELSE
		SET @IsExit = 0
	SET NOCOUNT OFF
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinCayLauNam0]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091212
-- Description:	Cập nhật thông tin Thông tin Cây lâu năm
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinCayLauNam0]
	-- Add the parameters for the stored procedure here
	@MaThongTinCayLauNam BIGINT,
	@MaHoSoCapGCN BIGINT = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@LoaiCay NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET DATEFORMAT DMY
	UPDATE tblThongTinCayLauNam
	SET MaHoSoCapGCN=CONVERT(BIGINT,@MaHoSoCapGCN),DienTich = CONVERT(FLOAT,@DienTich)
		,LoaiCay = @LoaiCay	
		WHERE (MaThongTinCayLauNam = @MaThongTinCayLauNam)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectInPhieuThongTinRung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 28/12/2009
-- Description:	Lay thong tin ve rung va cay lau nam de in ra phieu quyet dinh cap GCN
-- =============================================
CREATE PROCEDURE [dbo].[sp_SelectInPhieuThongTinRung]
		@Flag int =null,
		@MaHoSocapGCN nvarchar(50)=null
AS
BEGIN
	if @Flag=1
		begin
	--thong tin rung cay
			SELECT DISTINCT DienTichCoRung, NguonGocTaoLap, SoHoSoGiaoRung, MaHoSoCapGCN
			FROM         dbo.tblThongTinRungCay
			Where MaHoSoCapGCN=@MaHoSoCapGCN
		end
	if @Flag=2
		begin
	--Thong tin cay lau nam
			SELECT DISTINCT MaHoSoCapGCN, DienTich, LoaiCay
			FROM         dbo.tblThongTinCayLauNam
			Where MaHoSoCapGCN=@MaHoSoCapGCN
		end

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinCayLauNamByMaHoSoCapGCN0]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091212
-- Description:	Xóa Thông tin Cây lâu năm bởi Mã Hồ sơ cấp GCN
-- Cần xem lại Store này để có thể xóa được cả các bảng con
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinCayLauNamByMaHoSoCapGCN0]
	-- Add the parameters for the stored procedure here
	@MaThongTinCayLauNam BIGINT,
	@MaHoSoCapGCN BIGINT = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@LoaiCay NVARCHAR(500) = NULL


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	DELETE from tblThongTinCayLauNam 
	--INNER JOIN tblChuSoHuu AS b ON (MaTaiSan = b.MaTaiSan )
	WHERE (MaHoSoCapGCN = @MaHoSoCapGCN) 
	SET NOCOUNT OFF

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinCayLauNamDangKyCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100104
-- Description:	Lựa chọn danh sách CÂY LÂU NĂM
-- đăng ký cấp GCN theo Mã Hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinCayLauNamDangKyCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT *
	FROM tblThongTinCayLauNam 
	WHERE (MaHoSoCapGCN = @MaHoSoCapGCN)
	PRINT ''Selected''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinCayLauNamByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091212
-- Description:	Hiển thị thông tin cây lâu năm
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinCayLauNamByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaThongTinCayLauNam BIGINT,
	@MaHoSoCapGCN BIGINT = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@LoaiCay NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaThongTinCayLauNam,MaHoSoCapGCN
		,DienTich,LoaiCay
	FROM tblThongTinCayLauNam
	WHERE 1 = 1
	AND (case @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN  ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinCayLauNamByMaThongTinCayLauNam]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Date of Modify: 20091212
-- Description:	Xóa thông tin Cây lâu năm
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinCayLauNamByMaThongTinCayLauNam]
	-- Add the parameters for the stored procedure here
	@MaThongTinCayLauNam BIGINT,
	@MaHoSoCapGCN BIGINT = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@LoaiCay NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRANSACTION
		--Xóa bảng Cha
		DELETE FROM tblThongTinCayLauNam
		WHERE (MaThongTinCayLauNam = @MaThongTinCayLauNam)
		IF @@ERROR <> 0 
		BEGIN
			ROLLBACK TRANSACTION
		END
	COMMIT TRANSACTION
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinKiemKeByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091019
-- Description:	Xóa thông tin kiểm kê bởi Mã Hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinKiemKeByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaThongTinKiemKe BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR (50) = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@MoTa NVARCHAR(500) = NULL,
	@GhiChu NVARCHAR (200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM tblThongTinKiemKe
	WHERE (MaHoSoCapGCN = @MaHoSoCapGCN)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinKiemKeByMaKiemKe]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091019
-- Description:	Xóa thông tin kiểm kê đất đai
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinKiemKeByMaKiemKe]
	-- Add the parameters for the stored procedure here
	@MaThongTinKiemKe BIGINT = NULL, 
	@MaHoSoCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR (50) = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@MoTa NVARCHAR(500) = NULL,
	@GhiChu NVARCHAR (200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM tblThongTinKiemKe
	WHERE (MaThongTinKiemKe = @MaThongTinKiemKe)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinKiemKeByMaThongTinKiemKe]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091019
-- Description:	Thêm mới thông tin kiểm kê đất đai
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinKiemKeByMaThongTinKiemKe]
	-- Add the parameters for the stored procedure here
	@MaThongTinKiemKe BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR (50) =NULL,
	@DienTich NVARCHAR(50)= NULL,
	@MoTa NVARCHAR(500) =NULL,
	@GhiChu NVARCHAR (200)  =NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET DATEFORMAT DMY
	UPDATE tblThongTinKiemKe
	SET MaHoSoCapGCN =  convert(BIGINT,@MaHoSoCapGCN) ,KyHieu = @KyHieu,DienTich = convert(float,@DienTich)
		,MoTa = @MoTa,GhiChu = @GhiChu 
	WHERE (MaThongTinKiemKe = @MaThongTinKiemKe)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinKiemKeByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091019
-- Description:	Thêm mới thông tin kiểm kê đất đai
-- =============================================
CREATE PROCEDURE [dbo].[spInsertThongTinKiemKeByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaThongTinKiemKe BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR (50) = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@MoTa NVARCHAR(500) = NULL,
	@GhiChu NVARCHAR (200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1
	SET DATEFORMAT DMY
	IF NOT EXISTS (SELECT * FROM tblThongTinKiemKe WHERE (MaThongTinKiemKe = @MaThongTinKiemKe) )
		BEGIN
			INSERT INTO tblThongTinKiemKe(MaHoSoCapGCN , KyHieu,DienTich
				,MoTa,GhiChu)
			VALUES (convert(BIGINT,@MaHoSoCapGCN) ,@KyHieu,convert(float,@DienTich)
				,@MoTa,@GhiChu)
			SELECT @@IDENTITY AS MaThongTinKiemKe
		END
	ELSE 
		SET @IsExit = 0
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinQuiHoachByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091019
-- Description:	Thêm mới thông tin qui hoạch đất đai
-- =============================================
CREATE PROCEDURE [dbo].[spInsertThongTinQuiHoachByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaThongTinQuiHoach BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR (50) = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@MoTa NVARCHAR(500) = NULL,
	@GhiChu NVARCHAR (200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1
	SET DATEFORMAT DMY
	IF NOT EXISTS (SELECT * FROM tblThongTinQuiHoach WHERE (MaThongTinQuiHoach = @MaThongTinQuiHoach))
		BEGIN
			INSERT INTO tblThongTinQuiHoach(MaHoSoCapGCN , KyHieu,DienTich
				,MoTa,GhiChu)
			VALUES (convert(BIGINT,@MaHoSoCapGCN) ,@KyHieu,convert(float,@DienTich)
				,@MoTa,@GhiChu)
			SELECT @@IDENTITY AS MaThongTinQuiHoach
		END
	ELSE 
		SET @IsExit = 0
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinQuiHoachByMaThongTinQuiHoach]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091019
-- Description:	Thêm mới thông tin qui hoạch đất đai
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinQuiHoachByMaThongTinQuiHoach]
	-- Add the parameters for the stored procedure here
	@MaThongTinQuiHoach BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR (50) = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@MoTa NVARCHAR(500) = NULL,
	@GhiChu NVARCHAR (200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET DATEFORMAT DMY
	UPDATE tblThongTinQuiHoach
	SET MaHoSoCapGCN =  convert(BIGINT,@MaHoSoCapGCN) ,KyHieu = @KyHieu,DienTich = convert(float,@DienTich)
		,MoTa = @MoTa,GhiChu = @GhiChu 
	WHERE (MaThongTinQuiHoach = @MaThongTinQuiHoach)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinQuiHoachByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091019
-- Description:	Xóa thông tin qui hoạch bởi Mã Hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinQuiHoachByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaThongTinQuiHoach BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR (50) = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@MoTa NVARCHAR(500) = NULL,
	@GhiChu NVARCHAR (200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM tblThongTinQuiHoach
	WHERE (MaHoSoCapGCN = @MaHoSoCapGCN)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinQuiHoachByMaThongTinQuiHoach]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091019
-- Description:	Xóa thông tin qui hoạch đất đai
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinQuiHoachByMaThongTinQuiHoach]
	-- Add the parameters for the stored procedure here
	@MaThongTinQuiHoach BIGINT = NULL,
	@MaHoSoCapGCN BIGINT = NULL,
	@KyHieu NVARCHAR (50) = NULL,
	@DienTich NVARCHAR(50) = NULL,
	@MoTa NVARCHAR(500) = NULL,
	@GhiChu NVARCHAR (200) =NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM tblThongTinQuiHoach
	WHERE (MaThongTinQuiHoach = @MaThongTinQuiHoach)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinRungCayByMaHoSoCapGCN0]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090828
-- Description:	Xóa Thông tin Rừng cây bởi Mã Hồ sơ cấp GCN
-- Cần xem lại Store này để có thể xóa được cả các bảng con
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinRungCayByMaHoSoCapGCN0]
	-- Add the parameters for the stored procedure here
	@MaThongTinRungCay BIGINT,
	@MaHoSoCapGCN BIGINT = NULL,
	@DienTichCoRung NVARCHAR(50) = NULL,
	@NguonGocTaoLap NVARCHAR(500) = NULL,
	@SoHoSoGiaoRung NVARCHAR(500) = NULL


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	DELETE from tblThongTinRungCay 
	--INNER JOIN tblChuSoHuu AS b ON (MaTaiSan = b.MaTaiSan )
	WHERE (MaHoSoCapGCN = @MaHoSoCapGCN) 
	SET NOCOUNT OFF

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinRungCayDangKyCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20100104
-- Description:	Lựa chọn danh sách RỪNG CÂY
-- đăng ký cấp GCN theo Mã Hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinRungCayDangKyCapGCNByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaHoSoCapGCN BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT *
	FROM tblThongTinRungCay 
	WHERE (MaHoSoCapGCN = @MaHoSoCapGCN)
	PRINT ''Selected''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinRungCayByMaThongTinRungCay]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Date of Modify: 20091112
-- Description:	Xóa thông tin RỪNG CÂY
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteThongTinRungCayByMaThongTinRungCay]
	-- Add the parameters for the stored procedure here
	@MaThongTinRungCay BIGINT,
	@MaHoSoCapGCN BIGINT,
	@DienTichCoRung NVARCHAR (50) =NULL,
	@NguonGocTaoLap NVARCHAR(500) = NULL,
	@SoHoSoGiaoRung NVARCHAR (200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRANSACTION
		--Xóa bảng Cha
		DELETE FROM tblThongTinRungCay
		WHERE (MaThongTinRungCay = @MaThongTinRungCay)
		IF @@ERROR <> 0 
		BEGIN
			ROLLBACK TRANSACTION
		END
	COMMIT TRANSACTION
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinRungCayByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090828
-- Description:	HIỂN THỊ THÔNG TIN RỪNG CÂY
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinRungCayByMaHoSoCapGCN]
	-- Add the parameters for the stored procedure here
	@MaThongTinRungCay BIGINT,
	@MaHoSoCapGCN BIGINT = NULL,
	@DienTichCoRung NVARCHAR(50) = NULL,
	@NguonGocTaoLap NVARCHAR(500) = NULL,
	@SoHoSoGiaoRung NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MaThongTinRungCay,MaHoSoCapGCN
		,DienTichCoRung,NguonGocTaoLap,	SoHoSoGiaoRung
	FROM tblThongTinRungCay
	WHERE 1 = 1
	AND (case @MaHoSoCapGCN
		WHEN '''' THEN @MaHoSoCapGCN  ELSE MaHoSoCapGCN END) = @MaHoSoCapGCN

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinRungCay]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20090828
-- Description:	Cập nhật thông tin Thông tin Rừng cây
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateThongTinRungCay]
	-- Add the parameters for the stored procedure here
	@MaThongTinRungCay BIGINT,
	@MaHoSoCapGCN BIGINT = NULL,
	@DienTichCoRung NVARCHAR(50) = NULL,
	@NguonGocTaoLap NVARCHAR(500) = NULL,
	@SoHoSoGiaoRung NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET DATEFORMAT DMY
	UPDATE tblThongTinRungCay
	SET MaHoSoCapGCN=CONVERT(BIGINT,@MaHoSoCapGCN),DienTichCoRung = CONVERT(FLOAT,@DienTichCoRung)
		,NguonGocTaoLap = @NguonGocTaoLap,SoHoSoGiaoRung = @SoHoSoGiaoRung	
		
		WHERE (MaThongTinRungCay = @MaThongTinRungCay)
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinRungCay]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:	 Vũ Lê Thành
-- Create date: 20090828
-- Description:	THÊM MỚI THÔNG TIN RỪNG CÂY vào hồ sơ cấp GCN

-- =============================================
CREATE PROCEDURE [dbo].[spInsertThongTinRungCay]
	-- Add the parameters for the stored procedure here
	@MaThongTinRungCay BIGINT,
	@MaHoSoCapGCN BIGINT = NULL,
	@DienTichCoRung NVARCHAR(50) = NULL,
	@NguonGocTaoLap NVARCHAR(500) = NULL,
	@SoHoSoGiaoRung NVARCHAR(500) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IsExit INT
	SET @IsExit = 1
    -- Insert statements for procedure here
	SET DATEFORMAT DMY
	IF NOT EXISTS (SELECT MaThongTinRungCay,MaHoSoCapGCN
		,DienTichCoRung,NguonGocTaoLap,	SoHoSoGiaoRung
		FROM tblThongTinRungCay
		WHERE ( MaThongTinRungCay = @MaThongTinRungCay))
		BEGIN					
			INSERT INTO tblThongTinRungCay(MaHoSoCapGCN
				,DienTichCoRung,NguonGocTaoLap,	SoHoSoGiaoRung)
			VALUES (CONVERT(BIGINT,@MaHoSoCapGCN)
				,CONVERT(FLOAT,@DienTichCoRung),@NguonGocTaoLap,@SoHoSoGiaoRung)
		END
	ELSE
		SET @IsExit = 0
	SET NOCOUNT OFF
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTheChapBaoLanh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham xuan chung
-- Create date: 11/05/2010
-- Description:	thuc thi chuc nang the chap bao lanh
-- =============================================
CREATE PROCEDURE [dbo].[spTheChapBaoLanh]
	@flag int =null,
	@MaTheChapBaoLanh  nvarchar(20) =null ,
	@MaHoSoCapGCN  nvarchar(20) =null ,
	@LoaiTheChap  nvarchar(50) =null ,
	@SDK_Nam  nvarchar(20) =null ,
	@SDK_So  nvarchar(20) =null ,
	@SoQuyetDinhCapGCN  nvarchar(20) =null ,
	@NgayQuyetDinhCapGCN  nvarchar(20) =null ,
	@NgayNhanDon  nvarchar(20) =null ,
	@TheChap  nvarchar(1) =null ,
	@BaoLanh  nvarchar(1) =null ,
	@TenTheChap  nvarchar(500) =null ,
	@DiaChiTheChap  nvarchar(500) =null ,
	@TaiSanQSD  nvarchar(50) =null ,
	@TaiSanDat  nvarchar(50) =null ,
	@TaiSanQSDDat  nvarchar(50) =null ,
	@GiayToKemTheo  binary =null ,
	@GhiChu  nvarchar(max) =null ,
	@SoCongChung  nvarchar(10) =null ,
	@NgayCongChung  nvarchar(20) =null ,
	@QuyenSo nvarchar(10) =null

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if @flag=0 
	begin
		SELECT     MaTheChapBaoLanh, MaHoSoCapGCN, LoaiTheChap, SDK_Nam, SDK_So, SoQuyetDinhCapGCN, NgayQuyetDinhCapGCN, NgayNhanDon, TheChap, 
							  BaoLanh, TenTheChap, DiaChiTheChap, TaiSanQSD, TaiSanDat, TaiSanQSDDat, GiayToKemTheo, GhiChu, SoCongChung, NgayCongChung, 
							  QuyenSo
		FROM         dbo.tblTheChapBaoLanh
		where MaHoSoCapGCN=@MaHoSoCapGCN
	end
if @flag=1 
	begin
		insert into tblTheChapBaoLanh( MaHoSoCapGCN, LoaiTheChap, SDK_Nam, SDK_So, SoQuyetDinhCapGCN, NgayQuyetDinhCapGCN, NgayNhanDon, TheChap, 
							  BaoLanh, TenTheChap, DiaChiTheChap, TaiSanQSD, TaiSanDat, TaiSanQSDDat, GiayToKemTheo, GhiChu, SoCongChung, NgayCongChung, 
							  QuyenSo) values(@MaHoSoCapGCN, @LoaiTheChap, @SDK_Nam, @SDK_So, @SoQuyetDinhCapGCN, @NgayQuyetDinhCapGCN, @NgayNhanDon, @TheChap, @BaoLanh, @TenTheChap, @DiaChiTheChap, @TaiSanQSD, @TaiSanDat, @TaiSanQSDDat, @GiayToKemTheo, @GhiChu, @SoCongChung, @NgayCongChung, @QuyenSo)
	end
if @flag=2 
	begin
		Update tblTheChapBaoLanh set  MaHoSoCapGCN=@MaHoSoCapGCN, LoaiTheChap=@LoaiTheChap, SDK_Nam=@SDK_Nam, SDK_So=@SDK_So, SoQuyetDinhCapGCN=@SoQuyetDinhCapGCN, NgayQuyetDinhCapGCN=@NgayQuyetDinhCapGCN, NgayNhanDon=@NgayNhanDon, TheChap=@TheChap, 
							  BaoLanh=@BaoLanh, TenTheChap=@TenTheChap, DiaChiTheChap=@DiaChiTheChap, TaiSanQSD=@TaiSanQSD, TaiSanDat=@TaiSanDat, TaiSanQSDDat=@TaiSanQSDDat, GiayToKemTheo=@GiayToKemTheo, GhiChu=@GhiChu, SoCongChung=@SoCongChung, NgayCongChung=@NgayCongChung, 
							  QuyenSo=@QuyenSo
		where MaTheChapBaoLanh=@MaTheChapBaoLanh
	end
if @flag=3 
	begin
		delete 
		FROM         dbo.tblTheChapBaoLanh
		where MaTheChapBaoLanh=@MaTheChapBaoLanh
	end
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectHoSoCapGCNByMaThuaDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author: Vũ Lê Thành
-- Date Modified: 20100330
-- Description:	Tìm kiếm Hồ sơ cấp GCN theo Mã thửa đất
-- Store này chỉ dùng cho trường hợp Đã có bản đồ.
-- =============================================
CREATE PROCEDURE [dbo].[spSelectHoSoCapGCNByMaThuaDat]
	@MaThuaDat NVARCHAR(50)=NULL
AS
BEGIN
	BEGIN
		SELECT  DISTINCT  HSCGCN.MaHoSoCapGCN
		FROM  tblDLieuKGianThuaDat AS DLKGTD
			  INNER JOIN tblThuaDatCapGCN AS TDCGCN ON TDCGCN.MaThuaDat =DLKGTD.SW_MEMBER	 
			  INNER JOIN tblHoSoCapGCN AS HSCGCN ON HSCGCN.MaHoSoCapGCN = TDCGCN.MaHoSoCapGCN
		WHERE  1 = 1	
			AND (DLKGTD.SW_MEMBER = @MaThuaDat)
		ORDER BY HSCGCN.MaHoSoCapGCN DESC
	END
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Phạm Xuân Chung, Vũ Lê Thành
-- Create date: <Create Date,,>
-- Date Modified: 20100322
-- Description:	Tìm kiếm Hồ sơ theo thông tin Cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectHoSoCapGCN]
	@IsCoBanDo NVARCHAR(10)=NULL,
	@MaDonViHanhChinh NVARCHAR (50)=NULL,
	@SoPhatHanhGCN NVARCHAR(50)=NULL,
	@SoVaoSoCapGCN NVARCHAR(50)=NULL,
	@SoQuyetDinhCapGCN NVARCHAR(50)=NULL,
	@SoToTrinh NVARCHAR(50)=NULL,
	@NamTrinh NVARCHAR(50)=NULL,
	@NgayQuyetDinhCapGCN NVARCHAR(50)=NULL
AS
BEGIN
IF @IsCoBanDo=''1''
	BEGIN
		SELECT  DISTINCT
				 b.MaHoSoCapGCN AS MaHoSoCapGCN, a.ToBanDo AS ToBanDo, a.SoThua AS SoThua
				, a.DienTichTuNhien AS DienTich,TDCGCN.DiaChi, a.SW_MEMBER AS MaThuaDat
				, a.Status, b.ToTrinhPhuong AS SoToTrinh, year( b.NgayTrinhPhuong) AS NgayLapToTrinh, 
			  YEAR (TDQD.NgayQuyetDinhCapGCN) AS NgayQuyetDinhCapGCN, a.MaDonViHanhChinh AS MaDonViHanhChinh
			FROM  tblDLieuKGianThuaDat AS a
			  LEFT JOIN tblThuaDatCapGCN AS TDCGCN ON TDCGCN.MaThuaDat =a.SW_MEMBER	 
			  LEFT JOIN tblHoSoCapGCN AS b ON b.MaHoSoCapGCN = TDCGCN.MaHoSoCapGCN
			  LEFT JOIN tblHoSoQuyetDinhCapGCN AS HSQD ON HSQD.MaHoSoCapGCN = b.MaHoSoCapGCN	
			  LEFT JOIN tblTuDienQuyetDinhCapGCN AS TDQD ON TDQD.MaQuyetDinhCapGCN = HSQD.MaQuyetDinhCapGCN
			  LEFT JOIN tblChuHoSoCapGCN AS CHS ON CHS.MaHoSoCapGCN = b.MaHoSoCapGCN
			  LEFT JOIN tblChu AS d ON d.MaChu = CHS.MaChu	
		WHERE  1 = 1	
			AND (@MaDonViHanhChinh is null or a.MaDonViHanhChinh LIKE ''%'' + @MaDonViHanhChinh + ''%'')
			AND (@SoPhatHanhGCN  is null or isnull(SoPhatHanhGCN,'''') LIKE ''%'' +  @SoPhatHanhGCN + ''%'')
			AND (@SoVaoSoCapGCN  is null or isnull(SoVaoSoCapGCN,'''') LIKE ''%'' + @SoVaoSoCapGCN + ''%'')
			AND (@SoQuyetDinhCapGCN is null or isnull(SoQuyetDinhCapGCN,'''') LIKE ''%'' + @SoQuyetDinhCapGCN + ''%'')
			AND (@SoToTrinh  is null or isnull(b.ToTrinhPhuong,'''') LIKE ''%'' + @SoToTrinh + ''%'')
			AND (@NamTrinh is null or isnull(year(b.NgayTrinhPhuong),'''') LIKE ''%'' + @NamTrinh + ''%'')
			AND (@NgayQuyetDinhCapGCN  is null or isnull(year(TDQD.NgayQuyetDinhCapGCN),'''') LIKE ''%'' + @NgayQuyetDinhCapGCN + ''%'')
			AND (a.SW_MEMBER IS NOT NULL)
	end
IF @IsCoBanDo=''0''
	BEGIN
SELECT DISTINCT 
		  b.MaHoSoCapGCN, TDCGCN.ToBanDo, TDCGCN.SoThua, TDCGCN.DienTich,TDCGCN.DiaChi  
		  , DLKGTD.SW_MEMBER AS MaThuaDat, DLKGTD.Status, b.ToTrinhPhuong AS SoToTrinh, YEAR(b.NgayTrinhPhuong) 
		  AS NgayLapToTrinh, YEAR(TDQD.NgayQuyetDinhCapGCN) AS NgayQuyetDinhCapGCN, DLKGTD.MaDonViHanhChinh
		FROM   dbo.tblHoSoCapGCN AS b 
			INNER JOIN tblThuaDatCapGCN AS TDCGCN ON TDCGCN.MaHoSoCapGCN = b.MaHoSoCapGCN	 
			LEFT JOIN tblChuHoSoCapGCN AS CHS ON CHS.MaHoSoCapGCN = b.MaHoSoCapGCN
			LEFT JOIN dbo.tblChu AS d  ON CHS.MaChu = d.MaChu
			LEFT JOIN tblHoSoQuyetDinhCapGCN AS HSQD ON HSQD.MaHoSoCapGCN = b.MaHoSoCapGCN	
			LEFT JOIN tblTuDienQuyetDinhCapGCN AS TDQD ON TDQD.MaQuyetDinhCapGCN = HSQD.MaQuyetDinhCapGCN
			LEFT JOIN dbo.tblDLieuKGianThuaDat AS  DLKGTD ON DLKGTD.SW_MEMBER = TDCGCN.MaThuaDat
			LEFT JOIN tblHoSoTiepNhan AS HSTN ON HSTN.MaHoSoCapGCN = b.MaHoSoCapGCN
		WHERE  1 = 1	
			and  (TDCGCN.MaThuaDat IS NULL) AND (DLKGTD.SW_MEMBER IS NULL)	
			AND (@MaDonViHanhChinh is null or b.Maxa LIKE ''%'' + @MaDonViHanhChinh + ''%'')
			AND (@SoPhatHanhGCN  is null or ISNULL(SoPhatHanhGCN,'''') LIKE ''%'' +  @SoPhatHanhGCN + ''%'')
			AND (@SoVaoSoCapGCN  is null or ISNULL(SoVaoSoCapGCN,'''') LIKE ''%'' + @SoVaoSoCapGCN + ''%'')
			AND (@SoQuyetDinhCapGCN  is null or ISNULL(SoQuyetDinhCapGCN,'''') LIKE ''%'' + @SoQuyetDinhCapGCN + ''%'')
			AND (@SoToTrinh  is null or ISNULL(b.ToTrinhPhuong,'''') LIKE ''%'' + @SoToTrinh + ''%'')
			AND (@NamTrinh is null or  ISNULL(YEAR(b.NgayTrinhPhuong),'''') LIKE ''%'' + @NamTrinh + ''%'')
			AND (@NgayQuyetDinhCapGCN is null or ISNULL(YEAR(TDQD.NgayQuyetDinhCapGCN),'''') LIKE ''%'' + @NgayQuyetDinhCapGCN + ''%'')
	END
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTheoHoSoCapGCN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Phạm Xuân Chung, Vũ Lê Thành
-- Create date: <Create Date,,>
-- Date Modified: 20100322
-- Description:	Tìm kiếm theo thông tin Trạng thái hồ sơ
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTheoHoSoCapGCN]
	@IsCoBanDo NVARCHAR(10)=NULL,
	@MaDonViHanhChinh NVARCHAR(50)=NULL,
	@TrangThaiHoSoCapGCN NVARCHAR(50)=NULL,
	@SoPhatHanhGCN NVARCHAR(50)=NULL,
	@SoVaoSoCapGCN NVARCHAR(50)=NULL,
	@SoQuyetDinhCapGCN NVARCHAR(50)=NULL,
	@SoHoSo NVARCHAR(50)=NULL,
	@SoThuTuHoSo NVARCHAR(50)=NULL
AS
BEGIN
IF @IsCoBanDo=''1''
	BEGIN
		SELECT  
			   b.MaHoSoCapGCN AS MaHoSoCapGCN, a.ToBanDo AS ToBanDo, a.SoThua AS SoThua
				, a.DienTichTuNhien AS DienTich
			  ,TDCGCN.DiaChi, a.SW_MEMBER AS MaThuaDat, a.Status, b.ToTrinhPhuong AS SoToTrinh
			  ,YEAR( b.NgayTrinhPhuong) AS NgayLapToTrinh, 
			  YEAR(TDQD.NgayQuyetDinhCapGCN) AS NgayQuyetDinhCapGCN,a.MaDonViHanhChinh AS MaDonViHanhChinh
			FROM  tblDLieuKGianThuaDat AS a 
			  LEFT JOIN tblThuaDatCapGCN AS TDCGCN ON TDCGCN.MaThuaDat = a.SW_MEMBER 
			  LEFT JOIN tblHoSoCapGCN AS b ON b.MaHoSoCapGCN = TDCGCN.MaHoSoCapGCN
			  LEFT JOIN tblHoSoQuyetDinhCapGCN AS HSQD ON HSQD.MaHoSoCapGCN = b.MaHoSoCapGCN	
			  LEFT JOIN tblTuDienQuyetDinhCapGCN AS TDQD ON TDQD.MaQuyetDinhCapGCN = HSQD.MaQuyetDinhCapGCN
			  LEFT JOIN tblHoSoTiepNhan AS HSTN ON HSTN.MaHoSoCapGCN = b.MaHoSoCapGCN
			  LEFT JOIN tblChuHoSoCapGCN AS CHS ON CHS.MaHoSoCapGCN = b.MaHoSoCapGCN
			  LEFT JOIN tblChu AS d ON d.MaChu = CHS.MaChu	
		WHERE  1 = 1	
			AND (@MaDonViHanhChinh is null or a.MaDonViHanhChinh LIKE ''%'' + @MaDonViHanhChinh + ''%'')
			AND (@TrangThaiHoSoCapGCN is null or isnull(b.TrangThaiHoSoCapGCN,'''') LIKE ''%'' +  @TrangThaiHoSoCapGCN + ''%'')
			AND (@SoPhatHanhGCN is null or isnull(b.SoPhatHanhGCN,'''') LIKE ''%'' + @SoPhatHanhGCN + ''%'')
			AND (@SoVaoSoCapGCN  is null or isnull(b.SoVaoSoCapGCN,'''') LIKE ''%'' + @SoVaoSoCapGCN + ''%'')
			AND (@SoQuyetDinhCapGCN  is null or isnull(TDQD.SoQuyetDinhCapGCN,'''') LIKE ''%'' + @SoQuyetDinhCapGCN + ''%'')
			AND (@SoHoSo is null or isnull(HSTN.SoHoSoTiepNhan,'''') LIKE ''%'' + @SoHoSo + ''%'')
			AND (@SoThuTuHoSo is null or isnull(HSTN.ThuTuTiepNhan,'''') LIKE ''%'' +  @SoThuTuHoSo + ''%'')
			and (a.SW_MEMBER IS not NULL)
	END
IF @IsCoBanDo=''0''
	BEGIN
		SELECT DISTINCT 
              b.MaHoSoCapGCN, TDCGCN.ToBanDo, TDCGCN.SoThua, TDCGCN.DienTich,TDCGCN.DiaChi 
              ,DLKGTD.SW_MEMBER AS MaThuaDat, DLKGTD.Status, b.ToTrinhPhuong AS SoToTrinh, YEAR(b.NgayTrinhPhuong) 
              AS NgayLapToTrinh, YEAR(TDQD.NgayQuyetDinhCapGCN) AS NgayQuyetDinhCapGCN, DLKGTD.MaDonViHanhChinh
		FROM   dbo.tblHoSoCapGCN AS b 
			INNER JOIN tblThuaDatCapGCN AS TDCGCN ON TDCGCN.MaHoSoCapGCN = b.MaHoSoCapGCN	 
			LEFT JOIN tblChuHoSoCapGCN AS CHS ON CHS.MaHoSoCapGCN = b.MaHoSoCapGCN
			LEFT JOIN dbo.tblChu AS d  ON CHS.MaChu = d.MaChu
			LEFT JOIN tblHoSoQuyetDinhCapGCN AS HSQD ON HSQD.MaHoSoCapGCN = b.MaHoSoCapGCN	
			LEFT JOIN tblTuDienQuyetDinhCapGCN AS TDQD ON TDQD.MaQuyetDinhCapGCN = HSQD.MaQuyetDinhCapGCN
			LEFT JOIN dbo.tblDLieuKGianThuaDat AS  DLKGTD ON DLKGTD.SW_MEMBER = TDCGCN.MaThuaDat
			LEFT JOIN tblHoSoTiepNhan AS HSTN ON HSTN.MaHoSoCapGCN = b.MaHoSoCapGCN
		WHERE  1 = 1	
			AND  (TDCGCN.MaThuaDat IS NULL) AND (DLKGTD.SW_MEMBER IS NULL)	
			AND (b.Maxa LIKE ''%'' + @MaDonViHanhChinh + ''%'')
			AND (@TrangThaiHoSoCapGCN is null or isnull(b.TrangThaiHoSoCapGCN,'''') LIKE ''%'' +  @TrangThaiHoSoCapGCN + ''%'')
			AND (@SoPhatHanhGCN  is null or isnull(b.SoPhatHanhGCN,'''') LIKE ''%'' + @SoPhatHanhGCN + ''%'')
			AND (@SoVaoSoCapGCN is null or isnull(b.SoVaoSoCapGCN,'''') LIKE ''%'' + @SoVaoSoCapGCN + ''%'')
			AND (@SoQuyetDinhCapGCN is null or isnull(TDQD.SoQuyetDinhCapGCN,'''') LIKE ''%'' + @SoQuyetDinhCapGCN + ''%'')
			AND (@SoHoSo is null or isnull(HSTN.SoHoSoTiepNhan,'''') LIKE ''%'' + @SoHoSo + ''%'')
			AND (@SoThuTuHoSo is null or isnull(HSTN.ThuTuTiepNhan,'''') LIKE ''%'' +  @SoThuTuHoSo + ''%'')
	END
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTheoChuSuDung]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		phamxuanchung, VuLeThanh
-- Create date: <Create Date,,>
-- Date modified: 20100322
-- Description:	Tìm kiếm thông tin Chủ hồ sơ cấp GCN
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTheoChuSuDung]
	@IsCoBanDo NVARCHAR(10)=NULL,
	@MaDonViHanhChinh NVARCHAR(50)=NULL,
	@TenChuSuDung NVARCHAR(50)=NULL,
	@SoDinhDanh NVARCHAR(50)=NULL
AS
BEGIN
IF @IsCoBanDo=''1''
	BEGIN
		SELECT  DISTINCT
			  b.MaHoSoCapGCN AS MaHoSoCapGCN, a.ToBanDo AS ToBanDo, a.SoThua AS SoThua
			  , a.DienTichTuNhien AS DienTich , TDCGCN.DiaChi
			, a.SW_MEMBER AS MaThuaDat, a.Status, b.ToTrinhPhuong AS SoToTrinh, YEAR( b.NgayTrinhPhuong) as NgayLapToTrinh, 
			  YEAR(TDQD.NgayQuyetDinhCapGCN)  AS NgayQuyetDinhCapGCN,a.MaDonViHanhChinh AS MaDonViHanhChinh
			FROM  tblDLieuKGianThuaDat AS a
			  LEFT JOIN tblThuaDatCapGCN AS TDCGCN ON TDCGCN.MaThuaDat =a.SW_MEMBER	 
			  LEFT JOIN tblHoSoCapGCN AS b ON b.MaHoSoCapGCN = TDCGCN.MaHoSoCapGCN 
			  LEFT JOIN tblHoSoQuyetDinhCapGCN AS HSQD ON HSQD.MaHoSoCapGCN = b.MaHoSoCapGCN	
			  LEFT JOIN tblTuDienQuyetDinhCapGCN AS TDQD ON TDQD.MaQuyetDinhCapGCN = HSQD.MaQuyetDinhCapGCN
			  LEFT JOIN tblChuHoSoCapGCN AS CHS ON CHS.MaHoSoCapGCN = b.MaHoSoCapGCN
			  LEFT OUTER JOIN tblChu AS d ON d.MaChu = CHS.MaChu	
		WHERE  1 = 1	
			AND (@MaDonViHanhChinh is null or a.MaDonViHanhChinh LIKE ''%'' + @MaDonViHanhChinh + ''%'')
			AND (@TenChuSuDung is null or ISNULL(d.HoTen,N'''') LIKE ''%'' +  @TenChuSuDung + ''%'')
			AND (@SoDinhDanh  is null or ISNULL(d.SoDinhDanh,'''') LIKE ''%'' + @SoDinhDanh + ''%'')
			AND (a.SW_MEMBER IS NOT NULL)
	end
IF @IsCoBanDo=''0''
	BEGIN
		SELECT DISTINCT  
                      b.MaHoSoCapGCN,TDCGCN.DiaChi
					, TDCGCN.ToBanDo AS ToBanDo, TDCGCN.SoThua AS SoThua, TDCGCN.DienTich 
                      , DLKGTD.SW_MEMBER AS MaThuaDat, DLKGTD.Status, b.ToTrinhPhuong AS SoToTrinh, YEAR(b.NgayTrinhPhuong) 
                      AS NgayLapToTrinh, YEAR(TDQD.NgayQuyetDinhCapGCN) AS NgayQuyetDinhCapGCN, DLKGTD.MaDonViHanhChinh
		FROM   dbo.tblHoSoCapGCN AS b 
			INNER JOIN tblThuaDatCapGCN AS TDCGCN ON TDCGCN.MaHoSoCapGCN = b.MaHoSoCapGCN	 
			LEFT JOIN tblChuHoSoCapGCN AS CHS ON CHS.MaHoSoCapGCN = b.MaHoSoCapGCN
			LEFT JOIN dbo.tblChu AS d  ON CHS.MaChu = d.MaChu
			LEFT JOIN tblHoSoQuyetDinhCapGCN AS HSQD ON HSQD.MaHoSoCapGCN = b.MaHoSoCapGCN	
			LEFT JOIN tblTuDienQuyetDinhCapGCN AS TDQD ON TDQD.MaQuyetDinhCapGCN = HSQD.MaQuyetDinhCapGCN
			LEFT JOIN dbo.tblDLieuKGianThuaDat AS  DLKGTD ON DLKGTD.SW_MEMBER = TDCGCN.MaThuaDat
		WHERE (1=1)
			AND (TDCGCN.MaThuaDat IS NULL)
			AND (DLKGTD.SW_MEMBER IS NULL)
			AND (@MaDonViHanhChinh is null or b.Maxa LIKE ''%'' + @MaDonViHanhChinh + ''%'')
			AND (@TenChuSuDung  is null or ISNULL(d.HoTen,N'''') LIKE ''%'' +  @TenChuSuDung + ''%'')
			AND (@SoDinhDanh  is null or ISNULL(d.SoDinhDanh,'''') LIKE ''%'' + @SoDinhDanh + ''%'')
	END
END



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinThuaDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		pham xuan chung, Vũ Lê Thành
-- Create date: <Create Date,,>
-- Date Modified: 20100322
-- Description:	Tìm kiếm theo thông tin Thửa đất
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinThuaDat]
	@IsCoBanDo NVARCHAR(10)=NULL,
	@MaDonViHanhChinh NVARCHAR(50)=NULL,
	@ToBanDo NVARCHAR(50)=NULL,
	@SoThua NVARCHAR(50)=NULL,
	@DiaChiThua  NVARCHAR(100)=NULL
AS
BEGIN
IF @IsCoBanDo=''1''
	BEGIN
		SELECT  DISTINCT
	          b.MaHoSoCapGCN AS MaHoSoCapGCN, a.ToBanDo AS ToBanDo, a.SoThua AS SoThua
			, a.DienTichTuNhien AS DienTich
	          , TDCGCN.DiaChi, a.SW_MEMBER AS MaThuaDat, a.Status
			, b.ToTrinhPhuong AS SoToTrinh, YEAR( b.NgayTrinhPhuong) AS NgayLapToTrinh, 
	          year(TDQD.NgayQuyetDinhCapGCN) AS NgayQuyetDinhCapGCN,a.MaDonViHanhChinh AS MaDonViHanhChinh
		
		FROM  tblDLieuKGianThuaDat AS a 
			  LEFT JOIN tblThuaDatCapGCN AS TDCGCN ON TDCGCN.MaThuaDat =a.SW_MEMBER	 
			  LEFT JOIN tblHoSoCapGCN AS b ON b.MaHoSoCapGCN = TDCGCN.MaHoSoCapGCN
			  LEFT JOIN tblHoSoQuyetDinhCapGCN AS HSQD ON HSQD.MaHoSoCapGCN = b.MaHoSoCapGCN	
			  LEFT JOIN tblTuDienQuyetDinhCapGCN AS TDQD ON TDQD.MaQuyetDinhCapGCN = HSQD.MaQuyetDinhCapGCN
			  LEFT JOIN tblChuHoSoCapGCN AS CHS ON CHS.MaHoSoCapGCN = b.MaHoSoCapGCN
			  LEFT JOIN tblChu AS d ON d.MaChu = CHS.MaChu	
		WHERE  1 = 1	
			AND (@MaDonViHanhChinh is null or a.MaDonViHanhChinh LIKE ''%'' + @MaDonViHanhChinh + ''%'')
			AND (@MaDonViHanhChinh is null or ISNULL(a.ToBanDo,'''') LIKE ''%'' +  @ToBanDo + ''%'')
			AND (@SoThua  is null or ISNULL(a.SoThua,'''') LIKE ''%'' + @SoThua + ''%'')
			AND (@DiaChiThua  is null or ISNULL(TDCGCN.DiaChi,'''') LIKE ''%'' + @DiaChiThua + ''%'')
			and (a.SW_MEMBER IS not NULL)
	end
IF @IsCoBanDo=''0''
	BEGIN
		SELECT DISTINCT 
                      b.MaHoSoCapGCN, TDCGCN.ToBanDo , TDCGCN.SoThua , TDCGCN.DienTich, TDCGCN.DiaChi
                      ,DLKGTD.SW_MEMBER AS MaThuaDat, DLKGTD.Status, b.ToTrinhPhuong AS SoToTrinh
					 , YEAR(b.NgayTrinhPhuong) AS NgayLapToTrinh, YEAR(TDQD.NgayQuyetDinhCapGCN) AS NgayQuyetDinhCapGCN
					, DLKGTD.MaDonViHanhChinh
		FROM   dbo.tblHoSoCapGCN AS b 
			INNER JOIN tblThuaDatCapGCN AS TDCGCN ON TDCGCN.MaHoSoCapGCN = b.MaHoSoCapGCN	 
			LEFT JOIN tblChuHoSoCapGCN AS CHS ON CHS.MaHoSoCapGCN = b.MaHoSoCapGCN
			LEFT JOIN dbo.tblChu AS d  ON CHS.MaChu = d.MaChu
			LEFT JOIN tblHoSoQuyetDinhCapGCN AS HSQD ON HSQD.MaHoSoCapGCN = b.MaHoSoCapGCN	
			LEFT JOIN tblTuDienQuyetDinhCapGCN AS TDQD ON TDQD.MaQuyetDinhCapGCN = HSQD.MaQuyetDinhCapGCN
			LEFT JOIN dbo.tblDLieuKGianThuaDat AS  DLKGTD ON DLKGTD.SW_MEMBER = TDCGCN.MaThuaDat
			LEFT JOIN tblHoSoTiepNhan AS HSTN ON HSTN.MaHoSoCapGCN = b.MaHoSoCapGCN

		WHERE  1 = 1	
			AND  (TDCGCN.MaThuaDat IS NULL) AND (DLKGTD.SW_MEMBER IS NULL)
			AND (@MaDonViHanhChinh  is null or  b.MaXa LIKE ''%'' + @MaDonViHanhChinh + ''%'')
			AND (@ToBanDo  is null or ISNULL(TDCGCN.ToBanDo,'''') LIKE ''%'' +  @ToBanDo + ''%'')
			AND (@SoThua is null or ISNULL(TDCGCN.SoThua,'''') LIKE ''%'' + @SoThua + ''%'')
			AND (@DiaChiThua is null or ISNULL (TDCGCN.DiaChi,'''') LIKE ''%'' + @DiaChiThua + ''%'')
			
	END
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InSoMucKe]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Pham xuan chung
-- Create date: 5/11/2009
-- Description:	select phan in so muc ke
-- =============================================
CREATE PROCEDURE [dbo].[sp_InSoMucKe]
	@Flag int =null,
	@ToBanDo nvarchar(50)=null,
	@SoThua nvarchar(50)=null,
	@NamIn nvarchar (20) =null,
	@MaDVHC nvarchar(50)=null
AS
BEGIN
	if @Flag =1 
		begin

			IF (@NamIn=0) 
				BEGIN
					SELECT DISTINCT tblDLieuKGianThuaDat.ToBanDo 
					FROM  dbo.tblThuaDatCapGCN 
					INNER JOIN dbo.tblDLieuKGianThuaDat ON dbo.tblThuaDatCapGCN.MaThuaDat = dbo.tblDLieuKGianThuaDat.SW_MEMBER 
					INNER JOIN dbo.tblHoSoCapGCN ON dbo.tblThuaDatCapGCN.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN 
					WHERE tblHoSoCapGCN.TrangThaiHoSoCapGCN = 7  and tblDLieuKGianThuaDat.MaDonViHanhChinh =@MaDVHC 
					order by tblDLieuKGianThuaDat.ToBanDo
				END
			ELSE
				BEGIN
				--and year(NgayHoanTatGCN)=@NamIn
					SELECT DISTINCT tblDLieuKGianThuaDat.ToBanDo 
					FROM  dbo.tblThuaDatCapGCN
					INNER JOIN dbo.tblDLieuKGianThuaDat ON dbo.tblThuaDatCapGCN.MaThuaDat = dbo.tblDLieuKGianThuaDat.SW_MEMBER 
					INNER JOIN dbo.tblHoSoCapGCN ON dbo.tblThuaDatCapGCN.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN
					WHERE tblHoSoCapGCN.TrangThaiHoSoCapGCN = 7 and year(NgayHoanTatGCN)=@NamIn and tblDLieuKGianThuaDat.MaDonViHanhChinh =@MaDVHC 
					ORDER BY tblDLieuKGianThuaDat.ToBanDo
				END
		END
	IF @Flag=2
	BEGIN
		IF (@NamIn=0) 
			BEGIN
				SELECT DISTINCT tblThuaDatCapGCN.SoThua 
				FROM  dbo.tblThuaDatCapGCN 
				INNER JOIN dbo.tblHoSoCapGCN ON dbo.tblThuaDatCapGCN.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN
				INNER JOIN dbo.tblDLieuKGianThuaDat ON dbo.tblThuaDatCapGCN.MaThuaDat = dbo.tblDLieuKGianThuaDat.SW_MEMBER 
				WHERE tblThuaDatCapGCN.ToBanDo  = @ToBanDo and tblDLieuKGianThuaDat.MaDonViHanhChinh =@MaDVHC 
				ORDER BY tblThuaDatCapGCN.SoThua  asc
			END
		ELSE
			BEGIN
				  SELECT DISTINCT tblThuaDatCapGCN.SoThua 
				  FROM  dbo.tblThuaDatCapGCN INNER JOIN
                  dbo.tblHoSoCapGCN ON dbo.tblThuaDatCapGCN.MaHoSoCapGCN = dbo.tblHoSoCapGCN.MaHoSoCapGCN
				  INNER JOIN dbo.tblDLieuKGianThuaDat ON dbo.tblThuaDatCapGCN.MaThuaDat = dbo.tblDLieuKGianThuaDat.SW_MEMBER 
				  WHERE tblThuaDatCapGCN.ToBanDo  = @ToBanDo and tblDLieuKGianThuaDat.MaDonViHanhChinh =@MaDVHC and year(NgayHoanTatGCN)=@NamIn 
				  ORDER BY tblThuaDatCapGCN.SoThua  asc
			END
	END
	IF @Flag=3
		BEGIN
			IF (@NamIn=0) 
				BEGIN
                    SELECT  TOP (100) PERCENT dbo.tblChu.HoTen, dbo.tblChu.DoiTuongSDD, dbo.tblChu.GioiTinh
                    FROM tblChu,tblHoSoCapGCN,tblThuaDatCapGCN,tblChuHoSoCapGCN
                    WHERE tblChu.MaChu=tblChuHoSoCapGCN.MaChu AND tblHoSoCapGCN.MaHoSoCapGCN=tblChuHoSoCapGCN.MaHoSoCapGCN
                           AND tblThuaDatCapGCN.MaHoSoCapGCN=tblHoSoCapGCN.MaHoSoCapGCN AND tblThuaDatCapGCN.SoThua=@SoThua  
                           AND tblThuaDatCapGCN.ToBanDo =@ToBanDo 
                    ORDER BY HoTen 
				END
			ELSE
				BEGIN
                    SELECT  TOP (100) PERCENT dbo.tblChu.HoTen, dbo.tblChu.DoiTuongSDD, dbo.tblChu.GioiTinh
                    FROM tblChu,tblHoSoCapGCN,tblThuaDatCapGCN,tblChuHoSoCapGCN
                    WHERE tblChu.MaChu=tblChuHoSoCapGCN.MaChu AND tblHoSoCapGCN.MaHoSoCapGCN=tblChuHoSoCapGCN.MaHoSoCapGCN
                           AND tblThuaDatCapGCN.MaHoSoCapGCN=tblHoSoCapGCN.MaHoSoCapGCN AND tblThuaDatCapGCN.SoThua=@SoThua  
                           AND tblThuaDatCapGCN.ToBanDo =@ToBanDo AND year(NgayHoanTatGCN)=@NamIn 
                    ORDER BY HoTen 
				END
	END
	IF @Flag=4
		BEGIN
			IF (@NamIn=0) 
				
				BEGIN
					SELECT     dbo.tblMucDichSuDungDat.KyHieu, dbo.tblMucDichSuDungDat.DienTichKeKhai, dbo.tblMucDichSuDungDat.KyHieuKiemKe, 
                      dbo.tblMucDichSuDungDat.KyHieuQuiHoach, dbo.tblMucDichSuDungDat.ChiTiet 
						FROM tblThuaDatCapGCN
						INNER JOIN tblDLieuKGianThuaDat ON tblThuaDatCapGCN.MaThuaDat = tblDLieuKGianThuaDat.SW_MEMBER 
						INNER JOIN tblHoSoCapGCN ON tblThuaDatCapGCN.MaHoSoCapGCN = tblHoSoCapGCN.MaHoSoCapGCN 
						INNER JOIN tblMucDichSuDungDat ON tblThuaDatCapGCN.MaThuaDatCapGCN = tblMucDichSuDungDat.MaThuaDatCapGCN
						WHERE  tblThuaDatCapGCN.SoThua=@SoThua AND tblDLieuKGianThuaDat.ToBanDo =@ToBanDo 
				END
			ELSE
				BEGIN
						SELECT     dbo.tblMucDichSuDungDat.KyHieu, dbo.tblMucDichSuDungDat.DienTichKeKhai, dbo.tblMucDichSuDungDat.KyHieuKiemKe, 
                      dbo.tblMucDichSuDungDat.KyHieuQuiHoach, dbo.tblMucDichSuDungDat.ChiTiet 
					  FROM tblThuaDatCapGCN 
					  INNER JOIN tblDLieuKGianThuaDat ON tblThuaDatCapGCN.MaThuaDat = tblDLieuKGianThuaDat.SW_MEMBER 
					  INNER JOIN tblHoSoCapGCN ON tblThuaDatCapGCN.MaHoSoCapGCN = tblHoSoCapGCN.MaHoSoCapGCN 
					  INNER JOIN tblMucDichSuDungDat ON tblThuaDatCapGCN.MaThuaDatCapGCN = tblMucDichSuDungDat.MaThuaDatCapGCN
					  WHERE  tblThuaDatCapGCN.SoThua=@SoThua
												   AND tblDLieuKGianThuaDat.ToBanDo =@ToBanDo and year(NgayHoanTatGCN)=@NamIn
				END
		END
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinBienDongThuaDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 21/7/2010
-- Description:	Lay du lieu ra grid hien thi so lan bien dong cua thua dat
-- =============================================
CREATE PROCEDURE [dbo].[spSelectThongTinBienDongThuaDat] 
@flag int =null,
@MaThuaDat nvarchar(200)=null
AS
BEGIN
			;with TTT( NgayBienDong, LoaiBienDong, ToBanDo, SoThua, DienTichTuNhien,SW_MEMBER, DanhSachMaThuaDatCon)  AS
			(
				select  NgayBienDong, LoaiBienDong, ToBanDo, SoThua, DienTichTuNhien,SW_MEMBER, DanhSachMaThuaDatCon from TBLDLIEUKGIANTHUADATLICHSU
				where DanhSachMaThuaDatCon like ''%''+ @MaThuaDat +''%''
				union all
				select  t.NgayBienDong, t.LoaiBienDong, t.ToBanDo, t.SoThua, t.DienTichTuNhien,t.SW_MEMBER, t.DanhSachMaThuaDatCon 
				FROM TBLDLIEUKGIANTHUADATLICHSU t, TTT
				where t.DanhSachMaThuaDatCon like ''%'' + convert(nvarchar, TTT.SW_MEMBER) + ''%''
			)

			select * from TTT
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertDLieuKGianThuaDatLichSuByGhep]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091103
-- Description:	Lưu vào bảng Lịch sử thửa đất bị Ghép
-- Biến truyền vào @xml: là danh sách Mã thửa đất bị ghép
-- Toàn bộ thửa đất trong danh sách này sẽ được Insert vào 
-- bảng Lịch sử thửa đất (tblDLieuKGianThuaDat), đồng thời sẽ bị xóa tại bảng các thửa
-- đất hiên thời (tblDLieuKGianThuaDat)
-- =============================================
CREATE PROCEDURE [dbo].[spInsertDLieuKGianThuaDatLichSuByGhep]
	-- Add the parameters for the stored procedure here
	@xml XML
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	DECLARE @idoc int
		EXEC sp_xml_preparedocument @idoc OUTPUT,@xml
		BEGIN TRANSACTION

		-- LƯU CÁC THỬA ĐẤT CẦN GHÉP VÀO TRONG BẢNG LỊCH SỬ
		-- tblDLieuKGianThuaDatLichSu
		Insert into TblDLieuKGianThuaDatLichSu
			(NgayBienDong,
				LoaiBienDong,
				ToBanDo
				,SoThua
				,DienTichTuNhien
				,featureID
				,TYLEIN
				,Status
				,MaDonViHanhChinh
				,MI_STYLE
				,SW_MEMBER
				,SW_GEOMETRY
				,DanhSachMaThuaDatCon
			)
			Select getdate(),''ghep'',
				ToBanDo
				,SoThua
				,DienTichTuNhien
				,featureID
				,TYLEIN
				,Status
				,MaDonViHanhChinh
				,MI_STYLE
				,SW_MEMBER
				,SW_GEOMETRY
				,(select max(SW_MEMBER) from TblDLieuKGianThuaDat)
			From OPENXML(@idoc,''/root/ThuaDat'')
			WITH
				(
				MaThua	int ''MaThua''
				) AS xmlTable

			INNER JOIN TblDLieuKGianThuaDat
			ON TblDLieuKGianThuaDat.SW_MEMBER = xmlTable.MaThua
			IF (@@ERROR <> 0)
				BEGIN
					ROLLBACK TRANSACTION
					RETURN
				END
			ELSE 
				BEGIN
					-- XÓA CÁC THỬA ĐẤT CẦN GHÉP TRONG BẢNG DỮ LIỆU
					-- THỬA ĐẤT HIỆN THỜI tblDLieuKGianThuaDat
					DELETE TblDLieuKGianThuaDat 
					From OPENXML(@idoc,''/root/ThuaDat'')
					WITH
						(
						MaThua	int	''MaThua''
						) AS xmlTable
					WHERE
						 TblDLieuKGianThuaDat.SW_MEMBER=xmlTable.MaThua

					IF (@@ERROR <>0)
							BEGIN
								ROLLBACK TRANSACTION
								RETURN
							END
					ELSE
							BEGIN
								COMMIT TRANSACTION
							END
				END
		exec sp_xml_removedocument @idoc

	PRINT ''Da Them''
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertDLieuKGianThuaDatLichSuByTachThua]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091103
-- Description:	Lưu vào bảng Lịch sử thửa đất bị Tách 
-- =============================================
CREATE PROCEDURE [dbo].[spInsertDLieuKGianThuaDatLichSuByTachThua]
	-- Add the parameters for the stored procedure here
	@MaThuaDat INT = null,
	@MaThuaDatCon nvarchar(300) =null
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRANSACTION
    -- Insert statements for procedure here
	IF EXISTS (SELECT SW_MEMBER FROM TblDLieuKGianThuaDat 
		WHERE SW_MEMBER = @MaThuaDat)
		BEGIN
			-- Lưu thửa đất bị tách vào bảng lịch sử
			--(TblDLieuKGianThuaDatLichSu))
			INSERT INTO TblDLieuKGianThuaDatLichSu 
			 (NgayBienDong, LoaiBienDong , ToBanDo, SoThua, DienTichTuNhien, Status,
				MaDonViHanhChinh, MI_STYLE,SW_GEOMETRY,
				DanhSachMaThuaDatCha,SW_MEMBER, DanhSachMaThuaDatCon) 
			 ( 
				SELECT	getdate(),''tach'',ToBanDo, SoThua, DienTichTuNhien, Status,
				MaDonViHanhChinh, MI_STYLE,SW_GEOMETRY,
				DanhSachMaThuaDatCha,SW_MEMBER,@MaThuaDatCon
				FROM TblDLieuKGianThuaDat 	
				WHERE SW_MEMBER =  @MaThuaDat)
			IF (@@ERROR <> 0)
				BEGIN
					ROLLBACK TRANSACTION
					RETURN
				END
			ELSE
				BEGIN
					-- Xóa thửa đất bị tách khỏi bảng hiện thời
					--(TblDLieuKGianThuaDat)
					DELETE FROM TblDLieuKGianThuaDat
					WHERE (SW_MEMBER = @MaThuaDat)
					IF (@@ERROR <> 0)
						BEGIN
							ROLLBACK TRANSACTION
							RETURN
						END 
					ELSE
						BEGIN
							COMMIT TRANSACTION
						END
				END
		END

	PRINT ''Da Them''
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertDLieuKGianThuaDatLichSuByNanChinh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091103
-- Description:	Lưu vào bảng Lịch sử thửa đất bị Nắn chỉnh
-- =============================================
CREATE PROCEDURE [dbo].[spInsertDLieuKGianThuaDatLichSuByNanChinh]
	-- Add the parameters for the stored procedure here
	@MaThuaDat INT=null,
	@MaThuaDatCon nvarchar(300) =null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRANSACTION
    -- Insert statements for procedure here
	IF EXISTS (SELECT SW_MEMBER FROM TblDLieuKGianThuaDat 
		WHERE SW_MEMBER = @MaThuaDat)
		BEGIN
			-- Lưu thửa đất bị NẮN CHỈNH vào bảng lịch sử
			--(TblDLieuKGianThuaDatLichSu))
			INSERT INTO TblDLieuKGianThuaDatLichSu 
			 ( NgayBienDong, LoaiBienDong,ToBanDo, SoThua, DienTichTuNhien, Status,
				MaDonViHanhChinh, MI_STYLE,SW_GEOMETRY,
				DanhSachMaThuaDatCha,SW_MEMBER,DanhSachmaThuaDatCon) 
			 ( 
				SELECT	Getdate(),''nan'',ToBanDo, SoThua, DienTichTuNhien, Status,
				MaDonViHanhChinh, MI_STYLE,SW_GEOMETRY,
				DanhSachMaThuaDatCha,SW_MEMBER,@MaThuaDatCon
				FROM TblDLieuKGianThuaDat 	
				WHERE SW_MEMBER =  @MaThuaDat)
			IF (@@ERROR <> 0)
				BEGIN
					ROLLBACK TRANSACTION
					RETURN
				END
			ELSE
				BEGIN
					-- Xóa thửa đất bị NẮN CHỈNH khỏi bảng hiện thời
					--(TblDLieuKGianThuaDat)
					DELETE FROM TblDLieuKGianThuaDat
					WHERE (SW_MEMBER = @MaThuaDat)
					IF (@@ERROR <> 0)
						BEGIN
							ROLLBACK TRANSACTION
							RETURN
						END 
					ELSE
						BEGIN
							COMMIT TRANSACTION
						END
				END
		END

	PRINT ''Da Them''
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinThuaTuNhien]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích: Truy vấn thông tin tự nhiên của thửa đất

CREATE PROC [dbo].[spSelectThongTinThuaTuNhien]
	@MaThuaDat NVARCHAR (50) = NULL,
	@ToBanDo NVARCHAR(50) = NULL,
	@SoThua NVARCHAR(50) = NULL,
	@DienTichTuNhien NVARCHAR(50) = NULL
AS 
	SET NOCOUNT ON
	DECLARE @IsExit INT
	SET @IsExit = 1

	-- Liet ke danh sach thua dat
	SELECT  ToBanDo ,SoThua ,DienTichTuNhien,DanhSachMaThuaDatCha
	FROM   tblDLieuKGianThuaDat
	WHERE  1 = 1
	AND (CASE @MaThuaDat
		WHEN '''' THEN @MaThuaDat  ELSE SW_MEMBER END) = @MaThuaDat

	SET NOCOUNT OFF' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLuuLichSuBienDongThuaDat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan Chung
-- Create date: 15/07/2010
-- Description:	them moi lich su thua dat vao bang lich su khi tach ghep
-- =============================================
CREATE PROCEDURE [dbo].[spLuuLichSuBienDongThuaDat]
@flag int =null,
@MaThuaDat nvarchar(200)=null,
@MaThuaDatCha nvarchar(200)=null,
@MaHoSoCapGCN nvarchar(200)=null,
@LoaiBienDong nvarchar(20)=null
AS
BEGIN
--truong hop tach
--@mathuadat =''_101,102,103''
--#tmpMaHoSoCapGCN =''201,202,203''
--		create table #tmpMaTD(MaThuaDat nvarchar(20),MaCha bit)
--		--tach xau mathuadat va mahosocapGCN thanh mang nhieu doi tuong
--			declare @MaTD nvarchar(10)
--			declare @MaHS nvarchar(10)
--			declare @MaCha nvarchar(1)
--			DECLARE crSoHD CURSOR FOR    select itemID from dbo.split(@mathuadat,'','')
--			OPEN crSoHD
--			FETCH NEXT FROM crSoHD INTO @MaTD
--				WHILE @@FETCH_STATUS = 0
--				BEGIN
--			--insert ma thua dat vao bang tam
--				if substring(@MaTD,0,1)=''_''
--					begin
--						set @MaCha = ''1''
--					end
--				else
--					begin
--						set @MaCha = ''0''
--					end
--
--				insert into #tmpMaTD values(@MaTD,@MaCha)
--
--			FETCH NEXT FROM crSoHD INTO @MaTD
--			end
--			CLOSE crSoHD
--			DEALLOCATE crSoHD
--
--		declare @ThuaDatCha nvarchar(100)
--		declare @ThuaDatCon nvarchar(100)
--	if @LoaiBienDong =''tach''-- loai bien dong =1
--		begin
--			--neu tach thi thua cha chi la 1 thua
--			DECLARE crSoHD CURSOR FOR    select MaThuaDat,MaCha from #tmpMaTD 
--			OPEN crSoHD
--			FETCH NEXT FROM crSoHD INTO @MaTD,@MaCha
--				WHILE @@FETCH_STATUS = 0
--				BEGIN			
--					if @macha =''1''					
--						begin
--							set @ThuaDatCha = @maTD
--						end
--					else
--						begin
--							set @ThuaDatCon = @maTD
--						end
--			FETCH NEXT FROM crSoHD INTO @MaTD,@MaCha
--			end
--			CLOSE crSoHD
--			DEALLOCATE crSoHD
--			insert into TBLDLIEUKGIANTHUADATLICHSU( NgayBienDong,LoaiBienDong,ToBanDo, SoThua, DienTichTuNhien, featureID, TYLEIN, Status, MaDonViHanhChinh, MI_STYLE, SW_MEMBER, SW_GEOMETRY, DanhSachMaThuaDatCha)
--				  select getdate(),''1'',ToBanDo, SoThua, DienTichTuNhien, featureID, TYLEIN, Status, MaDonViHanhChinh,  MI_STYLE, @ThuaDatCha, SW_GEOMETRY,@ThuaDatCon	
--					FROM dbo.tblDLieuKGianThuaDat where SW_MEMBER = @MaTD
--		end
--	if @LoaiBienDong =''ghep''-- loai bien dong =0
--		begin
--	--neu gop thi thua cha chi la nhieu thua
--			print ''''
--		end
--drop table #tmpMaTD

--insert thua dat cha vao truoc sau do update danh sach thua dat duoc tach hoac ghep vao truong DanhSachMaThuaDatCha
if @flag =0
		begin
			insert into TBLDLIEUKGIANTHUADATLICHSU( NgayBienDong,LoaiBienDong,ToBanDo, SoThua, DienTichTuNhien, featureID, TYLEIN, Status, MaDonViHanhChinh, MI_STYLE, SW_MEMBER, SW_GEOMETRY)
				  select getdate(),@LoaiBienDong,ToBanDo, SoThua, DienTichTuNhien, featureID, TYLEIN, Status, MaDonViHanhChinh,  MI_STYLE, SW_MEMBER, SW_GEOMETRY
					FROM dbo.tblDLieuKGianThuaDat where SW_MEMBER = @MaThuaDat
		end
if @flag =1
		begin
			update TBLDLIEUKGIANTHUADATLICHSU set DanhSachMaThuaDatCha =@MaThuaDatCha where SW_MEMBER= @MaThuaDat
		end
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteDLieuKGianThuaDatByGhep]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Vũ Lê Thành
-- Create date: 20091103
-- Description:	Xóa các thửa đất bị GHÉP trên bảng 
-- các thửa đất hiện thời (tblDLieuKGianThuaDat)
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteDLieuKGianThuaDatByGhep]
	-- Add the parameters for the stored procedure here
	@xml XML
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	DECLARE @idoc int
	EXEC sp_xml_preparedocument @idoc OUTPUT,@xml


	DELETE TblDLieuKGianThuaDat 
	FROM OPENXML(@idoc,''/root/TblDLieuKGianThuaDat'')
	WITH(
			ToBanDo	varchar(50)	''ToBanDo''
			,SoThua	varchar(500)	''SoThua''
			,DienTichTuNhien	decimal(19, 1)	''DienTichTuNhien''
			,featureID	varchar(100)	''featureID''
			,TYLEIN	float	''TYLEIN''
			,Status	int	''Status''
			,MaDonViHanhChinh	int	''MaDonViHanhChinh''
			,MI_STYLE	varchar(254)	''MI_STYLE''
			,SW_MEMBER	int	''SW_MEMBER''
			,SW_GEOMETRY	image	''SW_GEOMETRY''
			,DanhSachMaThuaDatCha	nvarchar(500) ''DanhSachMaThuaDatCha''
		) AS xmlTable
	WHERE
		 TblDLieuKGianThuaDat.SW_MEMBER=xmlTable.SW_MEMBER
	EXEC sp_xml_removedocument @idoc
	PRINT ''Đã xóa''
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectMaHoSoCapGCNByToBanDoSoThuaInBanDo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		pham xuan chung	
-- Create date: 12/5/2010
-- Description:	lay thong tin ho so theo to ban do va so thua trong bang du lieu khong gian thua dat
-- =============================================
create PROCEDURE [dbo].[spSelectMaHoSoCapGCNByToBanDoSoThuaInBanDo]
	-- Add the parameters for the stored procedure h
@MaThuaDat nvarchar(20)=null,
@DienTichTuNhien nvarchar(20)=null,
	@ToBanDo nvarchar(10)=null,
	@SoThua nvarchar(10)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT SW_MEMBER as MaThuaDat, ToBanDo ,SoThua ,DienTichTuNhien,DanhSachMaThuaDatCha
	FROM   tblDLieuKGianThuaDat
where ToBanDo=@ToBanDo and SoThua=@SoThua
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spThongTinThuaTuNhien]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Ngày tạo gần nhất: 200807
--Người tạo: Vũ Lê Thành,
--Mục đích:

CREATE PROC [dbo].[spThongTinThuaTuNhien]
	@flag tinyint,
	@MaThuaDat nvarchar (50),
	@ToBanDo nvarchar(50),
	@SoThua nvarchar(50),
	@DienTichTuNhien nvarchar(50)
as 
	set nocount on
	declare @IsExit int
	set @IsExit = 1

	-- Liet ke danh sach thua dat
	if @flag = 0 
			select  ToBanDo ,SoThua as SoThua,DienTichTuNhien
			 from   tblDLieuKGianThuaDat
			where  1 = 1
			and (case @MaThuaDat
				when '''' then @MaThuaDat  else SW_MEMBER end) = @MaThuaDat
--			and (case @ToBanDo
--				when '''' then @ToBanDo  else ToBanDo end) = @ToBanDo
--			and (case @SoThua
--				when '''' then @SoThua else SoThua end) = @SoThua
--			and (case @DienTichTuNhien
--				when '''' then @DienTichTuNhien else DienTichTuNhien end) = @DienTichTuNhien
	
	set nocount off' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTimKiemLichSu]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--Created:03/16/2009
--Author:Pham Xuan Chung
--Desc: This store procedure is generated by SQLAutoScripting  script engine. Version:1.0.2.7374
CREATE procedure [dbo].[spTimKiemLichSu]
@flag tinyint,
	@MaDonViHanhChinh nvarchar (50),
	@ToBanDo nvarchar(50),
	@SoThua nvarchar(50),
	@HoanTatHoSoKeKhai nvarchar(50),
	@HoanTatThamDinh nvarchar(50),
	@HoanTatPheDuyet nvarchar(50),
	@SoPhatHanhGCN nvarchar (50),
	@SoVaoSoCapGCN nvarchar(50),
	@SoQuyetDinhCapGCN nvarchar (50),
	@HoanTatCapGCN nvarchar (50),
	@TenChuSuDung nvarchar (50),
	@SoDinhDanh nvarchar (50)
as 
	set nocount on
	declare @IsExit int
	set @IsExit = 1
	declare @TempTenChuSuDung nvarchar(500)
	set @TempTenChuSuDung  =  ''%'' + @TenChuSuDung + ''%''
	-- Liet ke danh sach thua dat
	if @flag = 0 
		Begin
			if @TenChuSuDung = ''''
				Begin
					select  distinct  b.MaHoSoCapGCN as MaHoSoCapGCN , a.ToBanDo, a.SoThua,a.DienTichTuNhien,b.ToBanDo as ToBanDoKeKhai
					,b.SoThua as SoThuaKeKhai,b.DienTichTuNhien as DienTichTuNhienKeKhai,b.DiaChiThua	,a.SW_MEMBER as MaThuaDat 
					 from  tblDLieuKGianThuaDat  a
					--Lien ket voi bang tblHoSoCapGCN
					left  join tblLichSuHoSoCapGCN as b on (b.MaThuaDat = a.SW_MEMBER)
					--Lien ket voi bang tblChuSuDung
					left join tblLichSuChuSuDungDat as c on (c.MaHoSoCapGCN = b.MaHoSoCapGCN)		
					where  1 = 1
					and (case @MaDonViHanhChinh
						when '''' then @MaDonViHanhChinh  else convert(nvarchar,a.MaDonViHanhChinh) end) = @MaDonViHanhChinh
					and (case @ToBanDo
						when '''' then @ToBanDo  else a.ToBanDo end) = @ToBanDo
					and (case @SoThua
						when '''' then @SoThua else a.SoThua end) = @SoThua
					and (case @HoanTatHoSoKeKhai
						when '''' then @HoanTatHoSoKeKhai  else b.HoanTatHoSoKeKhai end) = @HoanTatHoSoKeKhai
					and (case @HoanTatThamDinh
						when '''' then @HoanTatThamDinh  else b.HoanTatThamDinh end) = @HoanTatThamDinh
					and (case @HoanTatPheDuyet
						when '''' then @HoanTatPheDuyet else b.HoanTatPheDuyet end) = @HoanTatPheDuyet
					and (case @SoPhatHanhGCN
						when '''' then @SoPhatHanhGCN  else b.SoPhatHanhGCN end) = @SoPhatHanhGCN
					and (case @SoVaoSoCapGCN
						when '''' then @SoVaoSoCapGCN else b.SoVaoSoCapGCN end) = @SoVaoSoCapGCN
					and (case @SoQuyetDinhCapGCN
						when '''' then @SoQuyetDinhCapGCN else b.SoQuyetDinhCapGCN end) = @SoQuyetDinhCapGCN
					and (case @HoanTatCapGCN
						when '''' then @HoanTatCapGCN else b.HoanTatCapGCN end) = @HoanTatCapGCN
					and (@TenChuSuDung  = @TenChuSuDung)
					and (case @SoDinhDanh
						when '''' then @SoDinhDanh else c.SoDinhDanh end) = @SoDinhDanh
				End
			else
				Begin
					select  distinct  b.MaHoSoCapGCN as MaHoSoCapGCN , a.ToBanDo, a.SoThua,a.DienTichTuNhien,b.ToBanDo as ToBanDoKeKhai
					,b.SoThua as SoThuaKeKhai,b.DienTichTuNhien as DienTichTuNhienKeKhai,b.DiaChiThua	,a.SW_MEMBER as MaThuaDat 
					from  tblDLieuKGianThuaDat  a
					--Lien ket voi bang tblHoSoCapGCN
					left  join tblLichSuHoSoCapGCN as b on (b.MaThuaDat = a.SW_MEMBER)
					--Lien ket voi bang tblChuSuDung
					left join tblLichSuChuSuDungDat as c on (c.MaHoSoCapGCN = b.MaHoSoCapGCN)		
					where  1 = 1
					and (case @ToBanDo
						when '''' then @ToBanDo  else a.ToBanDo end) = @ToBanDo
					and (case @SoThua
						when '''' then @SoThua else a.SoThua end) = @SoThua
					and (case @HoanTatHoSoKeKhai
						when '''' then @HoanTatHoSoKeKhai  else b.HoanTatHoSoKeKhai end) = @HoanTatHoSoKeKhai
					and (case @HoanTatThamDinh
						when '''' then @HoanTatThamDinh  else b.HoanTatThamDinh end) = @HoanTatThamDinh
					and (case @HoanTatPheDuyet
						when '''' then @HoanTatPheDuyet else b.HoanTatPheDuyet end) = @HoanTatPheDuyet
					and (case @SoPhatHanhGCN
						when '''' then @SoPhatHanhGCN  else b.SoPhatHanhGCN end) = @SoPhatHanhGCN
					and (case @SoVaoSoCapGCN
						when '''' then @SoVaoSoCapGCN else b.SoVaoSoCapGCN end) = @SoVaoSoCapGCN
					and (case @SoQuyetDinhCapGCN
						when '''' then @SoQuyetDinhCapGCN else b.SoQuyetDinhCapGCN end) = @SoQuyetDinhCapGCN
					and (case @HoanTatCapGCN
						when '''' then @HoanTatCapGCN else b.HoanTatCapGCN end) = @HoanTatCapGCN
					and ( c.HoTen like  @TempTenChuSuDung )
					and (case @SoDinhDanh
						when '''' then @SoDinhDanh else c.SoDinhDanh end) = @SoDinhDanh
				End
		End
	set nocount off' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dt_addtosourcecontrol]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[dt_addtosourcecontrol]
    @vchSourceSafeINI varchar(255) = '''',
    @vchProjectName   varchar(255) ='''',
    @vchComment       varchar(255) ='''',
    @vchLoginName     varchar(255) ='''',
    @vchPassword      varchar(255) =''''

as

set nocount on

declare @iReturn int
declare @iObjectId int
select @iObjectId = 0

declare @iStreamObjectId int
select @iStreamObjectId = 0

declare @VSSGUID varchar(100)
select @VSSGUID = ''SQLVersionControl.VCS_SQL''

declare @vchDatabaseName varchar(255)
select @vchDatabaseName = db_name()

declare @iReturnValue int
select @iReturnValue = 0

declare @iPropertyObjectId int
declare @vchParentId varchar(255)

declare @iObjectCount int
select @iObjectCount = 0

    exec @iReturn = sp_OACreate @VSSGUID, @iObjectId OUT
    if @iReturn <> 0 GOTO E_OAError


    /* Create Project in SS */
    exec @iReturn = sp_OAMethod @iObjectId,
                                ''AddProjectToSourceSafe'',
                                NULL,
                                @vchSourceSafeINI,
                                @vchProjectName output,
                                @@SERVERNAME,
                                @vchDatabaseName,
                                @vchLoginName,
                                @vchPassword,
                                @vchComment


    if @iReturn <> 0 GOTO E_OAError

    exec @iReturn = sp_OAGetProperty @iObjectId, ''GetStreamObject'', @iStreamObjectId OUT

    if @iReturn <> 0 GOTO E_OAError

    /* Set Database Properties */

    begin tran SetProperties

    /* add high level object */

    exec @iPropertyObjectId = dbo.dt_adduserobject_vcs ''VCSProjectID''

    select @vchParentId = CONVERT(varchar(255),@iPropertyObjectId)

    exec dbo.dt_setpropertybyid @iPropertyObjectId, ''VCSProjectID'', @vchParentId , NULL
    exec dbo.dt_setpropertybyid @iPropertyObjectId, ''VCSProject'' , @vchProjectName , NULL
    exec dbo.dt_setpropertybyid @iPropertyObjectId, ''VCSSourceSafeINI'' , @vchSourceSafeINI , NULL
    exec dbo.dt_setpropertybyid @iPropertyObjectId, ''VCSSQLServer'', @@SERVERNAME, NULL
    exec dbo.dt_setpropertybyid @iPropertyObjectId, ''VCSSQLDatabase'', @vchDatabaseName, NULL

    if @@error <> 0 GOTO E_General_Error

    commit tran SetProperties

    declare cursorProcNames cursor for
        select convert(varchar(255), name) from sysobjects where type = ''P'' and name not like ''dt_%''
    open cursorProcNames

    while 1 = 1
    begin
        declare @vchProcName varchar(255)
        fetch next from cursorProcNames into @vchProcName
        if @@fetch_status <> 0
            break

        select colid, text into #ProcLines
        from syscomments
        where id = object_id(@vchProcName)
        order by colid

        declare @iCurProcLine int
        declare @iProcLines int
        select @iCurProcLine = 1
        select @iProcLines = (select count(*) from #ProcLines)
        while @iCurProcLine <= @iProcLines
        begin
            declare @pos int
            select @pos = 1
            declare @iCurLineSize int
            select @iCurLineSize = len((select text from #ProcLines where colid = @iCurProcLine))
            while @pos <= @iCurLineSize
            begin
                declare @vchProcLinePiece varchar(255)
                select @vchProcLinePiece = convert(varchar(255),
                    substring((select text from #ProcLines where colid = @iCurProcLine),
                              @pos, 255 ))
                exec @iReturn = sp_OAMethod @iStreamObjectId, ''AddStream'', @iReturnValue OUT, @vchProcLinePiece
                if @iReturn <> 0 GOTO E_OAError
                select @pos = @pos + 255
            end
            select @iCurProcLine = @iCurProcLine + 1
        end
        drop table #ProcLines

        exec @iReturn = sp_OAMethod @iObjectId,
                                    ''CheckIn_StoredProcedure'',
                                    NULL,
                                    @sProjectName = @vchProjectName,
                                    @sSourceSafeINI = @vchSourceSafeINI,
                                    @sServerName = @@SERVERNAME,
                                    @sDatabaseName = @vchDatabaseName,
                                    @sObjectName = @vchProcName,
                                    @sComment = @vchComment,
                                    @sLoginName = @vchLoginName,
                                    @sPassword = @vchPassword,
                                    @iVCSFlags = 0,
                                    @iActionFlag = 0,
                                    @sStream = ''''

        if @iReturn = 0 select @iObjectCount = @iObjectCount + 1

    end

CleanUp:
	close cursorProcNames
	deallocate cursorProcNames
    select @vchProjectName
    select @iObjectCount
    return

E_General_Error:
    /* this is an all or nothing.  No specific error messages */
    goto CleanUp

E_OAError:
    exec dbo.dt_displayoaerror @iObjectId, @iReturn
    goto CleanUp' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinThuaDatBySoanHS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Pham Xuan CHung
-- Create date: 2/8/2010
-- Description:	Update thong tin thua dat vao ban soan
-- =============================================
CREATE PROCEDURE  [dbo].[spUpdateThongTinThuaDatBySoanHS]
	@MaThuaDat bigint =null,
	@ToBanDo nvarchar(30)=null,
	@SoThua nvarchar(20)=null,
	@DienTich nvarchar(20)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update tblSoanHoSoThuaDat set ToBanDo =@ToBanDo , SoThua =@soThua , dienTich =@DienTich where FeatureID = @MaThuaDat
END
' 
END
