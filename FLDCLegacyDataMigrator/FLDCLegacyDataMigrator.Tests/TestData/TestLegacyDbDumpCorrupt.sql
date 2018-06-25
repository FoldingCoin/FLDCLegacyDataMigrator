-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: mysql.joelooney.org
-- Generation Time: Jun 19, 2018 at 04:57 AM
-- Server version: 5.6.34-log
-- PHP Version: 7.1.17

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `fldc`
--

-- --------------------------------------------------------

--
-- Table structure for table `2015-10-04`
--

CREATE TABLE `2015-10-04` (
  `id` int(10) NOT NULL,
  `name` varchar(100) NOT NULL,
  `token` varchar(24) NOT NULL,
  `address` varchar(40) NOT NULL,
  `totalpts` varchar(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `2015-10-04`
--

INSERT INTO `2015-10-04` (`id`, `name`, `token`, `address`, `totalpts`) VALUES
(1, 'tguskill', 'FLDC', '14meWrVap2pmUBrRwY1tBufhG9gXsxKw3N', '1188582883'),
(2, 'ese', 'ALL', '1LaUBD1oAssdL59mzmhx7kzHm5p3vFNWuz', '620889294'),
(3, 'FatHom', 'ALL', '1NSvYD7W2AT7hKdja3BQ),
(4, 'Hou5e', 'ALL', '15k84jUoNPb1kodGvYtKDHiBPRX4Qs3kx8', '347449072'),
(5, 'btupsx', 'ALL', '1MSGDp9P823ZdVssGw8c4rgEyJPE2f1wT8', '282522488'),
(6, 'qqqq', 'ALL', '1CYZ4J1yFNSjxuFhT3eAJfCMB5VBD7PLut', '252749784'),
(7, '---', 'FLDC', '19wXPZGBtRpVgDjQyoBqGVSuiAc77uMiaM', '248783673'),
(8, '---', 'FLDC', '1P3iQSMmjrELxNWqvnHb5phZLS2nvYd3nn', '225096421'),
(9, 'jimbit', 'ALL', '1Kph4yvFQt3CdbMvZmPhiSzgtRq5uMRfkk', '173732970'),
(10, 'Stf', 'ALL', '14Axp5vJq9UD45dczq6ZZPBfrk5b2kwVq3', '160800766'),
(11, '---', 'FLDC', '1KQdCYT5i6nzUVCa1aN7WePDUdsV2VkMWx', '145841659'),
(12, 'deadthings', 'FLDC', '1JJCy54BRs4LVwxKjjwZd4fK9kLQr1wr8p', '135022852'),
(13, '---', 'FLDC', '13wYGb9WnjQRDmz8ryGMTGq8aExQsMpb35', '133149413'),
(14, 'Nismund', 'FLDC', '1NjMEnqV47fHXUujB47BPLuYjR4Wa8oHV1', '129692797'),
(15, 'Haitch', 'ALL', '12guGMu4Rf7niuffwizPLLGxDhxYWJqnFU', '127881802'),
(16, 'Smoke77', 'FLDC', '1AgAAYNkaiAnwwW2Ynm455KgVBCEAAQ1qt', '121949160'),
(17, 'TSC!TeamServer', 'FLDC', '1P8bne5rA11dEvX2xuN9tdXdcDHU2j4Xpw'),
(18, 'shaka256', 'ALL', '1FULqNFTAfCdMkPvMqY5NwUdfgYUAu6oNQ', '115722542'),
(19, 'kerbos5', 'ALL', '13wYGb9WnjQRDmz8ryGMTGq8aExQsMpb35', '111217873'),
(20, 'kotto78', 'ALL', '187NkXYvtXCb4CYM4XoTj2vLkGeqJ2367B', '107100218'),
(21, 'mk337', 'ALL', '176Dwn5HEovFkDU2W7LH17HBzpPq7VphUV', '106681202'),
(22, 'damatt86', 'ALL', '1EufoCWEQSxBBjh2HMb7yzNrCdtBboAKSu', '102726782'),
(23, 'AliG', 'ALL', '12WN2sVoNqxv6omWC54gW9udabwbGPgtWm', '101697419'),
(24, 'Leggazoid', 'FLDC', '1AQXefPh6q7f8Xf8RFM4vmvxHUWeodEaYg', '100009385'),
(25, '---', 'FLDC', '12WN2sVoNqxv6omWC54gW9udabwbGPgtWm', '98658563'),
(26, '---', 'FLDC', '14Axp5vJq9UD45dczq6ZZPBfrk5b2kwVq3', '97206070'),
(27, 'imsm', 'FLDC', '15ubqbQsHyaENQLoqSKoWDeE51pgcMNHyt', '93723429'),
(28, 'RoSMag', 'FLDC', '16qhXN7grXYJT7xcsiwBug74zmHCoBPwBW', '73017356'),
(29, '4ebi', 'ALL', '1AbTjP3oJZJMPQjdNzdaVrRsANAKmo32KB', '72325426'),
(30, 'HealZpl0x', 'ALL', '19YZuvGdxV6GJiEfztqbSZ9cKbrZn6afR5', '66175215'),
(31, 'road-runner', 'FLDC', '1B4BxbA8Tk3LA6Bec4P1yBf6F6sYgAmPTz', '63213353'),
(32, 'Fundamentum', 'ALL', '1CG1aRFP6awqF8BQ9CZXsiDFi9UHzP6gdE', '63119631'),
(33, 'mine22', 'ALL', '1NoGeurjdWe4bW8WBhYWMrXF4FS9drNaSC', '55552187'),
(34, 'QQ', 'ALL', '123GAA3DF7HfNrZX8nHQLXj9eE2FX2r5Ug', '55394640'),
(35, 'Smoke77', 'ALL', '1DCwjzy7SdVp4P5WsrodNeMZxVSSycHGm3', '54099631'),
(36, 'PADDBA', 'FLDC', '1JyywCtA4ftkBtLdijTcvRSVCYZH2Jnhe9', '53801918');
INSERT INTO `2015-10-04` (`id`, `name`, `token`, `address`, `totalpts`) VALUES
(699, 'Dendroid1812', 'FLDC', '1DkpjU4J9zgTHidcDoDo9RmftxHJmWqbad', '136614'),
(700, 'tpiper', 'ALL', '1DbYkKxx9sTN3H6SKfNRs68ZavV3zzKC7C', '135218'),
(701, '---', 'FLDC', '1Q6cAMZGYoi1BvQDcSB8Pm2MAqBKa2qkgy', '134658'),
(702, '---', 'FLDC', '17UCjUuiC2LEn6KCix7gb1oAohPxhYJX4g', '134516'),
(703, 'MookiE', 'FLDC', '1J8QnsMou4nexXUqj1KUu57bYn1YbmePtL', '133840'),
(704, '---', 'FLDC', '1Cn5h1uwxHJ8LEBMJKG33rhN18B8Zbq4Hn', '132281'),
(705, 'SmeeHat', 'FLDC', '1LYUweBCFk5rF5L4UqKmZm2LPKq1CknMiU', '131342'),
(706, 'junseth', 'ALL', '18L2VnJj1YkxHJszh9nQcKjQQam8A4jBm2', '130920'),
(707, 'PADDBA', 'FLDC', '1JyywCtA4ftkBtLdijTcvRSVCYZH2Jnhe9', '130552'),
(708, 'Dimdirol', 'ALL', '14pSQPgRnuiBwpYDPszSpcHUivpVMqefp4', '129346'),
(709, '---', 'FLDC', '15VUAZRg2FeNE5obecnivzZCAdxhMJjNPz', '128884'),
(710, '---', 'FLDC', '1MPMCVtWAxaSCRpbjxqe7wKVRhGtjtL7MW', '128816'),
(711, 'mengine', 'ALL', '1LMLgbupxYJzn5RKipJz7R5wWPSsbtF7wR', '127974'),
(712, '---', 'FLDC', '16bACrncH87JGvM6sbLzTKYrdHbWFXEDE4', '126738'),
(713, 'smokeypeacock', 'ALL', '16A7VwB89KWnfFMsvGcYrhNdYr4yq2aFMS', '126399'),
(714, 'Franknsten', 'ALL', '1FhZg1dUFgYRE2ZWnEHNZZnBEqi1A9Pzsn', '122989'),
(715, 'casper77', 'FLDC', '12TTKYSRGbGpm2hwYAmcAPmW3b71x8jQyt', '122123'),
(716, 'junseth', 'FLDC', '18L2VnJj1YkxHJszh9nQcKjQQam8A4jBm2', '121834'),
(717, '---', 'FLDC', '18n6FPJev6fn97fFd4u9JMwR7DSmEW35Y7', '121683'),
(718, 'xaine', 'FLDC', '1HJVLCoYdSfDbSYcuDvMZBMEWDEfViXyiM', '121588'),
(719, '---', 'FLDC', '1L3QTzuPz3ra3URWYvfTgyMeWqdWagifDM', '119602'),
(720, 'Apidech', 'FLDC', '1EDifSMMyALL2NR3kzSsqjFwMyd6enhvYP', '119171'),
(721, 'harakiwi', 'ALL', '16wVdZykHvJvsdEPkSmSN6aQwCXFJjUKmA', '118320'),
(722, 'mparramon', 'FLDC', '15RQCnfUfHDexWmkeo5srVP58Kyp9Rj6e7', '118112'),
(723, 'edlondon', 'FLDC', '19LY6yrBdvPonqqVrCDWT7sBXNGGUVPxBj', '117375'),
(724, 'dic212', 'FLDC', '16dTJq4Z49MewEKvfUc5pL6Tq35QNSSmX4', '115428'),
(725, 'Katsu411', 'ALL', '1LTeJoh1MYBPP8oyakGLTx2LAUhwCopCdf', '114074'),
(726, 'D3R3', 'ALL', '17D9iHQNygBwgw9YYTbGbT1JP1pXpH3MMb', '114000'),
(727, '---', 'FLDC', '13HGWE6pxE5WiR95mEv2AVhjg56PkvFByn', '113818'),
(728, 'KusopdeJun', 'ALL', '1EHuhbxNXez1TLYy48vE8GmitoLfAatubg', '113750'),
(729, 'biohazardpd', 'FLDC', '1JBmriq2Qdck5zG3iSBMsuK5sDVawYEcxc', '110583'),
(730, '---', 'FLDC', '14MQyoEayU2npKgCPrZXhfadHhfcmZQwTb', '110234'),
(731, 'jasperdamman', 'ALL', '1qyuW2nWAiswVuhB48azGD42fPPemnEiX', '109434'),
(732, 'GaelBuro', 'ALL', '1AETvTVG1NyGU6cUHmzZiCBijjgVq8TDL7', '108608'),
(733, 'Ph0n3', 'ALL', '1LqqWxAfEZymJarZ1zHiNq9EcDdmQhhGzy', '107947'),
(734, '---', 'FLDC', '17ApKRTWkjn9f9NrkrB2iEJK4v5Tp7X6Z4', '106875');

-- --------------------------------------------------------

--
-- Table structure for table `2015-10-05`
--

CREATE TABLE `2015-10-05` (
  `id` int(10) NOT NULL,
  `name` varchar(100) NOT NULL,
  `token` varchar(24) NOT NULL,
  `address` varchar(40) NOT NULL,
  `totalpts` varchar(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `2015-10-05`
--

INSERT INTO `2015-10-05` (`id`, `name`, `token`, `address`, `totalpts`) VALUES
(1, 'tguskill', 'FLDC', '14meWrVap2pmUBrRwY1tBufhG9gXsxKw3N', '1194127699'),
(2, 'ese', 'ALL', '1LaUBD1oAssdL59mzmhx7kzHm5p3vFNWuz', '623097904'),
(3, 'FatHom', 'ALL', '1NSvYD7W2AT7hKdja3BQLQS4N68KRvQ9zo', '358050212'),
(4, 'Hou5e', 'ALL', '15k84jUoNPb1kodGvYtKDHiBPRX4Qs3kx8', '352016980'),
(5, 'btupsx', 'ALL', '1MSGDp9P823ZdVssGw8c4rgEyJPE2f1wT8', '282571703'),
(6, 'qqqq', 'ALL', '1CYZ4J1yFNSjxuFhT3eAJfCMB5VBD7PLut', '252749784'),
(7, '---', 'FLDC', '19wXPZGBtRpVgDjQyoBqGVSuiAc77uMiaM', '248783673'),
(8, '---', 'FLDC', '1P3iQSMmjrELxNWqvnHb5phZLS2nvYd3nn', '226176048'),
(9, 'jimbit', 'ALL', '1Kph4yvFQt3CdbMvZmPhiSzgtRq5uMRfkk', '173732970'),
(10, 'Stf', 'ALL', '14Axp5vJq9UD45dczq6ZZPBfrk5b2kwVq3', '160800766'),
(11, '---', 'FLDC', '1KQdCYT5i6nzUVCa1aN7WePDUdsV2VkMWx', '145841659'),
(12, 'deadthings', 'FLDC', '1JJCy54BRs4LVwxKjjwZd4fK9kLQr1wr8p', '135251020'),
(13, '---', 'FLDC', '13wYGb9WnjQRDmz8ryGMTGq8aExQsMpb35', '133149413'),
(14, 'Nismund', 'FLDC', '1NjMEnqV47fHXUujB47BPLuYjR4Wa8oHV1', '130637931'),
(15, 'Haitch', 'ALL', '12guGMu4Rf7niuffwizPLLGxDhxYWJqnFU', '127881802'),
(16, 'Smoke77', 'FLDC', '1AgAAYNkaiAnwwW2Ynm455KgVBCEAAQ1qt', '122441911'),
(17, 'TSC!TeamServer', 'FLDC', '1P8bne5rA11dEvX2xuN9tdXdcDHU2j4Xpw', '121873914'),
(18, 'shaka256', 'ALL', '1FULqNFTAfCdMkPvMqY5NwUdfgYUAu6oNQ', '116094157'),
(19, 'kerbos5', 'ALL', '13wYGb9WnjQRDmz8ryGMTGq8aExQsMpb35', '111217873'),
(20, 'kotto78', 'ALL', '187NkXYvtXCb4CYM4XoTj2vLkGeqJ2367B', '107100218'),
(21, 'mk337', 'ALL', '176Dwn5HEovFkDU2W7LH17HBzpPq7VphUV', '106681202'),
(22, 'damatt86', 'ALL', '1EufoCWEQSxBBjh2HMb7yzNrCdtBboAKSu', '104855477'),
(23, 'AliG', 'ALL', '12WN2sVoNqxv6omWC54gW9udabwbGPgtWm', '102486161'),
(24, 'Leggazoid', 'FLDC', '1AQXefPh6q7f8Xf8RFM4vmvxHUWeodEaYg', '100561110'),
(25, '---', 'FLDC', '12WN2sVoNqxv6omWC54gW9udabwbGPgtWm', '98658563'),
(26, '---', 'FLDC', '14Axp5vJq9UD45dczq6ZZPBfrk5b2kwVq3', '97206070'),
(27, 'imsm', 'FLDC', '15ubqbQsHyaENQLoqSKoWDeE51pgcMNHyt', '94285340'),
(28, 'RoSMag', 'FLDC', '16qhXN7grXYJT7xcsiwBug74zmHCoBPwBW', '73594337'),
(29, '4ebi', 'ALL', '1AbTjP3oJZJMPQjdNzdaVrRsANAKmo32KB', '72325426'),
(30, 'HealZpl0x', 'ALL', '19YZuvGdxV6GJiEfztqbSZ9cKbrZn6afR5', '66175215'),
(31, 'road-runner', 'FLDC', '1B4BxbA8Tk3LA6Bec4P1yBf6F6sYgAmPTz', '63213353'),
(32, 'Fundamentum', 'ALL', '1CG1aRFP6awqF8BQ9CZXsiDFi9UHzP6gdE', '63119631'),
(33, 'mine22', 'ALL', '1NoGeurjdWe4bW8WBhYWMrXF4FS9drNaSC', '56002576'),
(34, 'QQ', 'ALL', '123GAA3DF7HfNrZX8nHQLXj9eE2FX2r5Ug', '55394640'),
(35, 'Smoke77', 'ALL', '1DCwjzy7SdVp4P5WsrodNeMZxVSSycHGm3', '54099631'),
(36, 'PADDBA', 'FLDC', '1JyywCtA4ftkBtLdijTcvRSVCYZH2Jnhe9', '53801918'),
(37, 'ricky', 'ALL', '16cDsE3qDkDu2FeFt8fv4Sq8S2r6GtYSaH', '52109528'),
(38, 'biohazard', 'ALL', '1GqrN7zzN18RDSS1sHog21LE5ZkQFGc3ed', '50042446'),
(39, 'Maxiandr', 'ALL', '1C2wqmq9xhtaLfMxjYApYi7G1WrArnjoDS', '48730127'),
(40, '---', 'FLDC', '17vBohqAPj1tAtVahxqWELw5VZ3zUWrW81', '48294611'),
(41, 'PookTwo', 'FLDC', '16muW9htJAYrrXrKN8BwWTmT6cgXscXDzJ', '48282679'),
(42, '---', 'FLDC', '14KFp43wSwFK7hGc7e4u3q5jytgRgQqSCH', '47697452'),
(43, 'Maxiandr', 'FLDC', '1C2wqmq9xhtaLfMxjYApYi7G1WrArnjoDS', '44180400'),
(44, '---', 'FLDC', '1NzVNFTsN3NhCEj1R4B8Br1YQ4P29C5BwQ', '44143639'),
(45, 'rc', 'ALL', '1H7cuUJBDuA1ubNaQJQfErbD6fm6xw3fN', '43410272'),
(46, '4ebi', 'FLDC', '1AbTjP3oJZJMPQjdNzdaVrRsANAKmo32KB', '41437605');
INSERT INTO `2015-10-05` (`id`, `name`, `token`, `address`, `totalpts`) VALUES
(699, 'vach', 'ALL', '16FxwsDM7MKgEA3Gk4JWjnD5xmRoAHjwUJ', '137385'),
(700, 'Dendroid1812', 'FLDC', '1DkpjU4J9zgTHidcDoDo9RmftxHJmWqbad', '136614'),
(701, 'junseth', 'ALL', '18L2VnJj1YkxHJszh9nQcKjQQam8A4jBm2', '135377'),
(702, '---', 'FLDC', '1Q6cAMZGYoi1BvQDcSB8Pm2MAqBKa2qkgy', '134658'),
(703, '---', 'FLDC', '17UCjUuiC2LEn6KCix7gb1oAohPxhYJX4g', '134516'),
(704, 'MookiE', 'FLDC', '1J8QnsMou4nexXUqj1KUu57bYn1YbmePtL', '133840'),
(705, '---', 'FLDC', '1Cn5h1uwxHJ8LEBMJKG33rhN18B8Zbq4Hn', '132281'),
(706, 'SmeeHat', 'FLDC', '1LYUweBCFk5rF5L4UqKmZm2LPKq1CknMiU', '131342'),
(707, 'PADDBA', 'FLDC', '1JyywCtA4ftkBtLdijTcvRSVCYZH2Jnhe9', '130552'),
(708, 'Dimdirol', 'ALL', '14pSQPgRnuiBwpYDPszSpcHUivpVMqefp4', '129346'),
(709, '---', 'FLDC', '15VUAZRg2FeNE5obecnivzZCAdxhMJjNPz', '128884'),
(710, '---', 'FLDC', '1MPMCVtWAxaSCRpbjxqe7wKVRhGtjtL7MW', '128816'),
(711, 'smokeypeacock', 'ALL', '16A7VwB89KWnfFMsvGcYrhNdYr4yq2aFMS', '128183'),
(712, 'mengine', 'ALL', '1LMLgbupxYJzn5RKipJz7R5wWPSsbtF7wR', '127974'),
(713, '---', 'FLDC', '16bACrncH87JGvM6sbLzTKYrdHbWFXEDE4', '126738'),
(714, 'harakiwi', 'ALL', '16wVdZykHvJvsdEPkSmSN6aQwCXFJjUKmA', '123812'),
(715, 'Franknsten', 'ALL', '1FhZg1dUFgYRE2ZWnEHNZZnBEqi1A9Pzsn', '122989'),
(716, 'casper77', 'FLDC', '12TTKYSRGbGpm2hwYAmcAPmW3b71x8jQyt', '122123'),
(717, 'Serj188', 'FLDC', '15uNNf47QKZcEgbYB7LfV9YJNTrAvzh7rd', '122064'),
(718, 'junseth', 'FLDC', '18L2VnJj1YkxHJszh9nQcKjQQam8A4jBm2', '121834'),
(719, '---', 'FLDC', '18n6FPJev6fn97fFd4u9JMwR7DSmEW35Y7', '121683'),
(720, 'xaine', 'FLDC', '1HJVLCoYdSfDbSYcuDvMZBMEWDEfViXyiM', '121588'),
(721, '---', 'FLDC', '1L3QTzuPz3ra3URWYvfTgyMeWqdWagifDM', '119602'),
(722, 'Apidech', 'FLDC', '1EDifSMMyALL2NR3kzSsqjFwMyd6enhvYP', '119171'),
(723, 'mparramon', 'FLDC', '15RQCnfUfHDexWmkeo5srVP58Kyp9Rj6e7', '118112'),
(724, 'edlondon', 'FLDC', '19LY6yrBdvPonqqVrCDWT7sBXNGGUVPxBj', '117375'),
(725, 'GaelBuro', 'ALL', '1AETvTVG1NyGU6cUHmzZiCBijjgVq8TDL7', '116341'),
(726, 'dic212', 'FLDC', '16dTJq4Z49MewEKvfUc5pL6Tq35QNSSmX4', '115428'),
(727, 'Katsu411', 'ALL', '1LTeJoh1MYBPP8oyakGLTx2LAUhwCopCdf', '114074'),
(728, 'KusopdeJun', 'ALL', '1EHuhbxNXez1TLYy48vE8GmitoLfAatubg', '114000'),
(729, 'D3R3', 'ALL', '17D9iHQNygBwgw9YYTbGbT1JP1pXpH3MMb', '114000'),
(730, '---', 'FLDC', '13HGWE6pxE5WiR95mEv2AVhjg56PkvFByn', '113818'),
(731, 'biohazardpd', 'FLDC', '1JBmriq2Qdck5zG3iSBMsuK5sDVawYEcxc', '110583'),
(732, '---', 'FLDC', '14MQyoEayU2npKgCPrZXhfadHhfcmZQwTb', '110234'),
(733, 'jasperdamman', 'ALL', '1qyuW2nWAiswVuhB48azGD42fPPemnEiX', '109434'),
(734, 'Ph0n3', 'ALL', '1LqqWxAfEZymJarZ1zHiNq9EcDdmQhhGzy', '107947'),
(735, '---', 'FLDC', '17ApKRTWkjn9f9NrkrB2iEJK4v5Tp7X6Z4', '106875'),
(736, 'bitXbit1', 'ALL', '1LwLUYZ7rj4ZeS3j7be5g9L9uQ6pqjhWZ5', '105335'),
(737, '---', 'FLDC', '1GnVjXAENtp6fVQVpaTnzmTkK6rmTA5WY8', '104358'),
(738, 'lostdroid', 'FLDC', '19WE9BjNmhRKPHoMFyQrdVb3FDgsknhyey', '104086'),
(739, 'kreiseda', 'FLDC', '198ffjQKVmMs4qapEfakDpvBawFMjyYiYR', '103531'),
(740, 'ophirfolding', 'ALL', '14xCDz44W7Gv7QnfmWZKmw7BCMEvnV2McR', '103369'),
(741, 'barton26', 'ALL', '1BAAGn2ASMfGzKRFqwqNASyiAsFgb6CqxH', '102396'),
(742, 'Dth', 'ALL', '1HqdqwArHykCGqFTq8sRSAaDfybd5RVdwz', '101864'),
(743, '---', 'FLDC', '14o6DfkJzbsVVGwjZBZMBaiFE4kHafUoeV', '101530'),
(744, 'KarlAnders', 'ALL', '1FjXd9MpXYA4yrPMsr5Khm9snvcEQLCNR2', '100990');

-- --------------------------------------------------------

--
-- Table structure for table `template`
--

CREATE TABLE `template` (
  `id` int(10) NOT NULL,
  `name` varchar(100) NOT NULL,
  `token` varchar(24) NOT NULL,
  `address` varchar(40) NOT NULL,
  `totalpts` varchar(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `2015-10-04`
--
ALTER TABLE `2015-10-04`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `2015-10-05`
--
ALTER TABLE `2015-10-05`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `template`
--
ALTER TABLE `template`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `2015-10-04`
--
ALTER TABLE `2015-10-04`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1586;

--
-- AUTO_INCREMENT for table `2015-10-05`
--
ALTER TABLE `2015-10-05`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1588;

--
-- AUTO_INCREMENT for table `template`
--
ALTER TABLE `template`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;