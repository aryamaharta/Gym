/*
SQLyog Ultimate v9.01 
MySQL - 5.1.30-community : Database - db_gym
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_gym` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `db_gym`;

/*Table structure for table `master_member` */

DROP TABLE IF EXISTS `master_member`;

CREATE TABLE `master_member` (
  `id_member` int(10) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `nama` varchar(200) DEFAULT NULL,
  `alamat` varchar(200) DEFAULT NULL,
  `pekerjaan` varchar(200) DEFAULT NULL,
  `no_telp` varchar(50) DEFAULT NULL,
  `tanggal_mulai` date DEFAULT NULL,
  `tanggal_selesai` date DEFAULT NULL,
  PRIMARY KEY (`id_member`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `master_member` */

insert  into `master_member`(`id_member`,`nama`,`alamat`,`pekerjaan`,`no_telp`,`tanggal_mulai`,`tanggal_selesai`) values (0000000001,'Arya Maharta','Jalan Tukad Yeh Biu Gang Pudak no. 7','08970823021','Mahasiswa','0000-00-00','0000-00-00');

/*Table structure for table `master_paket` */

DROP TABLE IF EXISTS `master_paket`;

CREATE TABLE `master_paket` (
  `id_paket` int(11) NOT NULL AUTO_INCREMENT,
  `deskripsi_paket` varchar(50) DEFAULT NULL,
  `lama_waktu` int(11) DEFAULT NULL,
  `harga_paket` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_paket`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Data for the table `master_paket` */

insert  into `master_paket`(`id_paket`,`deskripsi_paket`,`lama_waktu`,`harga_paket`) values (1,'1 bulan',1,100000),(2,'2 bulan',2,200000),(3,'3 bulan',3,300000),(4,'6 bulan',6,500000),(5,'12 bulan',12,850000),(6,'flexible',0,NULL);

/*Table structure for table `tabel_absensi` */

DROP TABLE IF EXISTS `tabel_absensi`;

CREATE TABLE `tabel_absensi` (
  `id_member` int(11) DEFAULT NULL,
  `waktu_kedatangan` datetime DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `tabel_absensi` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
