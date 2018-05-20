
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/10/2018 00:57:04
-- Generated from EDMX file: D:\Bài Tập Công Nghê Thông Tin\Năm 3\HKII\Đồ án 1\MVCShoesShop\MVCShoesShop\Models\DBShoesShop.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ShoesShop];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__CT_DON_DA__MaDDH__1B0907CE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_DON_DAT_HANG] DROP CONSTRAINT [FK__CT_DON_DA__MaDDH__1B0907CE];
GO
IF OBJECT_ID(N'[dbo].[FK__CT_DON_DAT__MaSP__1BFD2C07]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_DON_DAT_HANG] DROP CONSTRAINT [FK__CT_DON_DAT__MaSP__1BFD2C07];
GO
IF OBJECT_ID(N'[dbo].[FK__CT_HOA_DON__MaHD__1273C1CD]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_HOA_DON] DROP CONSTRAINT [FK__CT_HOA_DON__MaHD__1273C1CD];
GO
IF OBJECT_ID(N'[dbo].[FK__CT_HOA_DON__MaSP__1367E606]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_HOA_DON] DROP CONSTRAINT [FK__CT_HOA_DON__MaSP__1367E606];
GO
IF OBJECT_ID(N'[dbo].[FK__CT_PHIEU___MaPGH__2E1BDC42]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_PHIEU_GIAO_HANG] DROP CONSTRAINT [FK__CT_PHIEU___MaPGH__2E1BDC42];
GO
IF OBJECT_ID(N'[dbo].[FK__CT_PHIEU_G__MaSP__24927208]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_PHIEU_GIAO_HANG] DROP CONSTRAINT [FK__CT_PHIEU_G__MaSP__24927208];
GO
IF OBJECT_ID(N'[dbo].[FK__DON_DAT_HA__MaKH__182C9B23]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DON_DAT_HANG] DROP CONSTRAINT [FK__DON_DAT_HA__MaKH__182C9B23];
GO
IF OBJECT_ID(N'[dbo].[FK__HOA_DON__MaKH__0DAF0CB0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HOA_DON] DROP CONSTRAINT [FK__HOA_DON__MaKH__0DAF0CB0];
GO
IF OBJECT_ID(N'[dbo].[FK__PHIEU_GIAO__MaKH__2D27B809]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PHIEU_GIAO_HANG] DROP CONSTRAINT [FK__PHIEU_GIAO__MaKH__2D27B809];
GO
IF OBJECT_ID(N'[dbo].[FK__SAN_PHAM__MaLoai__08EA5793]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SAN_PHAM] DROP CONSTRAINT [FK__SAN_PHAM__MaLoai__08EA5793];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CT_DON_DAT_HANG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CT_DON_DAT_HANG];
GO
IF OBJECT_ID(N'[dbo].[CT_HOA_DON]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CT_HOA_DON];
GO
IF OBJECT_ID(N'[dbo].[CT_PHIEU_GIAO_HANG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CT_PHIEU_GIAO_HANG];
GO
IF OBJECT_ID(N'[dbo].[DangNhap]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DangNhap];
GO
IF OBJECT_ID(N'[dbo].[DON_DAT_HANG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DON_DAT_HANG];
GO
IF OBJECT_ID(N'[dbo].[HOA_DON]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HOA_DON];
GO
IF OBJECT_ID(N'[dbo].[KHACH_HANG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KHACH_HANG];
GO
IF OBJECT_ID(N'[dbo].[LOAI_SAN_PHAM]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LOAI_SAN_PHAM];
GO
IF OBJECT_ID(N'[dbo].[PHIEU_GIAO_HANG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PHIEU_GIAO_HANG];
GO
IF OBJECT_ID(N'[dbo].[SAN_PHAM]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SAN_PHAM];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CT_DON_DAT_HANG'
CREATE TABLE [dbo].[CT_DON_DAT_HANG] (
    [MaDDH] int  NOT NULL,
    [MaSP] int  NOT NULL,
    [SoLuong] int  NULL,
    [DonGia] decimal(19,4)  NULL,
    [ThanhTien] decimal(19,4)  NULL
);
GO

-- Creating table 'CT_HOA_DON'
CREATE TABLE [dbo].[CT_HOA_DON] (
    [MaCTHD] int IDENTITY(1,1) NOT NULL,
    [MaHD] int  NULL,
    [MaSP] int  NULL,
    [SoLuong] int  NULL,
    [DonGia] decimal(19,4)  NULL,
    [ThanhTien] decimal(19,4)  NULL
);
GO

-- Creating table 'CT_PHIEU_GIAO_HANG'
CREATE TABLE [dbo].[CT_PHIEU_GIAO_HANG] (
    [MaPGH] int  NOT NULL,
    [MaSP] int  NOT NULL,
    [SoLuong] decimal(19,4)  NULL,
    [DonGia] decimal(19,4)  NULL,
    [ThanhTien] decimal(19,4)  NULL
);
GO

-- Creating table 'DON_DAT_HANG'
CREATE TABLE [dbo].[DON_DAT_HANG] (
    [MaDDH] int IDENTITY(1,1) NOT NULL,
    [NgayLapDDH] datetime  NULL,
    [MaKH] int  NULL
);
GO

-- Creating table 'HOA_DON'
CREATE TABLE [dbo].[HOA_DON] (
    [MaHD] int IDENTITY(1,1) NOT NULL,
    [MaKH] int  NULL,
    [NgayLapHD] datetime  NULL,
    [HinhThucThanhToan] nvarchar(50)  NULL,
    [TongTien] decimal(19,4)  NULL
);
GO

-- Creating table 'KHACH_HANG'
CREATE TABLE [dbo].[KHACH_HANG] (
    [MaKH] int IDENTITY(1,1) NOT NULL,
    [TenKH] nvarchar(50)  NULL,
    [DiaChi] nvarchar(50)  NULL,
    [SDT] varchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [IDLogin] varchar(50)  NULL,
    [Pass] varchar(50)  NULL
);
GO

-- Creating table 'LOAI_SAN_PHAM'
CREATE TABLE [dbo].[LOAI_SAN_PHAM] (
    [MaLoaiSP] int IDENTITY(1,1) NOT NULL,
    [TenLoai] nvarchar(50)  NULL
);
GO

-- Creating table 'PHIEU_GIAO_HANG'
CREATE TABLE [dbo].[PHIEU_GIAO_HANG] (
    [MaPGH] int IDENTITY(1,1) NOT NULL,
    [MaKH] int  NULL,
    [GhiChu] nvarchar(max)  NULL
);
GO

-- Creating table 'SAN_PHAM'
CREATE TABLE [dbo].[SAN_PHAM] (
    [MaSP] int IDENTITY(1,1) NOT NULL,
    [TenSP] nvarchar(50)  NULL,
    [MaLoaiSP] int  NULL,
    [SoLuongCon] int  NULL,
    [DonGia] decimal(19,4)  NULL,
    [Images] nvarchar(50)  NULL
);
GO

-- Creating table 'DangNhaps'
CREATE TABLE [dbo].[DangNhaps] (
    [id] varchar(50)  NOT NULL,
    [Username] varchar(50)  NULL,
    [Pass] varchar(max)  NULL,
    [PhanQuyen] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MaDDH], [MaSP] in table 'CT_DON_DAT_HANG'
ALTER TABLE [dbo].[CT_DON_DAT_HANG]
ADD CONSTRAINT [PK_CT_DON_DAT_HANG]
    PRIMARY KEY CLUSTERED ([MaDDH], [MaSP] ASC);
GO

-- Creating primary key on [MaCTHD] in table 'CT_HOA_DON'
ALTER TABLE [dbo].[CT_HOA_DON]
ADD CONSTRAINT [PK_CT_HOA_DON]
    PRIMARY KEY CLUSTERED ([MaCTHD] ASC);
GO

-- Creating primary key on [MaPGH], [MaSP] in table 'CT_PHIEU_GIAO_HANG'
ALTER TABLE [dbo].[CT_PHIEU_GIAO_HANG]
ADD CONSTRAINT [PK_CT_PHIEU_GIAO_HANG]
    PRIMARY KEY CLUSTERED ([MaPGH], [MaSP] ASC);
GO

-- Creating primary key on [MaDDH] in table 'DON_DAT_HANG'
ALTER TABLE [dbo].[DON_DAT_HANG]
ADD CONSTRAINT [PK_DON_DAT_HANG]
    PRIMARY KEY CLUSTERED ([MaDDH] ASC);
GO

-- Creating primary key on [MaHD] in table 'HOA_DON'
ALTER TABLE [dbo].[HOA_DON]
ADD CONSTRAINT [PK_HOA_DON]
    PRIMARY KEY CLUSTERED ([MaHD] ASC);
GO

-- Creating primary key on [MaKH] in table 'KHACH_HANG'
ALTER TABLE [dbo].[KHACH_HANG]
ADD CONSTRAINT [PK_KHACH_HANG]
    PRIMARY KEY CLUSTERED ([MaKH] ASC);
GO

-- Creating primary key on [MaLoaiSP] in table 'LOAI_SAN_PHAM'
ALTER TABLE [dbo].[LOAI_SAN_PHAM]
ADD CONSTRAINT [PK_LOAI_SAN_PHAM]
    PRIMARY KEY CLUSTERED ([MaLoaiSP] ASC);
GO

-- Creating primary key on [MaPGH] in table 'PHIEU_GIAO_HANG'
ALTER TABLE [dbo].[PHIEU_GIAO_HANG]
ADD CONSTRAINT [PK_PHIEU_GIAO_HANG]
    PRIMARY KEY CLUSTERED ([MaPGH] ASC);
GO

-- Creating primary key on [MaSP] in table 'SAN_PHAM'
ALTER TABLE [dbo].[SAN_PHAM]
ADD CONSTRAINT [PK_SAN_PHAM]
    PRIMARY KEY CLUSTERED ([MaSP] ASC);
GO

-- Creating primary key on [id] in table 'DangNhaps'
ALTER TABLE [dbo].[DangNhaps]
ADD CONSTRAINT [PK_DangNhaps]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MaDDH] in table 'CT_DON_DAT_HANG'
ALTER TABLE [dbo].[CT_DON_DAT_HANG]
ADD CONSTRAINT [FK__CT_DON_DA__MaDDH__1B0907CE]
    FOREIGN KEY ([MaDDH])
    REFERENCES [dbo].[DON_DAT_HANG]
        ([MaDDH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MaSP] in table 'CT_DON_DAT_HANG'
ALTER TABLE [dbo].[CT_DON_DAT_HANG]
ADD CONSTRAINT [FK__CT_DON_DAT__MaSP__1BFD2C07]
    FOREIGN KEY ([MaSP])
    REFERENCES [dbo].[SAN_PHAM]
        ([MaSP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CT_DON_DAT__MaSP__1BFD2C07'
CREATE INDEX [IX_FK__CT_DON_DAT__MaSP__1BFD2C07]
ON [dbo].[CT_DON_DAT_HANG]
    ([MaSP]);
GO

-- Creating foreign key on [MaHD] in table 'CT_HOA_DON'
ALTER TABLE [dbo].[CT_HOA_DON]
ADD CONSTRAINT [FK__CT_HOA_DON__MaHD__1273C1CD]
    FOREIGN KEY ([MaHD])
    REFERENCES [dbo].[HOA_DON]
        ([MaHD])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CT_HOA_DON__MaHD__1273C1CD'
CREATE INDEX [IX_FK__CT_HOA_DON__MaHD__1273C1CD]
ON [dbo].[CT_HOA_DON]
    ([MaHD]);
GO

-- Creating foreign key on [MaSP] in table 'CT_HOA_DON'
ALTER TABLE [dbo].[CT_HOA_DON]
ADD CONSTRAINT [FK__CT_HOA_DON__MaSP__1367E606]
    FOREIGN KEY ([MaSP])
    REFERENCES [dbo].[SAN_PHAM]
        ([MaSP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CT_HOA_DON__MaSP__1367E606'
CREATE INDEX [IX_FK__CT_HOA_DON__MaSP__1367E606]
ON [dbo].[CT_HOA_DON]
    ([MaSP]);
GO

-- Creating foreign key on [MaPGH] in table 'CT_PHIEU_GIAO_HANG'
ALTER TABLE [dbo].[CT_PHIEU_GIAO_HANG]
ADD CONSTRAINT [FK__CT_PHIEU___MaPGH__239E4DCF]
    FOREIGN KEY ([MaPGH])
    REFERENCES [dbo].[PHIEU_GIAO_HANG]
        ([MaPGH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MaSP] in table 'CT_PHIEU_GIAO_HANG'
ALTER TABLE [dbo].[CT_PHIEU_GIAO_HANG]
ADD CONSTRAINT [FK__CT_PHIEU_G__MaSP__24927208]
    FOREIGN KEY ([MaSP])
    REFERENCES [dbo].[SAN_PHAM]
        ([MaSP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CT_PHIEU_G__MaSP__24927208'
CREATE INDEX [IX_FK__CT_PHIEU_G__MaSP__24927208]
ON [dbo].[CT_PHIEU_GIAO_HANG]
    ([MaSP]);
GO

-- Creating foreign key on [MaKH] in table 'DON_DAT_HANG'
ALTER TABLE [dbo].[DON_DAT_HANG]
ADD CONSTRAINT [FK__DON_DAT_HA__MaKH__182C9B23]
    FOREIGN KEY ([MaKH])
    REFERENCES [dbo].[KHACH_HANG]
        ([MaKH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__DON_DAT_HA__MaKH__182C9B23'
CREATE INDEX [IX_FK__DON_DAT_HA__MaKH__182C9B23]
ON [dbo].[DON_DAT_HANG]
    ([MaKH]);
GO

-- Creating foreign key on [MaKH] in table 'HOA_DON'
ALTER TABLE [dbo].[HOA_DON]
ADD CONSTRAINT [FK__HOA_DON__MaKH__0DAF0CB0]
    FOREIGN KEY ([MaKH])
    REFERENCES [dbo].[KHACH_HANG]
        ([MaKH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__HOA_DON__MaKH__0DAF0CB0'
CREATE INDEX [IX_FK__HOA_DON__MaKH__0DAF0CB0]
ON [dbo].[HOA_DON]
    ([MaKH]);
GO

-- Creating foreign key on [MaKH] in table 'PHIEU_GIAO_HANG'
ALTER TABLE [dbo].[PHIEU_GIAO_HANG]
ADD CONSTRAINT [FK__PHIEU_GIAO__MaKH__20C1E124]
    FOREIGN KEY ([MaKH])
    REFERENCES [dbo].[KHACH_HANG]
        ([MaKH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PHIEU_GIAO__MaKH__20C1E124'
CREATE INDEX [IX_FK__PHIEU_GIAO__MaKH__20C1E124]
ON [dbo].[PHIEU_GIAO_HANG]
    ([MaKH]);
GO

-- Creating foreign key on [MaLoaiSP] in table 'SAN_PHAM'
ALTER TABLE [dbo].[SAN_PHAM]
ADD CONSTRAINT [FK__SAN_PHAM__MaLoai__08EA5793]
    FOREIGN KEY ([MaLoaiSP])
    REFERENCES [dbo].[LOAI_SAN_PHAM]
        ([MaLoaiSP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SAN_PHAM__MaLoai__08EA5793'
CREATE INDEX [IX_FK__SAN_PHAM__MaLoai__08EA5793]
ON [dbo].[SAN_PHAM]
    ([MaLoaiSP]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------