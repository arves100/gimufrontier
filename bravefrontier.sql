/*
 Navicat Premium Data Transfer

 Source Server         : Localhost (MariaDB)
 Source Server Type    : MariaDB
 Source Server Version : 100605
 Source Host           : localhost:30005
 Source Schema         : bravefrontier

 Target Server Type    : MariaDB
 Target Server Version : 100605
 File Encoding         : 65001

 Date: 18/05/2022 04:48:40
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for facebook_users
-- ----------------------------
DROP TABLE IF EXISTS `facebook_users`;
CREATE TABLE `facebook_users`  (
  `api_userid` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `android_id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `facebook_token` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`api_userid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users`  (
  `userid` int(255) UNSIGNED NOT NULL AUTO_INCREMENT,
  `username` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `api_userid` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `friendid` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `tutorial` int(10) UNSIGNED NOT NULL DEFAULT 0,
  `finished_tutorial` tinyint(1) NULL DEFAULT 0,
  `level` int(10) UNSIGNED NOT NULL DEFAULT 1,
  `exp` bigint(20) UNSIGNED NOT NULL DEFAULT 0,
  `unit_inc` int(10) UNSIGNED NOT NULL DEFAULT 0,
  `friend_inc` int(10) UNSIGNED NOT NULL DEFAULT 0,
  `honor_pt` int(10) UNSIGNED NOT NULL DEFAULT 0,
  `zel` int(10) UNSIGNED NOT NULL DEFAULT 1000,
  `karma` int(10) UNSIGNED NOT NULL DEFAULT 1000,
  `friend_msg` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `colosseum_tickets` int(10) UNSIGNED NOT NULL DEFAULT 0,
  `summon_tickets` int(10) UNSIGNED NOT NULL DEFAULT 0,
  `brave_points` int(10) UNSIGNED NOT NULL DEFAULT 0,
  `total_brave_points` int(10) UNSIGNED NOT NULL DEFAULT 0,
  `mystery_box` int(10) UNSIGNED NOT NULL DEFAULT 0,
  `paid_gems` int(10) UNSIGNED NOT NULL DEFAULT 0,
  `free_gems` int(10) UNSIGNED NOT NULL DEFAULT 0,
  `admin` tinyint(1) UNSIGNED NOT NULL DEFAULT 0,
  `banned` tinyint(1) UNSIGNED NOT NULL DEFAULT 0,
  PRIMARY KEY (`userid`) USING BTREE,
  INDEX `api_userid`(`api_userid`) USING BTREE,
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`api_userid`) REFERENCES `facebook_users` (`api_userid`) ON DELETE NO ACTION ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
