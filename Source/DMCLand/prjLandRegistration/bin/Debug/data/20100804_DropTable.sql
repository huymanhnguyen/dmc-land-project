IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTheChapBaoLanh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spTheChapBaoLanh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteChuByGDCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteChuByGDCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienNguoiThamDinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateTuDienNguoiThamDinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectHoSoCapGCNByMaThuaDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectHoSoCapGCNByMaThuaDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteChuByTCDN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteChuByTCDN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienNguoiXetDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateTuDienNguoiXetDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectHoSoCapGCNByMaVach]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectHoSoCapGCNByMaVach]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectMaHoSoCapGCNByToBanDoSoThua]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectMaHoSoCapGCNByToBanDoSoThua]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteChuDeNghiCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteChuDeNghiCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienNguonGocSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateTuDienNguonGocSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectHuyenTinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectHuyenTinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinChuByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinChuByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteChuHoSoCapGCNCQNNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteChuHoSoCapGCNCQNNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienTieuDeKyGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateTuDienTieuDeKyGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectLichSuThuaDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectLichSuThuaDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinHoSoByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinHoSoByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteChuHoSoCapGCNGDCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteChuHoSoCapGCNGDCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateXML]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateXML]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectMaCoQuanThucHienChinhLy]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectMaCoQuanThucHienChinhLy]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectKetQuaThamDinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectKetQuaThamDinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteChuHoSoCapGCNTCDNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteChuHoSoCapGCNTCDNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateYeuCauBoXung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateYeuCauBoXung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectMucDich]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectMucDich]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectMaHoSoCapGCNByToBanDoSoThuaInBanDo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectMaHoSoCapGCNByToBanDoSoThuaInBanDo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteCongTrinhXayDungByMaCongTrinhXayDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteCongTrinhXayDungByMaCongTrinhXayDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserChucNang]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUserChucNang]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectNguonGocChiTietByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectNguonGocChiTietByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTrangThaiHSCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTrangThaiHSCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteDangKyBienDongByMaDangKyBienDong]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteDangKyBienDongByMaDangKyBienDong]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUsers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUsers]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectNguonGocSuDungDatByMaThuaDatCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectNguonGocSuDungDatByMaThuaDatCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteDangKyBienDongByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteDangKyBienDongByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUserStatus]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectNhaOByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectNhaOByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteDLieuKGianThuaDatByGhep]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteDLieuKGianThuaDatByGhep]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spYeuCauBoXung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spYeuCauBoXung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectNoiDungThayDoi]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectNoiDungThayDoi]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteGhiChuNoiDungChuDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteGhiChuNoiDungChuDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectRptGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectRptGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteHangMucCongTrinhByMaCongTrinhXayDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteHangMucCongTrinhByMaCongTrinhXayDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectSoDoNhaDatByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectSoDoNhaDatByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteHangMucCongTrinhByMaHangMucCongTrinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteHangMucCongTrinhByMaHangMucCongTrinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectSoHoSoGocLonNhatByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectSoHoSoGocLonNhatByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteHoiDongXetDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteHoiDongXetDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectSoThuTuVaoSoCapGCNLonNhatTheoCapTinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectSoThuTuVaoSoCapGCNLonNhatTheoCapTinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteMaCoQuanThucHien]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteMaCoQuanThucHien]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectSoThuTuVaoSoCapGCNLonNhatTheoCapXa]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectSoThuTuVaoSoCapGCNLonNhatTheoCapXa]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteMucDichByMaMucDichSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteMucDichByMaMucDichSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTaiLieuKemTheoByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTaiLieuKemTheoByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteNguonGocSuDungDatByMaNguonGoc]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteNguonGocSuDungDatByMaNguonGoc]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTaiLieuKemTheoByMaTaiLieuKemTheo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTaiLieuKemTheoByMaTaiLieuKemTheo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteNguonGocSuDungDatByMaThuaDatCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteNguonGocSuDungDatByMaThuaDatCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThamDinhThongTinPhapLyKhacByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThamDinhThongTinPhapLyKhacByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteNhaOByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteNhaOByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTheoChuSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTheoChuSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteNhaOByMaNhaO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteNhaOByMaNhaO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTheoHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTheoHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteSoDoNhaDatThamDinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteSoDoNhaDatThamDinhByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongBaoCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongBaoCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTaiLieuKemTheoByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteTaiLieuKemTheoByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinBoXung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinBoXung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTaiLieuKemTheoByMaTaiLieuKemTheo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteTaiLieuKemTheoByMaTaiLieuKemTheo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLuuLichSuBienDongThuaDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLuuLichSuBienDongThuaDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinCanBoThamDinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinCanBoThamDinhByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThamDinhThongTinPhapLyKhacByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThamDinhThongTinPhapLyKhacByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinCayLauNamByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinCayLauNamByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongBaoCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongBaoCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinCayLauNamDangKyCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinCayLauNamDangKyCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongInTraGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongInTraGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinCayLauNamDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinCayLauNamDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinBoXungByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinBoXungByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinBoXungByMaYeuCauBoXung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinBoXungByMaYeuCauBoXung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinHangMucCongTrinhDangKyCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinHangMucCongTrinhDangKyCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinCanBoThamDinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinCanBoThamDinhByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinHangMucCongTrinhDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinHangMucCongTrinhDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinCayLauNamByMaHoSoCapGCN0]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinCayLauNamByMaHoSoCapGCN0]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinKiemKeByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinKiemKeByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinCayLauNamByMaThongTinCayLauNam]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinCayLauNamByMaThongTinCayLauNam]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinKyGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinKyGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinCayLauNamDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinCayLauNamDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinLichSuChuSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinLichSuChuSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinLichSuKiemKe]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinLichSuKiemKe]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinHangMucCongTrinhDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinHangMucCongTrinhDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinLichSuMucDichSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinLichSuMucDichSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinKiemKeByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinKiemKeByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinLichSuNguonGocSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinLichSuNguonGocSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinKiemKeByMaKiemKe]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinKiemKeByMaKiemKe]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinLichSuQuiHoach]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinLichSuQuiHoach]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinKyGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinKyGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinBienDongThuaDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinBienDongThuaDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinLichSuTaiLieuKemTheo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinLichSuTaiLieuKemTheo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinNhaODeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinNhaODeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinMaVach]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinMaVach]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinPheDuyetByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinPheDuyetByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinNhaODangKyCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinNhaODangKyCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinQuiHoachByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinQuiHoachByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinNhaODeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinNhaODeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinQuiHoachByMaThongTinQuiHoach]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinQuiHoachByMaThongTinQuiHoach]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinPheDuyetByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinPheDuyetByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinQuyetDinhCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinQuyetDinhCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateStatusMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateStatusMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinQuiHoachByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinQuiHoachByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinRungCayByMaHoSoCapGCN0]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinRungCayByMaHoSoCapGCN0]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTrangThaiHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTrangThaiHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinQuiTrinhCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinQuiTrinhCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinRungCayByMaThongTinRungCay]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinRungCayByMaThongTinRungCay]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinQuyetDinhCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinQuyetDinhCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinRungCayDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinRungCayDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinRungCayByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinRungCayByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinSoCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinSoCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinRungCayDangKyCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinRungCayDangKyCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinRungCayDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinRungCayDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinTiepNhanByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinTiepNhanByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinSoCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinSoCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThongTinToTrinhDiaChinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThongTinToTrinhDiaChinhByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinThuaDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinThuaDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteThuaDatCapGCNByMaThuaDatCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteThuaDatCapGCNByMaThuaDatCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinQuyetDinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinQuyetDinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinThuaDatDangKyCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinThuaDatDangKyCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienDoiTuongSuDungDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteTuDienDoiTuongSuDungDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienLoaiHinhBienDong]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteTuDienLoaiHinhBienDong]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinThuaTuNhien]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinThuaTuNhien]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienMucDichSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteTuDienMucDichSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinTiepNhanHoSoByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinTiepNhanHoSoByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienNghiaVuTaiChinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteTuDienNghiaVuTaiChinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinToTrinhDiaChinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinToTrinhDiaChinhByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienNguoiKyGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteTuDienNguoiKyGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinTraGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinTraGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienNguoiPheDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteTuDienNguoiPheDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThuaDatCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThuaDatCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienNguoiThamDinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteTuDienNguoiThamDinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThuaDatCapGCNWithHoSoKyThuat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThuaDatCapGCNWithHoSoKyThuat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienNguoiXetDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteTuDienNguoiXetDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThuTuHoSoBienDongLonNhat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThuTuHoSoBienDongLonNhat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienNguonGocSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteTuDienNguonGocSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProcLayChucNangTheoNguoiDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ProcLayChucNangTheoNguoiDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTraCuuChuByCQNN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTraCuuChuByCQNN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteTuDienTieuDeKyGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteTuDienTieuDeKyGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTraCuuChuByGDCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTraCuuChuByGDCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteYeuCauBoXungByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteYeuCauBoXungByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTraCuuChuByTCDN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTraCuuChuByTCDN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteYeuCauBoXungByMaYeuCauBoXung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteYeuCauBoXungByMaYeuCauBoXung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spThongTinBienDongHoSo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spThongTinBienDongHoSo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienDoiTuongSuDungDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTuDienDoiTuongSuDungDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetMaDVHC]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spGetMaDVHC]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienDonViHanhChinhByMaXa]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTuDienDonViHanhChinhByMaXa]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGroupFunction]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spGroupFunction]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinChuSuDungByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinChuSuDungByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienLoaiHinhBienDong]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTuDienLoaiHinhBienDong]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertChuDangKyCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertChuDangKyCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinNhaO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinNhaO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienMucDichSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTuDienMucDichSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertChuDeNghiCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertChuDeNghiCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinThuaDatByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinThuaDatByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienNghiaVuTaiChinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTuDienNghiaVuTaiChinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertChuHoSoCapGCNCQNNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertChuHoSoCapGCNCQNNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienNguoiKyGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTuDienNguoiKyGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertChuHoSoCapGCNGDCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertChuHoSoCapGCNGDCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinTranhChapKhieuKienByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinTranhChapKhieuKienByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinThuaDatBySoanHS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinThuaDatBySoanHS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienNguoiPheDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTuDienNguoiPheDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertChuHoSoCapGCNTCDNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertChuHoSoCapGCNTCDNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinCanBoPheDuyetByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinCanBoPheDuyetByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienNguoiThamDinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTuDienNguoiThamDinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertCongTrinhXayDungByMaCongTrinhXayDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertCongTrinhXayDungByMaCongTrinhXayDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinNguoiKyGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinNguoiKyGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienNguoiXetDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTuDienNguoiXetDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertDangKyBienDong]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertDangKyBienDong]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinNguoiKyGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinNguoiKyGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienNguonGocSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTuDienNguonGocSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertDangKyBienDongByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertDangKyBienDongByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienPhieuThamDinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTuDienPhieuThamDinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertDLieuKGianThuaDatLichSuByGhep]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertDLieuKGianThuaDatLichSuByGhep]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienTieuDeKyGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTuDienTieuDeKyGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertDLieuKGianThuaDatLichSuByNanChinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertDLieuKGianThuaDatLichSuByNanChinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienTrangThaiKeKhai]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTuDienTrangThaiKeKhai]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertDLieuKGianThuaDatLichSuByTachThua]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertDLieuKGianThuaDatLichSuByTachThua]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienTrangThaiPheDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTuDienTrangThaiPheDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertHangMucCongTrinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertHangMucCongTrinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienTrangThaiThamDinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTuDienTrangThaiThamDinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertHoiDongXetDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertHoiDongXetDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTuDienTrangThaiXetDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTuDienTrangThaiXetDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertHoSoCapGCNChuaCoThongTinKhongGianThuaDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertHoSoCapGCNChuaCoThongTinKhongGianThuaDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinNghiaVuTaiChinh_TranhChap_NguoiKyGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinNghiaVuTaiChinh_TranhChap_NguoiKyGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectUser]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertHoSoCapGCNDaCoThongTinKhongGianThuaDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertHoSoCapGCNDaCoThongTinKhongGianThuaDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinNhaOByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinNhaOByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectYeuCauBoXung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectYeuCauBoXung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertMaCoQuanThucHien]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertMaCoQuanThucHien]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertMucDich]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertMucDich]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTaiKhoanNguoiDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spTaiKhoanNguoiDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertNguonGocSuDungDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertNguonGocSuDungDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSoDiaChinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSoDiaChinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spThemChuSDDVaoChuTaiSan]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spThemChuSDDVaoChuTaiSan]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertNhaO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertNhaO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pro_AddUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[pro_AddUser]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spThongTinThuaTuNhien]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spThongTinThuaTuNhien]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTaiLieuKemTheo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertTaiLieuKemTheo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pro_AddUserStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[pro_AddUserStatus]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spThongTinXetDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spThongTinXetDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinBoXung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertThongTinBoXung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Cap]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Cap]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTimKiemLichSu]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spTimKiemLichSu]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinCanBoThamDinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertThongTinCanBoThamDinhByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_ChaConDVHC]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_ChaConDVHC]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTuDienChucNang]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spTuDienChucNang]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinCayLauNam0]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertThongTinCayLauNam0]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_GetCap]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_GetCap]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTuDienCoQuanChinhLyHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spTuDienCoQuanChinhLyHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinKiemKeByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertThongTinKiemKeByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_GetChaConDVHC]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_GetChaConDVHC]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTuDienDonViHanhChinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spTuDienDonViHanhChinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinPheDuyetByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertThongTinPheDuyetByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proc_GetTuDienDonViHanhChinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Proc_GetTuDienDonViHanhChinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTuDienGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spTuDienGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinQuiHoachByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertThongTinQuiHoachByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proc_KiemTraSuTonTai]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Proc_KiemTraSuTonTai]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTuDienQuyenDangNhap]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spTuDienQuyenDangNhap]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinQuyetDinhCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertThongTinQuyetDinhCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_LayDonViCha]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_LayDonViCha]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateChuHoSoCapGCNCQNNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateChuHoSoCapGCNCQNNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinRungCay]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertThongTinRungCay]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_LayDonViCon]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_LayDonViCon]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateChuHoSoCapGCNGDCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateChuHoSoCapGCNGDCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinTiepNhanByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertThongTinTiepNhanByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Test]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Test]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateChuHoSoCapGCNTCDNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateChuHoSoCapGCNTCDNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThongTinToTrinhDiaChinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertThongTinToTrinhDiaChinhByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectThongBaoHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectThongBaoHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procUserStatus_add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procUserStatus_add]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateCongTrinhXayDungByMaCongTrinhXayDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateCongTrinhXayDungByMaCongTrinhXayDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertThuaDatCapGCNByMaThuaDatCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertThuaDatCapGCNByMaThuaDatCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectInPhieuChuSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectInPhieuChuSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[respatialize]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[respatialize]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateDangKyBienDongByMaDangKyBienDong]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateDangKyBienDongByMaDangKyBienDong]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienDoiTuongSuDungDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertTuDienDoiTuongSuDungDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSoTheoDoiBienDong]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSoTheoDoiBienDong]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DanhSachToaDo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DanhSachToaDo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateGhiChuNoiDungChuDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateGhiChuNoiDungChuDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienLoaiHinhBienDong]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertTuDienLoaiHinhBienDong]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DeleteToTrinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_DeleteToTrinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateHangMucCongTrinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateHangMucCongTrinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienMucDichSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertTuDienMucDichSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InBienBanXetDuyetHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_InBienBanXetDuyetHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateHoSoCapGCNByHoSoKiThuatGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateHoSoCapGCNByHoSoKiThuatGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienNghiaVuTaiChinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertTuDienNghiaVuTaiChinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertDanhSachToaDoThuaDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_InsertDanhSachToaDoThuaDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateHoSoCapGCNByHoSoKiThuatThamDinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateHoSoCapGCNByHoSoKiThuatThamDinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienNguoiKyGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertTuDienNguoiKyGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertToTrinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_InsertToTrinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateHoSoCapGCNByMaVach]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateHoSoCapGCNByMaVach]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienNguoiPheDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertTuDienNguoiPheDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectThongTinBanDuThaoGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectThongTinBanDuThaoGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InSoMucKe]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_InSoMucKe]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateHoSoCapGCNBySoDoNhaDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateHoSoCapGCNBySoDoNhaDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienNguoiThamDinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertTuDienNguoiThamDinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTrangThaiHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateTrangThaiHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_NguoiLapBieu]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_NguoiLapBieu]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateMaCoQuanThucHien]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateMaCoQuanThucHien]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienNguoiXetDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertTuDienNguoiXetDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_QuanLyLog]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_QuanLyLog]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateMucDich]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateMucDich]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienNguonGocSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertTuDienNguonGocSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectGroupNghiaVuTaiChinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectGroupNghiaVuTaiChinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateNguonGocSuDungDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateNguonGocSuDungDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTuDienTieuDeKyGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertTuDienTieuDeKyGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectTrangThaiTiepNhanHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectTrangThaiTiepNhanHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectHoSoKyThuat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectHoSoKyThuat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateNhaO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateNhaO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertYeuCauBoXung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertYeuCauBoXung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectHoSoKyThuatBienBanXetDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectHoSoKyThuatBienBanXetDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTaiLieuKemTheoByMaTaiLieuKemTheo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateTaiLieuKemTheoByMaTaiLieuKemTheo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spNguoiXetDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spNguoiXetDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectInHoiDongXetDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectInHoiDongXetDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThamDinhThongTinPhapLyKhacByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThamDinhThongTinPhapLyKhacByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spPhieuThamDinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spPhieuThamDinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectInHoSoKyThuat_DanhSachToaDo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectInHoSoKyThuat_DanhSachToaDo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongBaoCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongBaoCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSaoChepThongTinLichSuChuSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSaoChepThongTinLichSuChuSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectInPhieuMucDichSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectInPhieuMucDichSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinBoXung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinBoXung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSaoChepThongTinLichSuKiemKe]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSaoChepThongTinLichSuKiemKe]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectInPhieuNguonGocSuDungDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectInPhieuNguonGocSuDungDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinCanBoThamDinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinCanBoThamDinhByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSaoChepThongTinLichSuMucDichSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSaoChepThongTinLichSuMucDichSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_selectInPhieuTaiSan]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_selectInPhieuTaiSan]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinCayLauNam0]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinCayLauNam0]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSaoChepThongTinLichSuNguonGocSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSaoChepThongTinLichSuNguonGocSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectInPhieuThongTinRung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectInPhieuThongTinRung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinCayLauNamDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinCayLauNamDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSaoChepThongTinLichSuQuiHoach]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSaoChepThongTinLichSuQuiHoach]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectMaThuaDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectMaThuaDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSaoChepThongTinLichSuTaiLieuKemTheo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSaoChepThongTinLichSuTaiLieuKemTheo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectMaXaByMaDVHC]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectMaXaByMaDVHC]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinHangMucCongTrinhDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinHangMucCongTrinhDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChucNangByMaNguoiDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectChucNangByMaNguoiDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectPhieuChuyenThongTinDiaChinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectPhieuChuyenThongTinDiaChinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinKiemKeByMaThongTinKiemKe]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinKiemKeByMaThongTinKiemKe]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChuDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectChuDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectTaiSanBienBanXetDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectTaiSanBienBanXetDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dt_addtosourcecontrol]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dt_addtosourcecontrol]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinKyGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinKyGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChuHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectChuHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_selectTenChu]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_selectTenChu]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinNhaODeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinNhaODeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChuHoSoCapGCNCQNNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectChuHoSoCapGCNCQNNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_selectThongTinDatInQuyetDinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_selectThongTinDatInQuyetDinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinPheDuyetByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinPheDuyetByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChuHoSoCapGCNGDCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectChuHoSoCapGCNGDCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectThongTinToTrinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectThongTinToTrinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsert10ThuaDatMoiThaoTac]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsert10ThuaDatMoiThaoTac]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinQuiHoachByMaThongTinQuiHoach]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinQuiHoachByMaThongTinQuiHoach]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChuHoSoCapGCNTCDNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectChuHoSoCapGCNTCDNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectTongHopChuSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectTongHopChuSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinQuyetDinhCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinQuyetDinhCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChuHoSoDangKyCapGCNCQNNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectChuHoSoDangKyCapGCNCQNNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SelectToTrinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SelectToTrinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinRungCay]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinRungCay]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChuHoSoDangKyCapGCNGDCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectChuHoSoDangKyCapGCNGDCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SeletAllHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SeletAllHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinRungCayDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinRungCayDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectChuHoSoDangKyCapGCNTCDNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectChuHoSoDangKyCapGCNTCDNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinSoCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinSoCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectCongTrinhXayDungByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectCongTrinhXayDungByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectDangKyBienDongByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectDangKyBienDongByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinTiepNhanByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinTiepNhanByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectDanhSachChuDangKyCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectDanhSachChuDangKyCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinToTrinhDiaChinhByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinToTrinhDiaChinhByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectDiaChiThuaDatByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectDiaChiThuaDatByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_UpdateNhomHoSoTrinhPhuong]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_UpdateNhomHoSoTrinhPhuong]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelect10ThuaDatMoiThaoTac]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelect10ThuaDatMoiThaoTac]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThongTinTraGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThongTinTraGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectDonViHanhChinhByMaNguoiDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectDonViHanhChinhByMaNguoiDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_UpdateToTrinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_UpdateToTrinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateThuaDatCapGCNByMaThuaDatCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateThuaDatCapGCNByMaThuaDatCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectGCNThongTinNhaODeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectGCNThongTinNhaODeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_UpdateTraGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_UpdateTraGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienDoiTuongSuDungDat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateTuDienDoiTuongSuDungDat]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectGCNThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectGCNThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_XuLyChuSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_XuLyChuSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienLoaiHinhBienDong]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateTuDienLoaiHinhBienDong]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectGhiChuNoiDungChuDeNghiCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectGhiChuNoiDungChuDeNghiCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBangMa]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spBangMa]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienMucDichSuDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateTuDienMucDichSuDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectGhiChuNoiDungChuDeNghiCapGCNByMaHoSoCapGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectGhiChuNoiDungChuDeNghiCapGCNByMaHoSoCapGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spChu]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spChu]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienNghiaVuTaiChinh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateTuDienNghiaVuTaiChinh]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectHangMucCongTrinhByMaCongTrinhXayDung]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectHangMucCongTrinhByMaCongTrinhXayDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spChuSuDungCursor]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spChuSuDungCursor]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienNguoiKyGCN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateTuDienNguoiKyGCN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSelectHoiDongXetDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSelectHoiDongXetDuyet]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteChuByCQNN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDeleteChuByCQNN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTuDienNguoiPheDuyet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdateTuDienNguoiPheDuyet]
