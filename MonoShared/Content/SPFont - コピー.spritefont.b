﻿<?xml version="1.0" encoding="utf-8"?>
<!--
This file contains an xml description of a font, and will be read by the XNA
Framework Content Pipeline. Follow the comments to customize the appearance
of the font in your game, and to change the characters which are available to draw
with.
-->
<XnaContent xmlns:Graphics="Microsoft.Xna.Framework.Content.Pipeline.Graphics">
  <Asset Type="Graphics:FontDescription">

    <!--
    Modify this string to change the font that will be imported.
    -->
    <FontName>meiryo</FontName>

    <!--
    Size is a float value, measured in points. Modify this value to change
    the size of the font.
    -->
    <Size>36</Size>

    <!--
    Spacing is a float value, measured in pixels. Modify this value to change
    the amount of spacing in between characters.
    -->
    <Spacing>0</Spacing>

    <!--
    UseKerning controls the layout of the font. If this value is true, kerning information
    will be used when placing characters.
    -->
    <UseKerning>true</UseKerning>

    <!--
    Style controls the style of the font. Valid entries are "Regular", "Bold", "Italic",
    and "Bold, Italic", and are case sensitive.
    -->
    <Style>Regular</Style>

    <!--
    If you uncomment this line, the default character will be substituted if you draw
    or measure text that contains characters which were not included in the font.
    -->
    <DefaultCharacter>*</DefaultCharacter>

    <!--
    CharacterRegions control what letters are available in the font. Every
    character from Start to End will be built and made available for drawing. The
    default range is from 32, (ASCII space), to 126, ('~'), covering the basic Latin
    character set. The characters are ordered according to the Unicode standard.
    See the documentation for more information.
    
    ・基本英語
    ・ひらがな
    ・かたかな
    ・記号
    -->
    <CharacterRegions>
      <CharacterRegion>
      
        <Start>&#32;</Start>
        <End>&#126;</End>
      </CharacterRegion>
      <CharacterRegion>
      
        <Start>&#x3041;</Start>
        <End>&#x3096;</End>
      </CharacterRegion>
      <CharacterRegion>
      
        <Start>&#x30A0;</Start>
        <End>&#x30FF;</End>
      </CharacterRegion>
      
      <CharacterRegion>
        <Start>&#x3000;</Start>
        <End>&#x303F;</End>
      </CharacterRegion>
      
    </CharacterRegions>
  </Asset>
</XnaContent>
