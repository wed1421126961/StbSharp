using System;

namespace StbSharp
{
	public static partial class Image
	{
		private class stbi__context
		{
			public uint img_x;
			public uint img_y;
			public int img_n;
			public int img_out_n;
			public stbi_io_callbacks io;
			public object io_user_data;
			public int read_from_callbacks;
			public int buflen;
			public Pointer<byte> buffer_start;
			public Pointer<byte> img_buffer;
			public Pointer<byte> img_buffer_end;
			public Pointer<byte> img_buffer_original;
			public Pointer<byte> img_buffer_original_end;
		}

		private class stbi__huffman
		{
			public Pointer<byte> fast;
			public Pointer<ushort> code;
			public Pointer<byte> values;
			public Pointer<byte> size;
			public Pointer<uint> maxcode;
			public Pointer<int> delta;
		}

		private class stbi__zhuffman
		{
			public Pointer<ushort> fast;
			public Pointer<ushort> firstcode;
			public Pointer<int> maxcode;
			public Pointer<ushort> firstsymbol;
			public Pointer<byte> size;
			public Pointer<ushort> value;
		}

		private class stbi__zbuf
		{
			public Pointer<byte> zbuffer;
			public Pointer<byte> zbuffer_end;
			public int num_bits;
			public uint code_buffer;
			public Pointer<sbyte> zout;
			public Pointer<sbyte> zout_start;
			public Pointer<sbyte> zout_end;
			public int z_expandable;
			public stbi__zhuffman z_length;
			public stbi__zhuffman z_distance;
		}

		private class stbi__pngchunk
		{
			public uint length;
			public uint type;
		}

		private class stbi__png
		{
			public stbi__context s;
			public Pointer<byte> idata;
			public Pointer<byte> expanded;
			public Pointer<byte> _out_;
			public int depth;
		}

		private class stbi__bmp_data
		{
			public int bpp;
			public int offset;
			public int hsz;
			public uint mr;
			public uint mg;
			public uint mb;
			public uint ma;
			public uint all_a;
		}

		private class stbi__pic_packet
		{
			public byte size;
			public byte type;
			public byte channel;
		}

		private class stbi__gif_lzw
		{
			public short prefix;
			public byte first;
			public byte suffix;
		}

		private class stbi__gif
		{
			public int w;
			public int h;
			public Pointer<byte> _out_;
			public Pointer<byte> old_out;
			public int flags;
			public int bgindex;
			public int ratio;
			public int transparent;
			public int eflags;
			public int delay;
			public Pointer<Pointer<byte>> pal;
			public Pointer<Pointer<byte>> lpal;
			public stbi__gif_lzw codes;
			public Pointer<byte> color_table;
			public int parse;
			public int step;
			public int lflags;
			public int start_x;
			public int start_y;
			public int max_x;
			public int max_y;
			public int cur_x;
			public int cur_y;
			public int line_size;
		}

		private const int STBI_default = 0;
		private const int STBI_grey = 1;
		private const int STBI_grey_alpha = 2;
		private const int STBI_rgb = 3;
		private const int STBI_rgb_alpha = 4;
		private const int STBI__SCAN_load = 0;
		private const int STBI__SCAN_type = 1;
		private const int STBI__SCAN_header = 2;
		private const int STBI__F_none = 0;
		private const int STBI__F_sub = 1;
		private const int STBI__F_up = 2;
		private const int STBI__F_avg = 3;
		private const int STBI__F_paeth = 4;
		private const int STBI__F_avg_first = 5;
		private const int STBI__F_paeth_first = 6;
		static float stbi__h2l_gamma_i = (float) (1/2.20000005);
		static float stbi__h2l_scale_i = (float) (1);

		static Pointer<uint> stbi__bmask =
			new Pointer<uint>(new uint[] {0, 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023, 2047, 4095, 8191, 16383, 32767, 65535});

		static Pointer<int> stbi__jbias =
			new Pointer<int>(new int[]
			{0, -1, -3, -7, -15, -31, -63, -127, -255, -511, -1023, -2047, -4095, -8191, -16383, -32767});

		static Pointer<byte> stbi__jpeg_dezigzag =
			new Pointer<byte>(new byte[]
			{
				0, 1, 8, 16, 9, 2, 3, 10, 17, 24, 32, 25, 18, 11, 4, 5, 12, 19, 26, 33, 40, 48, 41, 34, 27, 20, 13, 6, 7, 14, 21, 28,
				35, 42, 49, 56, 57, 50, 43, 36, 29, 22, 15, 23, 30, 37, 44, 51, 58, 59, 52, 45, 38, 31, 39, 46, 53, 60, 61, 54, 47,
				55, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63
			});

		static Pointer<int> stbi__zlength_base =
			new Pointer<int>(new int[]
			{
				3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 15, 17, 19, 23, 27, 31, 35, 43, 51, 59, 67, 83, 99, 115, 131, 163, 195, 227, 258, 0,
				0
			});

		static Pointer<int> stbi__zlength_extra =
			new Pointer<int>(new int[]
			{0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 0, 0, 0});

		static Pointer<int> stbi__zdist_base =
			new Pointer<int>(new int[]
			{
				1, 2, 3, 4, 5, 7, 9, 13, 17, 25, 33, 49, 65, 97, 129, 193, 257, 385, 513, 769, 1025, 1537, 2049, 3073, 4097, 6145,
				8193, 12289, 16385, 24577, 0, 0
			});

		static Pointer<int> stbi__zdist_extra =
			new Pointer<int>(new int[]
			{0, 0, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13});

		static Pointer<byte> stbi__zdefault_length = new Pointer<byte>(288);
		static Pointer<byte> stbi__zdefault_distance = new Pointer<byte>(32);

		static Pointer<byte> first_row_filter =
			new Pointer<byte>(new byte[] {STBI__F_none, STBI__F_sub, STBI__F_none, STBI__F_avg_first, STBI__F_paeth_first});

		static Pointer<byte> stbi__depth_scale_table = new Pointer<byte>(new byte[] {0, 255, 85, 0, 17, 0, 0, 0, 1});
		static int stbi__unpremultiply_on_load = (int) (0);
		static int stbi__de_iphone_flag = (int) (0);

		private static void stbi__start_mem(stbi__context s, Pointer<byte> buffer, int len)
		{
			s.io.read = (null /*0*/);
			s.read_from_callbacks = (int) (0);
			s.img_buffer = s.img_buffer_original = buffer;
			s.img_buffer_end = s.img_buffer_original_end = buffer + len;
		}

		private static void stbi__start_callbacks(stbi__context s, stbi_io_callbacks c, object user)
		{
			s.io = (stbi_io_callbacks) (c);
			s.io_user_data = (object) (user);
			s.buflen = (int) ((s.buffer_start).Size);
			s.read_from_callbacks = (int) (1);
			s.img_buffer_original = s.buffer_start;
			stbi__refill_buffer(s);
			s.img_buffer_original_end = s.img_buffer_end;
		}

		private static void stbi__rewind(stbi__context s)
		{
			s.img_buffer = s.img_buffer_original;
			s.img_buffer_end = s.img_buffer_original_end;
		}

		private static void stbi_set_flip_vertically_on_load(int flag_true_if_should_flip)
		{
			stbi__vertically_flip_on_load = (int) (flag_true_if_should_flip);
		}

		private static Pointer<byte> stbi__load_main(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp,
			int req_comp)
		{
			if ((stbi__jpeg_test(s)) != 0) return stbi__jpeg_load(s, x, y, comp, req_comp);
			if ((stbi__png_test(s)) != 0) return stbi__png_load(s, x, y, comp, req_comp);
			if ((stbi__bmp_test(s)) != 0) return stbi__bmp_load(s, x, y, comp, req_comp);
			if ((stbi__gif_test(s)) != 0) return stbi__gif_load(s, x, y, comp, req_comp);
			if ((stbi__psd_test(s)) != 0) return stbi__psd_load(s, x, y, comp, req_comp);
			if ((stbi__pic_test(s)) != 0) return stbi__pic_load(s, x, y, comp, req_comp);
			if ((stbi__pnm_test(s)) != 0) return stbi__pnm_load(s, x, y, comp, req_comp);
			if ((stbi__tga_test(s)) != 0) return stbi__tga_load(s, x, y, comp, req_comp);
			return (null /*(stbi__err("unknown image type") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
		}

		private static Pointer<byte> stbi__load_flip(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp,
			int req_comp)
		{
			Pointer<byte> result = stbi__load_main(s, x, y, comp, req_comp);
			if ((stbi__vertically_flip_on_load) != 0 && result != (null /*0*/))
			{
				int w = (int) (x.CurrentValue);
				int h = (int) (y.CurrentValue);
				int depth = (int) (req_comp > 0 ? req_comp : comp.CurrentValue);
				int row;
				int col;
				int z;
				byte temp;
				for (row = (int) (0); row < (h >> 1); row++)
				{
					for (col = (int) (0); col < w; col++)
					{
						for (z = (int) (0); z < depth; z++)
						{
							temp = (byte) (result[(row*w + col)*depth + z]);
							result[(row*w + col)*depth + z] = (byte) (result[((h - row - 1)*w + col)*depth + z]);
							result[((h - row - 1)*w + col)*depth + z] = (byte) (temp);
						}
					}
				}
			}

			return result;
		}

		private static Pointer<byte> stbi_load_from_memory(Pointer<byte> buffer, int len, Pointer<int> x, Pointer<int> y,
			Pointer<int> comp, int req_comp)
		{
			stbi__context s = new stbi__context();
			stbi__start_mem(s, buffer, len);
			return stbi__load_flip(s, x, y, comp, req_comp);
		}

		private static Pointer<byte> stbi_load_from_callbacks(stbi_io_callbacks clbk, object user, Pointer<int> x,
			Pointer<int> y, Pointer<int> comp, int req_comp)
		{
			stbi__context s = new stbi__context();
			stbi__start_callbacks(s, clbk, user);
			return stbi__load_flip(s, x, y, comp, req_comp);
		}

		private static void stbi_hdr_to_ldr_gamma(float gamma)
		{
			stbi__h2l_gamma_i = (float) (1/gamma);
		}

		private static void stbi_hdr_to_ldr_scale(float scale)
		{
			stbi__h2l_scale_i = (float) (1/scale);
		}

		private static void stbi__refill_buffer(stbi__context s)
		{
			int n = (int) (s.io.read(s.io_user_data, s.buffer_start, s.buflen));
			if (n == 0)
			{
				s.read_from_callbacks = (int) (0);
				s.img_buffer = s.buffer_start;
				s.img_buffer_end = s.buffer_start + 1;
				s.img_buffer.CurrentValue = (byte) (0);
			}
			else
			{
				s.img_buffer = s.buffer_start;
				s.img_buffer_end = s.buffer_start + n;
			}

		}

		private static byte stbi__get8(stbi__context s)
		{
			if (s.img_buffer < s.img_buffer_end) return (byte) (s.img_buffer.GetAndMove());
			if ((s.read_from_callbacks) != 0)
			{
				stbi__refill_buffer(s);
				return (byte) (s.img_buffer.GetAndMove());
			}

			return (byte) (0);
		}

		private static int stbi__at_eof(stbi__context s)
		{
			if ((s.io.read) != null)
			{
				if (s.io.eof(s.io_user_data) == 0) return (int) (0);
				if (s.read_from_callbacks == 0) return (int) (1);
			}

			return (int) (s.img_buffer >= s.img_buffer_end ? 1 : 0);
		}

		private static void stbi__skip(stbi__context s, int n)
		{
			if (n < 0)
			{
				s.img_buffer = s.img_buffer_end;
				return;
			}

			if ((s.io.read) != null)
			{
				int blen = (int) ((s.img_buffer_end - s.img_buffer));
				if (blen < n)
				{
					s.img_buffer = s.img_buffer_end;
					s.io.skip(s.io_user_data, n - blen);
					return;
				}
			}

			s.img_buffer += n;
		}

		private static int stbi__getn(stbi__context s, Pointer<byte> buffer, int n)
		{
			if ((s.io.read) != null)
			{
				int blen = (int) ((s.img_buffer_end - s.img_buffer));
				if (blen < n)
				{
					int res;
					int count;
					memcpy(buffer, s.img_buffer, blen);
					count = (int) (s.io.read(s.io_user_data, buffer + blen, n - blen));
					res = (int) ((count == (n - blen)));
					s.img_buffer = s.img_buffer_end;
					return (int) (res);
				}
			}

			if (s.img_buffer + n <= s.img_buffer_end)
			{
				memcpy(buffer, s.img_buffer, n);
				s.img_buffer += n;
				return (int) (1);
			}
			else return (int) (0);
		}

		private static int stbi__get16be(stbi__context s)
		{
			int z = (int) (stbi__get8(s));
			return (int) ((z << 8) + stbi__get8(s));
		}

		private static uint stbi__get32be(stbi__context s)
		{
			uint z = (uint) (stbi__get16be(s));
			return (uint) ((z << 16) + stbi__get16be(s));
		}

		private static int stbi__get16le(stbi__context s)
		{
			int z = (int) (stbi__get8(s));
			return (int) (z + (stbi__get8(s) << 8));
		}

		private static uint stbi__get32le(stbi__context s)
		{
			uint z = (uint) (stbi__get16le(s));
			return (uint) (z + (stbi__get16le(s) << 16));
		}

		private static byte stbi__compute_y(int r, int g, int b)
		{
			return (byte) ((((r*77) + (g*150) + (29*b)) >> 8));
		}

		private static Pointer<byte> stbi__convert_format(Pointer<byte> data, int img_n, int req_comp, uint x, uint y)
		{
			int i;
			int j;
			Pointer<byte> good;
			if (req_comp == img_n) return data;
			good = stbi__malloc(req_comp*x*y);
			if (good == (null /*0*/))
			{
				free(data);
				return (null /*(stbi__err("outofmem") > 0?(null /*0*/):
				(null /*0*/))
				*/)
				;
			}

			for (j = (int) (0); j < y; ++j)
			{
				Pointer<byte> src = data + j*x*img_n;
				Pointer<byte> dest = good + j*x*req_comp;
				switch (((img_n)*8 + (req_comp)))
				{
					case ((1)*8 + (2)):
						for (i = (int) (x - 1); i >= 0; --i , src += 1 , dest += 2) dest[0] = (byte) (src[0]) ,
						dest[1] = (byte) (255);
						break;
					case ((1)*8 + (3)):
						for (i = (int) (x - 1); i >= 0; --i , src += 1 , dest += 3)
							dest[0] = (byte) (dest[1] = (byte) (dest[2] = (byte) (src[0])));
						break;
					case ((1)*8 + (4)):
						for (i = (int) (x - 1); i >= 0; --i , src += 1 , dest += 4)
							dest[0] = (byte) (dest[1] = (byte) (dest[2] = (byte) (src[0]))) ,
						dest[3] = (byte) (255);
						break;
					case ((2)*8 + (1)):
						for (i = (int) (x - 1); i >= 0; --i , src += 2 , dest += 1) dest[0] = (byte) (src[0]);
						break;
					case ((2)*8 + (3)):
						for (i = (int) (x - 1); i >= 0; --i , src += 2 , dest += 3)
							dest[0] = (byte) (dest[1] = (byte) (dest[2] = (byte) (src[0])));
						break;
					case ((2)*8 + (4)):
						for (i = (int) (x - 1); i >= 0; --i , src += 2 , dest += 4)
							dest[0] = (byte) (dest[1] = (byte) (dest[2] = (byte) (src[0]))) ,
						dest[3] = (byte) (src[1]);
						break;
					case ((3)*8 + (4)):
						for (i = (int) (x - 1); i >= 0; --i , src += 3 , dest += 4) dest[0] = (byte) (src[0]) ,
						dest[1] = (byte) (src[1]) ,
						dest[2] = (byte) (src[2]) ,
						dest[3] = (byte) (255);
						break;
					case ((3)*8 + (1)):
						for (i = (int) (x - 1); i >= 0; --i , src += 3 , dest += 1)
							dest[0] = (byte) (stbi__compute_y(src[0], src[1], src[2]));
						break;
					case ((3)*8 + (2)):
						for (i = (int) (x - 1); i >= 0; --i , src += 3 , dest += 2)
							dest[0] = (byte) (stbi__compute_y(src[0], src[1], src[2])) ,
						dest[1] = (byte) (255);
						break;
					case ((4)*8 + (1)):
						for (i = (int) (x - 1); i >= 0; --i , src += 4 , dest += 1)
							dest[0] = (byte) (stbi__compute_y(src[0], src[1], src[2]));
						break;
					case ((4)*8 + (2)):
						for (i = (int) (x - 1); i >= 0; --i , src += 4 , dest += 2)
							dest[0] = (byte) (stbi__compute_y(src[0], src[1], src[2])) ,
						dest[1] = (byte) (src[3]);
						break;
					case ((4)*8 + (3)):
						for (i = (int) (x - 1); i >= 0; --i , src += 4 , dest += 3) dest[0] = (byte) (src[0]) ,
						dest[1] = (byte) (src[1]) ,
						dest[2] = (byte) (src[2]);
						break;
						;
				}
			}

			free(data);
			return good;
		}

		private static int stbi__build_huffman(stbi__huffman h, Pointer<int> count)
		{
			int i;
			int j;
			int k = (int) (0);
			int code;
			for (i = (int) (0); i < 16; ++i) for (j = (int) (0); j < count[i]; ++j) h.size[k++] = (byte) ((i + 1));
			h.size[k] = (byte) (0);
			code = (int) (0);
			k = (int) (0);
			for (j = (int) (1); j <= 16; ++j)
			{
				h.delta[j] = (int) (k - code);
				if (h.size[k] == j)
				{
					h.code[k++] = (ushort) ((code++));
					if (code - 1 >= (1 << j)) return (int) (stbi__err("bad code lengths"));
				}
				h.maxcode[j] = (uint) (code << (16 - j));
				code <<= 1;
			}

			h.maxcode[j] = (uint) (-1);
			memset(h.fast, 255, 1 << 9);
			for (i = (int) (0); i < k; ++i)
			{
				int s = (int) (h.size[i]);
				if (s <= 9)
				{
					int c = (int) (h.code[i] << (9 - s));
					int m = (int) (1 << (9 - s));
					for (j = (int) (0); j < m; ++j)
					{
						h.fast[c + j] = (byte) (i);
					}
				}
			}

			return (int) (1);
		}

		private static void stbi__build_fast_ac(Pointer<short> fast_ac, stbi__huffman h)
		{
			int i;
			for (i = (int) (0); i < (1 << 9); ++i)
			{
				byte fast = (byte) (h.fast[i]);
				fast_ac[i] = (short) (0);
				if (fast < 255)
				{
					int rs = (int) (h.values[fast]);
					int run = (int) ((rs >> 4) & 15);
					int magbits = (int) (rs & 15);
					int len = (int) (h.size[fast]);
					if ((magbits) != 0 && len + magbits <= 9)
					{
						int k = (int) (((i << len) & ((1 << 9) - 1)) >> (9 - magbits));
						int m = (int) (1 << (magbits - 1));
						if (k < m) k += (-1 << magbits) + 1;
						if (k >= -128 && k <= 127) fast_ac[i] = (short) (((k << 8) + (run << 4) + (len + magbits)));
					}
				}
			}

		}

		private static void stbi__grow_buffer_unsafe(stbi__jpeg j)
		{
			do
			{
				{
					int b = (int) (j.nomore > 0 ? 0 : stbi__get8(j.s));
					if (b == 255)
					{
						int c = (int) (stbi__get8(j.s));
						if (c != 0)
						{
							j.marker = (byte) (c);
							j.nomore = (int) (1);
							return;
						}
					}
					j.code_buffer |= b << (24 - j.code_bits);
					j.code_bits += 8;
				}
			} while (j.code_bits <= 24);
		}

		private static int stbi__jpeg_huff_decode(stbi__jpeg j, stbi__huffman h)
		{
			uint temp;
			int c;
			int k;
			if (j.code_bits < 16) stbi__grow_buffer_unsafe(j);
			c = (int) ((j.code_buffer >> (32 - 9)) & ((1 << 9) - 1));
			k = (int) (h.fast[c]);
			if (k < 255)
			{
				int s = (int) (h.size[k]);
				if (s > j.code_bits) return (int) (-1);
				j.code_buffer <<= s;
				j.code_bits -= s;
				return (int) (h.values[k]);
			}

			temp = (uint) (j.code_buffer >> 16);
			for (k = (int) (9 + 1);; ++k) if (temp < h.maxcode[k]) break;
			if (k == 17)
			{
				j.code_bits -= 16;
				return (int) (-1);
			}

			if (k > j.code_bits) return (int) (-1);
			c = (int) (((j.code_buffer >> (32 - k)) & stbi__bmask[k]) + h.delta[k]);
			j.code_bits -= k;
			j.code_buffer <<= k;
			return (int) (h.values[c]);
		}

		private static int stbi__extend_receive(stbi__jpeg j, int n)
		{
			uint k;
			int sgn;
			if (j.code_bits < n) stbi__grow_buffer_unsafe(j);
			sgn = (int) (j.code_buffer >> 31);
			k = (uint) (_lrotl(j.code_buffer, n));
			j.code_buffer = (uint) (k & ~stbi__bmask[n] ? 1 : 0);
			k &= stbi__bmask[n];
			j.code_bits -= n;
			return (int) (k + (stbi__jbias[n] & ~sgn));
		}

		private static int stbi__jpeg_get_bits(stbi__jpeg j, int n)
		{
			uint k;
			if (j.code_bits < n) stbi__grow_buffer_unsafe(j);
			k = (uint) (_lrotl(j.code_buffer, n));
			j.code_buffer = (uint) (k & ~stbi__bmask[n] ? 1 : 0);
			k &= stbi__bmask[n];
			j.code_bits -= n;
			return (int) (k);
		}

		private static int stbi__jpeg_get_bit(stbi__jpeg j)
		{
			uint k;
			if (j.code_bits < 1) stbi__grow_buffer_unsafe(j);
			k = (uint) (j.code_buffer);
			j.code_buffer <<= 1;
			--j.code_bits;
			return (int) (k & -2147483648);
		}

		private static int stbi__jpeg_decode_block(stbi__jpeg j, Pointer<short> data, stbi__huffman hdc, stbi__huffman hac,
			Pointer<short> fac, int b, Pointer<byte> dequant)
		{
			int diff;
			int dc;
			int k;
			int t;
			if (j.code_bits < 16) stbi__grow_buffer_unsafe(j);
			t = (int) (stbi__jpeg_huff_decode(j, hdc));
			if (t < 0) return (int) (stbi__err("bad huffman code"));
			memset(data, 0, 64*(data[0]).Size);
			diff = (int) (t > 0 ? stbi__extend_receive(j, t) : 0);
			dc = (int) (j.img_comp[b].dc_pred + diff);
			j.img_comp[b].dc_pred = (int) (dc);
			data[0] = (short) ((dc*dequant[0]));
			k = (int) (1);
			do
			{
				{
					uint zig;
					int c;
					int r;
					int s;
					if (j.code_bits < 16) stbi__grow_buffer_unsafe(j);
					c = (int) ((j.code_buffer >> (32 - 9)) & ((1 << 9) - 1));
					r = (int) (fac[c]);
					if ((r) != 0)
					{
						k += (r >> 4) & 15;
						s = (int) (r & 15 ? 1 : 0);
						j.code_buffer <<= s;
						j.code_bits -= s;
						zig = (uint) (stbi__jpeg_dezigzag[k++]);
						data[zig] = (short) (((r >> 8)*dequant[zig]));
					}
					else
					{
						int rs = (int) (stbi__jpeg_huff_decode(j, hac));
						if (rs < 0) return (int) (stbi__err("bad huffman code"));
						s = (int) (rs & 15 ? 1 : 0);
						r = (int) (rs >> 4);
						if (s == 0)
						{
							if (rs != 240) break;
							k += 16;
						}
						else
						{
							k += r;
							zig = (uint) (stbi__jpeg_dezigzag[k++]);
							data[zig] = (short) ((stbi__extend_receive(j, s)*dequant[zig]));
						}
					}
				}
			} while (k < 64);
			return (int) (1);
		}

		private static int stbi__jpeg_decode_block_prog_dc(stbi__jpeg j, Pointer<short> data, stbi__huffman hdc, int b)
		{
			int diff;
			int dc;
			int t;
			if (j.spec_end != 0) return (int) (stbi__err("can't merge dc and ac"));
			if (j.code_bits < 16) stbi__grow_buffer_unsafe(j);
			if (j.succ_high == 0)
			{
				memset(data, 0, 64*(data[0]).Size);
				t = (int) (stbi__jpeg_huff_decode(j, hdc));
				diff = (int) (t > 0 ? stbi__extend_receive(j, t) : 0);
				dc = (int) (j.img_comp[b].dc_pred + diff);
				j.img_comp[b].dc_pred = (int) (dc);
				data[0] = (short) ((dc << j.succ_low));
			}
			else
			{
				if ((stbi__jpeg_get_bit(j)) != 0) data[0] += (1 << j.succ_low);
			}

			return (int) (1);
		}

		private static int stbi__jpeg_decode_block_prog_ac(stbi__jpeg j, Pointer<short> data, stbi__huffman hac,
			Pointer<short> fac)
		{
			int k;
			if (j.spec_start == 0) return (int) (stbi__err("can't merge dc and ac"));
			if (j.succ_high == 0)
			{
				int shift = (int) (j.succ_low);
				if ((j.eob_run) != 0)
				{
					--j.eob_run;
					return (int) (1);
				}
				k = (int) (j.spec_start);
				do
				{
					{
						uint zig;
						int c;
						int r;
						int s;
						if (j.code_bits < 16) stbi__grow_buffer_unsafe(j);
						c = (int) ((j.code_buffer >> (32 - 9)) & ((1 << 9) - 1));
						r = (int) (fac[c]);
						if ((r) != 0)
						{
							k += (r >> 4) & 15;
							s = (int) (r & 15 ? 1 : 0);
							j.code_buffer <<= s;
							j.code_bits -= s;
							zig = (uint) (stbi__jpeg_dezigzag[k++]);
							data[zig] = (short) (((r >> 8) << shift));
						}
						else
						{
							int rs = (int) (stbi__jpeg_huff_decode(j, hac));
							if (rs < 0) return (int) (stbi__err("bad huffman code"));
							s = (int) (rs & 15 ? 1 : 0);
							r = (int) (rs >> 4);
							if (s == 0)
							{
								if (r < 15)
								{
									j.eob_run = (int) ((1 << r));
									if ((r) != 0) j.eob_run += stbi__jpeg_get_bits(j, r);
									--j.eob_run;
									break;
								}
								k += 16;
							}
							else
							{
								k += r;
								zig = (uint) (stbi__jpeg_dezigzag[k++]);
								data[zig] = (short) ((stbi__extend_receive(j, s) << shift));
							}
						}
					}
				} while (k <= j.spec_end);
			}
			else
			{
				short bit = (short) ((1 << j.succ_low));
				if ((j.eob_run) != 0)
				{
					--j.eob_run;
					for (k = (int) (j.spec_start); k <= j.spec_end; ++k)
					{
						Pointer<short> p = data[stbi__jpeg_dezigzag[k]];
						if (p.CurrentValue != 0)
							if ((stbi__jpeg_get_bit(j)) != 0)
								if ((p.CurrentValue & bit) == 0)
								{
									if (p.CurrentValue > 0) p.CurrentValue += bit
									else p.CurrentValue -= bit;
								}
					}
				}
				else
				{
					k = (int) (j.spec_start);
					do
					{
						{
							int r;
							int s;
							int rs = (int) (stbi__jpeg_huff_decode(j, hac));
							if (rs < 0) return (int) (stbi__err("bad huffman code"));
							s = (int) (rs & 15 ? 1 : 0);
							r = (int) (rs >> 4);
							if (s == 0)
							{
								if (r < 15)
								{
									j.eob_run = (int) ((1 << r) - 1);
									if ((r) != 0) j.eob_run += stbi__jpeg_get_bits(j, r);
									r = (int) (64);
								}
								else
								{
								}
							}
							else
							{
								if (s != 1) return (int) (stbi__err("bad huffman code"));
								if ((stbi__jpeg_get_bit(j)) != 0) s = (int) (bit)
								else s = (int) (-bit);
							}
							{
								Pointer<short> p = data[stbi__jpeg_dezigzag[k++]];
								if (p.CurrentValue != 0)
								{
									if ((stbi__jpeg_get_bit(j)) != 0)
										if ((p.CurrentValue & bit) == 0)
										{
											if (p.CurrentValue > 0) p.CurrentValue += bit
											else p.CurrentValue -= bit;
										}
								}
								else
								{
									if (r == 0)
									{
										p.CurrentValue = (short) (s);
										break;
									}
									--r;
								}
							}
						}
					} while (k <= j.spec_end);
				}
			}

			return (int) (1);
		}

		private static byte stbi__clamp(int x)
		{
			if (x > 255)
			{
				if (x < 0) return (byte) (0);
				if (x > 255) return (byte) (255);
			}

			return (byte) (x);
		}

		private static void stbi__idct_block(Pointer<byte> _out_, int out_stride, Pointer<short> data)
		{
			int i;
			Pointer<int> val = new Pointer<int>(64);
			Pointer<int> v = val;
			Pointer<byte> o;
			Pointer<short> d = data;
			for (i = (int) (0); i < 8; ++i , ++d , ++v)
			{
				if (d[8] == 0 && d[16] == 0 && d[24] == 0 && d[32] == 0 && d[40] == 0 && d[48] == 0 && d[56] == 0)
				{
					int dcterm = (int) (d[0] << 2);
					v[0] =
						(int)
							(v[8] =
								(int) (v[16] = (int) (v[24] = (int) (v[32] = (int) (v[40] = (int) (v[48] = (int) (v[56] = (int) (dcterm))))))));
				}
				else
				{
					int t0;
					int t1;
					int t2;
					int t3;
					int p1;
					int p2;
					int p3;
					int p4;
					int p5;
					int x0;
					int x1;
					int x2;
					int x3;
					p2 = (int) (d[16]);
					p3 = (int) (d[48]);
					p1 = (int) ((p2 + p3)*((((0.541196108)*4096 + 0.5))));
					t2 = (int) (p1 + p3*((((-1.84775901)*4096 + 0.5))));
					t3 = (int) (p1 + p2*((((0.765366852)*4096 + 0.5))));
					p2 = (int) (d[0]);
					p3 = (int) (d[32]);
					t0 = (int) (((p2 + p3) << 12));
					t1 = (int) (((p2 - p3) << 12));
					x0 = (int) (t0 + t3);
					x3 = (int) (t0 - t3);
					x1 = (int) (t1 + t2);
					x2 = (int) (t1 - t2);
					t0 = (int) (d[56]);
					t1 = (int) (d[40]);
					t2 = (int) (d[24]);
					t3 = (int) (d[8]);
					p3 = (int) (t0 + t2);
					p4 = (int) (t1 + t3);
					p1 = (int) (t0 + t3);
					p2 = (int) (t1 + t2);
					p5 = (int) ((p3 + p4)*((((1.17587554)*4096 + 0.5))));
					t0 = (int) (t0*((((0.29863134)*4096 + 0.5))));
					t1 = (int) (t1*((((2.0531199)*4096 + 0.5))));
					t2 = (int) (t2*((((3.07271099)*4096 + 0.5))));
					t3 = (int) (t3*((((1.50132108)*4096 + 0.5))));
					p1 = (int) (p5 + p1*((((-0.899976193)*4096 + 0.5))));
					p2 = (int) (p5 + p2*((((-2.56291556)*4096 + 0.5))));
					p3 = (int) (p3*((((-1.9615705)*4096 + 0.5))));
					p4 = (int) (p4*((((-0.390180647)*4096 + 0.5))));
					t3 += p1 + p4;
					t2 += p2 + p3;
					t1 += p2 + p4;
					t0 += p1 + p3;
					x0 += 512;
					x1 += 512;
					x2 += 512;
					x3 += 512;
					v[0] = (int) ((x0 + t3) >> 10);
					v[56] = (int) ((x0 - t3) >> 10);
					v[8] = (int) ((x1 + t2) >> 10);
					v[48] = (int) ((x1 - t2) >> 10);
					v[16] = (int) ((x2 + t1) >> 10);
					v[40] = (int) ((x2 - t1) >> 10);
					v[24] = (int) ((x3 + t0) >> 10);
					v[32] = (int) ((x3 - t0) >> 10);
				}
			}

			for (i = (int) (0) , v = val , o = _out_; i < 8; ++i , v += 8 , o += out_stride)
			{
				int t0;
				int t1;
				int t2;
				int t3;
				int p1;
				int p2;
				int p3;
				int p4;
				int p5;
				int x0;
				int x1;
				int x2;
				int x3;
				p2 = (int) (v[2]);
				p3 = (int) (v[6]);
				p1 = (int) ((p2 + p3)*((((0.541196108)*4096 + 0.5))));
				t2 = (int) (p1 + p3*((((-1.84775901)*4096 + 0.5))));
				t3 = (int) (p1 + p2*((((0.765366852)*4096 + 0.5))));
				p2 = (int) (v[0]);
				p3 = (int) (v[4]);
				t0 = (int) (((p2 + p3) << 12));
				t1 = (int) (((p2 - p3) << 12));
				x0 = (int) (t0 + t3);
				x3 = (int) (t0 - t3);
				x1 = (int) (t1 + t2);
				x2 = (int) (t1 - t2);
				t0 = (int) (v[7]);
				t1 = (int) (v[5]);
				t2 = (int) (v[3]);
				t3 = (int) (v[1]);
				p3 = (int) (t0 + t2);
				p4 = (int) (t1 + t3);
				p1 = (int) (t0 + t3);
				p2 = (int) (t1 + t2);
				p5 = (int) ((p3 + p4)*((((1.17587554)*4096 + 0.5))));
				t0 = (int) (t0*((((0.29863134)*4096 + 0.5))));
				t1 = (int) (t1*((((2.0531199)*4096 + 0.5))));
				t2 = (int) (t2*((((3.07271099)*4096 + 0.5))));
				t3 = (int) (t3*((((1.50132108)*4096 + 0.5))));
				p1 = (int) (p5 + p1*((((-0.899976193)*4096 + 0.5))));
				p2 = (int) (p5 + p2*((((-2.56291556)*4096 + 0.5))));
				p3 = (int) (p3*((((-1.9615705)*4096 + 0.5))));
				p4 = (int) (p4*((((-0.390180647)*4096 + 0.5))));
				t3 += p1 + p4;
				t2 += p2 + p3;
				t1 += p2 + p4;
				t0 += p1 + p3;
				x0 += 65536 + (128 << 17);
				x1 += 65536 + (128 << 17);
				x2 += 65536 + (128 << 17);
				x3 += 65536 + (128 << 17);
				o[0] = (byte) (stbi__clamp((x0 + t3) >> 17));
				o[7] = (byte) (stbi__clamp((x0 - t3) >> 17));
				o[1] = (byte) (stbi__clamp((x1 + t2) >> 17));
				o[6] = (byte) (stbi__clamp((x1 - t2) >> 17));
				o[2] = (byte) (stbi__clamp((x2 + t1) >> 17));
				o[5] = (byte) (stbi__clamp((x2 - t1) >> 17));
				o[3] = (byte) (stbi__clamp((x3 + t0) >> 17));
				o[4] = (byte) (stbi__clamp((x3 - t0) >> 17));
			}

		}

		private static byte stbi__get_marker(stbi__jpeg j)
		{
			byte x;
			if (j.marker != 255)
			{
				x = (byte) (j.marker);
				j.marker = (byte) (255);
				return (byte) (x);
			}

			x = (byte) (stbi__get8(j.s));
			if (x != 255) return (byte) (255);
			x = (byte) (stbi__get8(j.s));
			return (byte) (x);
		}

		private static void stbi__jpeg_reset(stbi__jpeg j)
		{
			j.code_bits = (int) (0);
			j.code_buffer = (uint) (0);
			j.nomore = (int) (0);
			j.img_comp[0].dc_pred = (int) (j.img_comp[1].dc_pred = (int) (j.img_comp[2].dc_pred = (int) (0)));
			j.marker = (byte) (255);
			j.todo = (int) (j.restart_interval > 0 ? j.restart_interval : 2147483647);
			j.eob_run = (int) (0);
		}

		private static int stbi__parse_entropy_coded_data(stbi__jpeg z)
		{
			stbi__jpeg_reset(z);
			if (z.progressive == 0)
			{
				if (z.scan_n == 1)
				{
					int i;
					int j;
					Pointer<short> data = new Pointer<short>(64);
					int n = (int) (z.order[0]);
					int w = (int) ((z.img_comp[n].x + 7) >> 3);
					int h = (int) ((z.img_comp[n].y + 7) >> 3);
					for (j = (int) (0); j < h; ++j)
					{
						for (i = (int) (0); i < w; ++i)
						{
							int ha = (int) (z.img_comp[n].ha);
							if (
								stbi__jpeg_decode_block(z, data, z.huff_dc + z.img_comp[n].hd, z.huff_ac + ha, z.fast_ac[ha], n,
									z.dequant[z.img_comp[n].tq]) == 0) return (int) (0);
							z.idct_block_kernel(z.img_comp[n].data + z.img_comp[n].w2*j*8 + i*8, z.img_comp[n].w2, data);
							if (--z.todo <= 0)
							{
								if (z.code_bits < 24) stbi__grow_buffer_unsafe(z);
								if (((z.marker) >= 208 && (z.marker) <= 215) == 0) return (int) (1);
								stbi__jpeg_reset(z);
							}
						}
					}
					return (int) (1);
				}
				else
				{
					int i;
					int j;
					int k;
					int x;
					int y;
					Pointer<short> data = new Pointer<short>(64);
					for (j = (int) (0); j < z.img_mcu_y; ++j)
					{
						for (i = (int) (0); i < z.img_mcu_x; ++i)
						{
							for (k = (int) (0); k < z.scan_n; ++k)
							{
								int n = (int) (z.order[k]);
								for (y = (int) (0); y < z.img_comp[n].v; ++y)
								{
									for (x = (int) (0); x < z.img_comp[n].h; ++x)
									{
										int x2 = (int) ((i*z.img_comp[n].h + x)*8);
										int y2 = (int) ((j*z.img_comp[n].v + y)*8);
										int ha = (int) (z.img_comp[n].ha);
										if (
											stbi__jpeg_decode_block(z, data, z.huff_dc + z.img_comp[n].hd, z.huff_ac + ha, z.fast_ac[ha], n,
												z.dequant[z.img_comp[n].tq]) == 0) return (int) (0);
										z.idct_block_kernel(z.img_comp[n].data + z.img_comp[n].w2*y2 + x2, z.img_comp[n].w2, data);
									}
								}
							}
							if (--z.todo <= 0)
							{
								if (z.code_bits < 24) stbi__grow_buffer_unsafe(z);
								if (((z.marker) >= 208 && (z.marker) <= 215) == 0) return (int) (1);
								stbi__jpeg_reset(z);
							}
						}
					}
					return (int) (1);
				}
			}
			else
			{
				if (z.scan_n == 1)
				{
					int i;
					int j;
					int n = (int) (z.order[0]);
					int w = (int) ((z.img_comp[n].x + 7) >> 3);
					int h = (int) ((z.img_comp[n].y + 7) >> 3);
					for (j = (int) (0); j < h; ++j)
					{
						for (i = (int) (0); i < w; ++i)
						{
							Pointer<short> data = z.img_comp[n].coeff + 64*(i + j*z.img_comp[n].coeff_w);
							if (z.spec_start == 0)
							{
								if (stbi__jpeg_decode_block_prog_dc(z, data, z.huff_dc[z.img_comp[n].hd], n) == 0) return (int) (0);
							}
							else
							{
								int ha = (int) (z.img_comp[n].ha);
								if (stbi__jpeg_decode_block_prog_ac(z, data, z.huff_ac[ha], z.fast_ac[ha]) == 0) return (int) (0);
							}
							if (--z.todo <= 0)
							{
								if (z.code_bits < 24) stbi__grow_buffer_unsafe(z);
								if (((z.marker) >= 208 && (z.marker) <= 215) == 0) return (int) (1);
								stbi__jpeg_reset(z);
							}
						}
					}
					return (int) (1);
				}
				else
				{
					int i;
					int j;
					int k;
					int x;
					int y;
					for (j = (int) (0); j < z.img_mcu_y; ++j)
					{
						for (i = (int) (0); i < z.img_mcu_x; ++i)
						{
							for (k = (int) (0); k < z.scan_n; ++k)
							{
								int n = (int) (z.order[k]);
								for (y = (int) (0); y < z.img_comp[n].v; ++y)
								{
									for (x = (int) (0); x < z.img_comp[n].h; ++x)
									{
										int x2 = (int) ((i*z.img_comp[n].h + x));
										int y2 = (int) ((j*z.img_comp[n].v + y));
										Pointer<short> data = z.img_comp[n].coeff + 64*(x2 + y2*z.img_comp[n].coeff_w);
										if (stbi__jpeg_decode_block_prog_dc(z, data, z.huff_dc[z.img_comp[n].hd], n) == 0) return (int) (0);
									}
								}
							}
							if (--z.todo <= 0)
							{
								if (z.code_bits < 24) stbi__grow_buffer_unsafe(z);
								if (((z.marker) >= 208 && (z.marker) <= 215) == 0) return (int) (1);
								stbi__jpeg_reset(z);
							}
						}
					}
					return (int) (1);
				}
			}

		}

		private static void stbi__jpeg_dequantize(Pointer<short> data, Pointer<byte> dequant)
		{
			int i;
			for (i = (int) (0); i < 64; ++i) data[i] *= dequant[i];
		}

		private static void stbi__jpeg_finish(stbi__jpeg z)
		{
			if ((z.progressive) != 0)
			{
				int i;
				int j;
				int n;
				for (n = (int) (0); n < z.s.img_n; ++n)
				{
					int w = (int) ((z.img_comp[n].x + 7) >> 3);
					int h = (int) ((z.img_comp[n].y + 7) >> 3);
					for (j = (int) (0); j < h; ++j)
					{
						for (i = (int) (0); i < w; ++i)
						{
							Pointer<short> data = z.img_comp[n].coeff + 64*(i + j*z.img_comp[n].coeff_w);
							stbi__jpeg_dequantize(data, z.dequant[z.img_comp[n].tq]);
							z.idct_block_kernel(z.img_comp[n].data + z.img_comp[n].w2*j*8 + i*8, z.img_comp[n].w2, data);
						}
					}
				}
			}

		}

		private static int stbi__process_marker(stbi__jpeg z, int m)
		{
			int L;
			switch (m)
			{
				case 255:
					return (int) (stbi__err("expected marker"));
				case 221:
					if (stbi__get16be(z.s) != 4) return (int) (stbi__err("bad DRI len"));
					z.restart_interval = (int) (stbi__get16be(z.s));
					return (int) (1);
				case 219:
					L = (int) (stbi__get16be(z.s) - 2);
				{
					int q = (int) (stbi__get8(z.s));
					int p = (int) (q >> 4);
					int t = (int) (q & 15);
					int i;
					if (p != 0) return (int) (stbi__err("bad DQT type"));
					if (t > 3) return (int) (stbi__err("bad DQT table"));
					for (i = (int) (0); i < 64; ++i) z.dequant[t][stbi__jpeg_dezigzag[i]] = (byte) (stbi__get8(z.s));
					L -= 65;
				}
					return (int) (L == 0 ? 1 : 0);
				case 196:
					L = (int) (stbi__get16be(z.s) - 2);
				{
					Pointer<byte> v;
					Pointer<int> sizes = new Pointer<int>(16);
					int i;
					int n = (int) (0);
					int q = (int) (stbi__get8(z.s));
					int tc = (int) (q >> 4);
					int th = (int) (q & 15);
					if (tc > 1 || th > 3) return (int) (stbi__err("bad DHT header"));
					for (i = (int) (0); i < 16; ++i)
					{
						sizes[i] = (int) (stbi__get8(z.s));
						n += sizes[i];
					}
					L -= 17;
					if (tc == 0)
					{
						if (stbi__build_huffman(z.huff_dc + th, sizes) == 0) return (int) (0);
						v = z.huff_dc[th].values;
					}
					else
					{
						if (stbi__build_huffman(z.huff_ac + th, sizes) == 0) return (int) (0);
						v = z.huff_ac[th].values;
					}
					for (i = (int) (0); i < n; ++i) v[i] = (byte) (stbi__get8(z.s));
					if (tc != 0) stbi__build_fast_ac(z.fast_ac[th], z.huff_ac + th);
					L -= n;
				}
					return (int) (L == 0 ? 1 : 0);
			}

			if (((m >= 224 && m <= 239)) != 0 || m == 254)
			{
				stbi__skip(z.s, stbi__get16be(z.s) - 2);
				return (int) (1);
			}

			return (int) (0);
		}

		private static int stbi__process_scan_header(stbi__jpeg z)
		{
			int i;
			int Ls = (int) (stbi__get16be(z.s));
			z.scan_n = (int) (stbi__get8(z.s));
			if (z.scan_n < 1 || z.scan_n > 4 || z.scan_n > z.s.img_n) return (int) (stbi__err("bad SOS component count"));
			if (Ls != 6 + 2*z.scan_n) return (int) (stbi__err("bad SOS len"));
			for (i = (int) (0); i < z.scan_n; ++i)
			{
				int id = (int) (stbi__get8(z.s));
				int which;
				int q = (int) (stbi__get8(z.s));
				for (which = (int) (0); which < z.s.img_n; ++which) if (z.img_comp[which].id == id) break;
				if (which == z.s.img_n) return (int) (0);
				z.img_comp[which].hd = (int) (q >> 4);
				if (z.img_comp[which].hd > 3) return (int) (stbi__err("bad DC huff"));
				z.img_comp[which].ha = (int) (q & 15 ? 1 : 0);
				if (z.img_comp[which].ha > 3) return (int) (stbi__err("bad AC huff"));
				z.order[i] = (int) (which);
			}

			{
				int aa;
				z.spec_start = (int) (stbi__get8(z.s));
				z.spec_end = (int) (stbi__get8(z.s));
				aa = (int) (stbi__get8(z.s));
				z.succ_high = (int) ((aa >> 4));
				z.succ_low = (int) ((aa & 15));
				if ((z.progressive) != 0)
				{
					if (z.spec_start > 63 || z.spec_end > 63 || z.spec_start > z.spec_end || z.succ_high > 13 || z.succ_low > 13)
						return (int) (stbi__err("bad SOS"));
				}
				else
				{
					if (z.spec_start != 0) return (int) (stbi__err("bad SOS"));
					if (z.succ_high != 0 || z.succ_low != 0) return (int) (stbi__err("bad SOS"));
					z.spec_end = (int) (63);
				}
			}

			return (int) (1);
		}

		private static int stbi__process_frame_header(stbi__jpeg z, int scan)
		{
			stbi__context s = z.s;
			int Lf;
			int p;
			int i;
			int q;
			int h_max = (int) (1);
			int v_max = (int) (1);
			int c;
			Lf = (int) (stbi__get16be(s));
			if (Lf < 11) return (int) (stbi__err("bad SOF len"));
			p = (int) (stbi__get8(s));
			if (p != 8) return (int) (stbi__err("only 8-bit"));
			s.img_y = (uint) (stbi__get16be(s));
			if (s.img_y == 0) return (int) (stbi__err("no header height"));
			s.img_x = (uint) (stbi__get16be(s));
			if (s.img_x == 0) return (int) (stbi__err("0 width"));
			c = (int) (stbi__get8(s));
			if (c != 3 && c != 1) return (int) (stbi__err("bad component count"));
			s.img_n = (int) (c);
			for (i = (int) (0); i < c; ++i)
			{
				z.img_comp[i].data = (null /*0*/);
				z.img_comp[i].linebuf = (null /*0*/);
			}

			if (Lf != 8 + 3*s.img_n) return (int) (stbi__err("bad SOF len"));
			z.rgb = (int) (0);
			for (i = (int) (0); i < s.img_n; ++i)
			{
				Pointer<byte> rgb = new Pointer<byte>(new byte[] {, , 
			}
			)
				;
				z.img_comp[i].id = (int) (stbi__get8(s));
				if (z.img_comp[i].id != i + 1)
					if (z.img_comp[i].id != i)
					{
						if (z.img_comp[i].id != rgb[i]) return (int) (stbi__err("bad component ID"));
						++z.rgb;
					}
				q = (int) (stbi__get8(s));
				z.img_comp[i].h = (int) ((q >> 4));
				if (z.img_comp[i].h == 0 || z.img_comp[i].h > 4) return (int) (stbi__err("bad H"));
				z.img_comp[i].v = (int) (q & 15 ? 1 : 0);
				if (z.img_comp[i].v == 0 || z.img_comp[i].v > 4) return (int) (stbi__err("bad V"));
				z.img_comp[i].tq = (int) (stbi__get8(s));
				if (z.img_comp[i].tq > 3) return (int) (stbi__err("bad TQ"));
			}

			if (scan != STBI__SCAN_load) return (int) (1);
			if ((1 << 30)/s.img_x/s.img_n < s.img_y) return (int) (stbi__err("too large"));
			for (i = (int) (0); i < s.img_n; ++i)
			{
				if (z.img_comp[i].h > h_max) h_max = (int) (z.img_comp[i].h);
				if (z.img_comp[i].v > v_max) v_max = (int) (z.img_comp[i].v);
			}

			z.img_h_max = (int) (h_max);
			z.img_v_max = (int) (v_max);
			z.img_mcu_w = (int) (h_max*8);
			z.img_mcu_h = (int) (v_max*8);
			z.img_mcu_x = (int) ((s.img_x + z.img_mcu_w - 1)/z.img_mcu_w);
			z.img_mcu_y = (int) ((s.img_y + z.img_mcu_h - 1)/z.img_mcu_h);
			for (i = (int) (0); i < s.img_n; ++i)
			{
				z.img_comp[i].x = (int) ((s.img_x*z.img_comp[i].h + h_max - 1)/h_max);
				z.img_comp[i].y = (int) ((s.img_y*z.img_comp[i].v + v_max - 1)/v_max);
				z.img_comp[i].w2 = (int) (z.img_mcu_x*z.img_comp[i].h*8);
				z.img_comp[i].h2 = (int) (z.img_mcu_y*z.img_comp[i].v*8);
				z.img_comp[i].raw_data = (object) (stbi__malloc(z.img_comp[i].w2*z.img_comp[i].h2 + 15));
				if (z.img_comp[i].raw_data == (null /*0*/))
				{
					for (--i; i >= 0; --i)
					{
						free(z.img_comp[i].raw_data);
						z.img_comp[i].raw_data = (object) ((null /*0*/));
					}
					return (int) (stbi__err("outofmem"));
				}
				z.img_comp[i].data = null /*((z.img_comp[i].raw_data + 15) & ~15)*/;
				z.img_comp[i].linebuf = (null /*0*/);
				if ((z.progressive) != 0)
				{
					z.img_comp[i].coeff_w = (int) ((z.img_comp[i].w2 + 7) >> 3);
					z.img_comp[i].coeff_h = (int) ((z.img_comp[i].h2 + 7) >> 3);
					z.img_comp[i].raw_coeff = (object) (malloc(z.img_comp[i].coeff_w*z.img_comp[i].coeff_h*64*sizeof (short) + +15));
					z.img_comp[i].coeff = null /*((z.img_comp[i].raw_coeff + 15) & ~15)*/;
				}
				else
				{
					z.img_comp[i].coeff = 0;
					z.img_comp[i].raw_coeff = (object) (0);
				}
			}

			return (int) (1);
		}

		private static int stbi__decode_jpeg_header(stbi__jpeg z, int scan)
		{
			int m;
			z.marker = (byte) (255);
			m = (int) (stbi__get_marker(z));
			if (((m) == 216) == 0) return (int) (stbi__err("no SOI"));
			if (scan == STBI__SCAN_type) return (int) (1);
			m = (int) (stbi__get_marker(z));
			{
				if (stbi__process_marker(z, m) == 0) return (int) (0);
				m = (int) (stbi__get_marker(z));
				{
					if ((stbi__at_eof(z.s)) != 0) return (int) (stbi__err("no SOF"));
					m = (int) (stbi__get_marker(z));
				}
			}

			z.progressive = (int) (((m) == 194));
			if (stbi__process_frame_header(z, scan) == 0) return (int) (0);
			return (int) (1);
		}

		private static int stbi__decode_jpeg_image(stbi__jpeg j)
		{
			int m;
			for (m = (int) (0); m < 4; m++)
			{
				j.img_comp[m].raw_data = (object) ((null /*0*/));
				j.img_comp[m].raw_coeff = (object) ((null /*0*/));
			}

			j.restart_interval = (int) (0);
			if (stbi__decode_jpeg_header(j, STBI__SCAN_load) == 0) return (int) (0);
			m = (int) (stbi__get_marker(j));
			{
				if ((((m) == 218)) != 0)
				{
					if (stbi__process_scan_header(j) == 0) return (int) (0);
					if (stbi__parse_entropy_coded_data(j) == 0) return (int) (0);
					if (j.marker == 255)
					{
						{
							int x = (int) (stbi__get8(j.s));
							if (x == 255)
							{
								j.marker = (byte) (stbi__get8(j.s));
								break;
							}
							else if (x != 0)
							{
								return (int) (stbi__err("junk before marker"));
							}
						}
					}
				}
				else
				{
					if (stbi__process_marker(j, m) == 0) return (int) (0);
				}
				m = (int) (stbi__get_marker(j));
			}

			if ((j.progressive) != 0) stbi__jpeg_finish(j);
			return (int) (1);
		}

		private static Pointer<byte> resample_row_1(Pointer<byte> _out_, Pointer<byte> in_near, Pointer<byte> in_far, int w,
			int hs)
		{
			(_out_);
			(in_far);
			(w);
			(hs);
			return in_near;
		}

		private static Pointer<byte> stbi__resample_row_v_2(Pointer<byte> _out_, Pointer<byte> in_near, Pointer<byte> in_far,
			int w, int hs)
		{
			int i;
			(hs);
			for (i = (int) (0); i < w; ++i) _out_[i] = (byte) ((((3*in_near[i] + in_far[i] + 2) >> 2)));
			return _out_;
		}

		private static Pointer<byte> stbi__resample_row_h_2(Pointer<byte> _out_, Pointer<byte> in_near, Pointer<byte> in_far,
			int w, int hs)
		{
			int i;
			Pointer<byte> input = in_near;
			if (w == 1)
			{
				_out_[0] = (byte) (_out_[1] = (byte) (input[0]));
				return _out_;
			}

			_out_[0] = (byte) (input[0]);
			_out_[1] = (byte) ((((input[0]*3 + input[1] + 2) >> 2)));
			for (i = (int) (1); i < w - 1; ++i)
			{
				int n = (int) (3*input[i] + 2);
				_out_[i*2 + 0] = (byte) ((((n + input[i - 1]) >> 2)));
				_out_[i*2 + 1] = (byte) ((((n + input[i + 1]) >> 2)));
			}

			_out_[i*2 + 0] = (byte) ((((input[w - 2]*3 + input[w - 1] + 2) >> 2)));
			_out_[i*2 + 1] = (byte) (input[w - 1]);
			(in_far);
			(hs);
			return _out_;
		}

		private static Pointer<byte> stbi__resample_row_hv_2(Pointer<byte> _out_, Pointer<byte> in_near, Pointer<byte> in_far,
			int w, int hs)
		{
			int i;
			int t0;
			int t1;
			if (w == 1)
			{
				_out_[0] = (byte) (_out_[1] = (byte) ((((3*in_near[0] + in_far[0] + 2) >> 2))));
				return _out_;
			}

			t1 = (int) (3*in_near[0] + in_far[0]);
			_out_[0] = (byte) ((((t1 + 2) >> 2)));
			for (i = (int) (1); i < w; ++i)
			{
				t0 = (int) (t1);
				t1 = (int) (3*in_near[i] + in_far[i]);
				_out_[i*2 - 1] = (byte) ((((3*t0 + t1 + 8) >> 4)));
				_out_[i*2] = (byte) ((((3*t1 + t0 + 8) >> 4)));
			}

			_out_[w*2 - 1] = (byte) ((((t1 + 2) >> 2)));
			(hs);
			return _out_;
		}

		private static Pointer<byte> stbi__resample_row_generic(Pointer<byte> _out_, Pointer<byte> in_near,
			Pointer<byte> in_far, int w, int hs)
		{
			int i;
			int j;
			(in_far);
			for (i = (int) (0); i < w; ++i) for (j = (int) (0); j < hs; ++j) _out_[i*hs + j] = (byte) (in_near[i]);
			return _out_;
		}

		private static void stbi__YCbCr_to_RGB_row(Pointer<byte> _out_, Pointer<byte> y, Pointer<byte> pcb, Pointer<byte> pcr,
			int count, int step)
		{
			int i;
			for (i = (int) (0); i < count; ++i)
			{
				int y_fixed = (int) ((y[i] << 20) + (1 << 19));
				int r;
				int g;
				int b;
				int cr = (int) (pcr[i] - 128);
				int cb = (int) (pcb[i] - 128);
				r = (int) (y_fixed + cr*((((1.40199995)*4096 + 0.5)) << 8));
				g =
					(int) (y_fixed + (cr*-((((0.714139997)*4096 + 0.5)) << 8)) + ((cb*-((((0.344139993)*4096 + 0.5)) << 8)) & -65536));
				b = (int) (y_fixed + cb*((((1.77199996)*4096 + 0.5)) << 8));
				r >>= 20;
				g >>= 20;
				b >>= 20;
				if (r > 255)
				{
					if (r < 0) r = (int) (0)
					else r = (int) (255);
				}
				if (g > 255)
				{
					if (g < 0) g = (int) (0)
					else g = (int) (255);
				}
				if (b > 255)
				{
					if (b < 0) b = (int) (0)
					else b = (int) (255);
				}
				_out_[0] = (byte) (r);
				_out_[1] = (byte) (g);
				_out_[2] = (byte) (b);
				_out_[3] = (byte) (255);
				_out_ += step;
			}

		}

		private static void stbi__setup_jpeg(stbi__jpeg j)
		{
			j.idct_block_kernel = stbi__idct_block;
			j.YCbCr_to_RGB_kernel = stbi__YCbCr_to_RGB_row;
			j.resample_row_hv_2_kernel = stbi__resample_row_hv_2;
		}

		private static void stbi__cleanup_jpeg(stbi__jpeg j)
		{
			int i;
			for (i = (int) (0); i < j.s.img_n; ++i)
			{
				if (j.img_comp[i].raw_data)
				{
					free(j.img_comp[i].raw_data);
					j.img_comp[i].raw_data = (object) ((null /*0*/));
					j.img_comp[i].data = (null /*0*/);
				}
				if (j.img_comp[i].raw_coeff)
				{
					free(j.img_comp[i].raw_coeff);
					j.img_comp[i].raw_coeff = (object) (0);
					j.img_comp[i].coeff = 0;
				}
				if ((j.img_comp[i].linebuf) != null)
				{
					free(j.img_comp[i].linebuf);
					j.img_comp[i].linebuf = (null /*0*/);
				}
			}

		}

		private static Pointer<byte> load_jpeg_image(stbi__jpeg z, Pointer<int> out_x, Pointer<int> out_y, Pointer<int> comp,
			int req_comp)
		{
			int n;
			int decode_n;
			z.s.img_n = (int) (0);
			if (req_comp < 0 || req_comp > 4) return (null /*(stbi__err("bad req_comp") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
			if (stbi__decode_jpeg_image(z) == 0)
			{
				stbi__cleanup_jpeg(z);
				return (null /*0*/);
			}

			n = (int) (req_comp > 0 ? req_comp : z.s.img_n);
			if (z.s.img_n == 3 && n < 3) decode_n = (int) (1)
			else decode_n = (int) (z.s.img_n);
			{
				int k;
				uint i;
				uint j;
				Pointer<byte> output;
				Pointer<Pointer<byte>> coutput = new Pointer<Pointer<byte>>(4);
				stbi__resample res_comp = new stbi__resample(4);
				for (k = (int) (0); k < decode_n; ++k)
				{
					stbi__resample r = res_comp[k];
					z.img_comp[k].linebuf = stbi__malloc(z.s.img_x + 3);
					if (z.img_comp[k].linebuf == 0)
					{
						stbi__cleanup_jpeg(z);
						return (null /*(stbi__err("outofmem") > 0?(null /*0*/):
						(null /*0*/))
						*/)
						;
					}
					r.hs = (int) (z.img_h_max/z.img_comp[k].h);
					r.vs = (int) (z.img_v_max/z.img_comp[k].v);
					r.ystep = (int) (r.vs >> 1);
					r.w_lores = (int) ((z.s.img_x + r.hs - 1)/r.hs);
					r.ypos = (int) (0);
					r.line0 = r.line1 = z.img_comp[k].data;
					if (r.hs == 1 && r.vs == 1) r.resample = resample_row_1
					else if (r.hs == 1 && r.vs == 2) r.resample = stbi__resample_row_v_2
					else if (r.hs == 2 && r.vs == 1) r.resample = stbi__resample_row_h_2
					else if (r.hs == 2 && r.vs == 2) r.resample = z.resample_row_hv_2_kernel
					else r.resample = stbi__resample_row_generic;
				}
				output = stbi__malloc(n*z.s.img_x*z.s.img_y + 1);
				if (output == 0)
				{
					stbi__cleanup_jpeg(z);
					return (null /*(stbi__err("outofmem") > 0?(null /*0*/):
					(null /*0*/))
					*/)
					;
				}
				for (j = (uint) (0); j < z.s.img_y; ++j)
				{
					Pointer<byte> out =
					output + n*z.s.img_x*j;
					for (k = (int) (0); k < decode_n; ++k)
					{
						stbi__resample r = res_comp[k];
						int y_bot = (int) (r.ystep >= (r.vs >> 1));
						coutput[k] = r.resample(z.img_comp[k].linebuf, y_bot > 0 ? r.line1 : r.line0, y_bot > 0 ? r.line0 : r.line1,
							r.w_lores, r.hs);
						if (++r.ystep >= r.vs)
						{
							r.ystep = (int) (0);
							r.line0 = r.line1;
							if (++r.ypos < z.img_comp[k].y) r.line1 += z.img_comp[k].w2;
						}
					}
					if (n >= 3)
					{
						Pointer<byte> y = coutput[0];
						if (z.s.img_n == 3)
						{
							if (z.rgb == 3)
							{
								for (i = (uint) (0); i < z.s.img_x; ++i)
								{
									_out_[0] = (byte) (y[i]);
									_out_[1] = (byte) (coutput[1][i]);
									_out_[2] = (byte) (coutput[2][i]);
									_out_[3] = (byte) (255);
									_out_ += n;
								}
							}
							else
							{
								z.YCbCr_to_RGB_kernel(_out_, y, coutput[1], coutput[2], z.s.img_x, n);
							}
						}
						else
							for (i = (uint) (0); i < z.s.img_x; ++i)
							{
								_out_[0] = (byte) (_out_[1] = (byte) (_out_[2] = (byte) (y[i])));
								_out_[3] = (byte) (255);
								_out_ += n;
							}
					}
					else
					{
						Pointer<byte> y = coutput[0];
						if (n == 1) for (i = (uint) (0); i < z.s.img_x; ++i) _out_[i] = (byte) (y[i])
						else for (i = (uint) (0); i < z.s.img_x; ++i) _out_.GetAndMove() = (byte) (y[i]) ,
						_out_.GetAndMove() = (byte) (255);
					}
				}
				stbi__cleanup_jpeg(z);
				out_x.CurrentValue = (int) (z.s.img_x);
				out_y.CurrentValue = (int) (z.s.img_y);
				if ((comp) != null) comp.CurrentValue = (int) (z.s.img_n);
				return output;
			}

		}

		private static Pointer<byte> stbi__jpeg_load(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp,
			int req_comp)
		{
			Pointer<byte> result;
			stbi__jpeg j = stbi__malloc(.Size)
			;
			j.s = s;
			stbi__setup_jpeg(j);
			result = load_jpeg_image(j, x, y, comp, req_comp);
			free(j);
			return result;
		}

		private static int stbi__jpeg_test(stbi__context s)
		{
			int r;
			stbi__jpeg j = new stbi__jpeg();
			j.s = s;
			stbi__setup_jpeg(j);
			r = (int) (stbi__decode_jpeg_header(j, STBI__SCAN_type));
			stbi__rewind(s);
			return (int) (r);
		}

		private static int stbi__jpeg_info_raw(stbi__jpeg j, Pointer<int> x, Pointer<int> y, Pointer<int> comp)
		{
			if (stbi__decode_jpeg_header(j, STBI__SCAN_header) == 0)
			{
				stbi__rewind(j.s);
				return (int) (0);
			}

			if ((x) != null) x.CurrentValue = (int) (j.s.img_x);
			if ((y) != null) y.CurrentValue = (int) (j.s.img_y);
			if ((comp) != null) comp.CurrentValue = (int) (j.s.img_n);
			return (int) (1);
		}

		private static int stbi__jpeg_info(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp)
		{
			int result;
			stbi__jpeg j = (stbi__malloc(.Size))
			;
			j.s = s;
			result = (int) (stbi__jpeg_info_raw(j, x, y, comp));
			free(j);
			return (int) (result);
		}

		private static int stbi__bitreverse16(int n)
		{
			n = (int) (((n & 43690) >> 1) | ((n & 21845) << 1) ? 1 : 0);
			n = (int) (((n & 52428) >> 2) | ((n & 13107) << 2) ? 1 : 0);
			n = (int) (((n & 61680) >> 4) | ((n & 3855) << 4) ? 1 : 0);
			n = (int) (((n & 65280) >> 8) | ((n & 255) << 8) ? 1 : 0);
			return (int) (n);
		}

		private static int stbi__bit_reverse(int v, int bits)
		{
			return (int) (stbi__bitreverse16(v) >> (16 - bits));
		}

		private static int stbi__zbuild_huffman(stbi__zhuffman z, Pointer<byte> sizelist, int num)
		{
			int i;
			int k = (int) (0);
			int code;
			Pointer<int> next_code = new Pointer<int>(16);
			Pointer<int> sizes = new Pointer<int>(17);
			memset(sizes, 0, (sizes).Size);
			memset(z.fast, 0, (z.fast).Size);
			for (i = (int) (0); i < num; ++i) ++sizes[sizelist[i]];
			sizes[0] = (int) (0);
			for (i = (int) (1); i < 16; ++i) if (sizes[i] > (1 << i)) return (int) (stbi__err("bad sizes"));
			code = (int) (0);
			for (i = (int) (1); i < 16; ++i)
			{
				next_code[i] = (int) (code);
				z.firstcode[i] = (ushort) (code);
				z.firstsymbol[i] = (ushort) (k);
				code = (int) ((code + sizes[i]));
				if ((sizes[i]) != 0) if (code - 1 >= (1 << i)) return (int) (stbi__err("bad codelengths"));
				z.maxcode[i] = (int) (code << (16 - i));
				code <<= 1;
				k += sizes[i];
			}

			z.maxcode[16] = (int) (65536);
			for (i = (int) (0); i < num; ++i)
			{
				int s = (int) (sizelist[i]);
				if ((s) != 0)
				{
					int c = (int) (next_code[s] - z.firstcode[s] + z.firstsymbol[s]);
					ushort fastv = (ushort) (((s << 9) | i));
					z.size[c] = (byte) (s);
					z.value[c] = (ushort) (i);
					if (s <= 9)
					{
						int j = (int) (stbi__bit_reverse(next_code[s], s));
						{
							z.fast[j] = (ushort) (fastv);
							j += (1 << s);
						}
					}
					++next_code[s];
				}
			}

			return (int) (1);
		}

		private static byte stbi__zget8(stbi__zbuf z)
		{
			if (z.zbuffer >= z.zbuffer_end) return (byte) (0);
			return (byte) (z.zbuffer.GetAndMove());
		}

		private static void stbi__fill_bits(stbi__zbuf z)
		{
			do
			{
				{
					;
					z.code_buffer |= stbi__zget8(z) << z.num_bits;
					z.num_bits += 8;
				}
			} while (z.num_bits <= 24);
		}

		private static uint stbi__zreceive(stbi__zbuf z, int n)
		{
			uint k;
			if (z.num_bits < n) stbi__fill_bits(z);
			k = (uint) (z.code_buffer & ((1 << n) - 1) ? 1 : 0);
			z.code_buffer >>= n;
			z.num_bits -= n;
			return (uint) (k);
		}

		private static int stbi__zhuffman_decode_slowpath(stbi__zbuf a, stbi__zhuffman z)
		{
			int b;
			int s;
			int k;
			k = (int) (stbi__bit_reverse(a.code_buffer, 16));
			for (s = (int) (9 + 1);; ++s) if (k < z.maxcode[s]) break;
			if (s == 16) return (int) (-1);
			b = (int) ((k >> (16 - s)) - z.firstcode[s] + z.firstsymbol[s]);
			a.code_buffer >>= s;
			a.num_bits -= s;
			return (int) (z.value[b]);
		}

		private static int stbi__zhuffman_decode(stbi__zbuf a, stbi__zhuffman z)
		{
			int b;
			int s;
			if (a.num_bits < 16) stbi__fill_bits(a);
			b = (int) (z.fast[a.code_buffer & ((1 << 9) - 1)]);
			if ((b) != 0)
			{
				s = (int) (b >> 9);
				a.code_buffer >>= s;
				a.num_bits -= s;
				return (int) (b & 511 ? 1 : 0);
			}

			return (int) (stbi__zhuffman_decode_slowpath(a, z));
		}

		private static int stbi__zexpand(stbi__zbuf z, Pointer<sbyte> zout, int n)
		{
			Pointer<sbyte> q;
			int cur;
			int limit;
			int old_limit;
			z.zout = zout;
			if (z.z_expandable == 0) return (int) (stbi__err("output buffer limit"));
			cur = (int) ((z.zout - z.zout_start));
			limit = (int) (old_limit = (int) ((z.zout_end - z.zout_start)));
			limit *= 2;
			q = realloc(z.zout_start, limit);
			(old_limit);
			if (q == (null /*0*/)) return (int) (stbi__err("outofmem"));
			z.zout_start = q;
			z.zout = q + cur;
			z.zout_end = q + limit;
			return (int) (1);
		}

		private static int stbi__parse_huffman_block(stbi__zbuf a)
		{
			Pointer<sbyte> zout = a.zout;
			for (;;)
			{
				int z = (int) (stbi__zhuffman_decode(a, a.z_length));
				if (z < 256)
				{
					if (z < 0) return (int) (stbi__err("bad huffman code"));
					if (zout >= a.zout_end)
					{
						if (stbi__zexpand(a, zout, 1) == 0) return (int) (0);
						zout = a.zout;
					}
					zout.GetAndMove() = (sbyte) (z);
				}
				else
				{
					Pointer<byte> p;
					int len;
					int dist;
					if (z == 256)
					{
						a.zout = zout;
						return (int) (1);
					}
					z -= 257;
					len = (int) (stbi__zlength_base[z]);
					if ((stbi__zlength_extra[z]) != 0) len += stbi__zreceive(a, stbi__zlength_extra[z]);
					z = (int) (stbi__zhuffman_decode(a, a.z_distance));
					if (z < 0) return (int) (stbi__err("bad huffman code"));
					dist = (int) (stbi__zdist_base[z]);
					if ((stbi__zdist_extra[z]) != 0) dist += stbi__zreceive(a, stbi__zdist_extra[z]);
					if (zout - a.zout_start < dist) return (int) (stbi__err("bad dist"));
					if (zout + len > a.zout_end)
					{
						if (stbi__zexpand(a, zout, len) == 0) return (int) (0);
						zout = a.zout;
					}
					p = (zout - dist);
					if (dist == 1)
					{
						byte v = (byte) (p.CurrentValue);
						if ((len) != 0)
						{
							do
							{
								zout.GetAndMove() = (sbyte) (v)
							} while (--len);
						}
					}
					else
					{
						if ((len) != 0)
						{
							do
							{
								zout.GetAndMove() = (sbyte) (p.GetAndMove())
							} while (--len);
						}
					}
				}
			}

		}

		private static int stbi__compute_huffman_codes(stbi__zbuf a)
		{
			Pointer<byte> length_dezigzag =
				new Pointer<byte>(new byte[] {16, 17, 18, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 14, 1, 15});
			stbi__zhuffman z_codelength = new stbi__zhuffman();
			Pointer<byte> lencodes = 286 + 32 + 137;
			Pointer<byte> codelength_sizes = new Pointer<byte>(19);
			int i;
			int n;
			int hlit = (int) (stbi__zreceive(a, 5) + 257);
			int hdist = (int) (stbi__zreceive(a, 5) + 1);
			int hclen = (int) (stbi__zreceive(a, 4) + 4);
			memset(codelength_sizes, 0, (codelength_sizes).Size);
			for (i = (int) (0); i < hclen; ++i)
			{
				int s = (int) (stbi__zreceive(a, 3));
				codelength_sizes[length_dezigzag[i]] = (byte) (s);
			}

			if (stbi__zbuild_huffman(z_codelength, codelength_sizes, 19) == 0) return (int) (0);
			n = (int) (0);
			{
				int c = (int) (stbi__zhuffman_decode(a, z_codelength));
				if (c < 0 || c >= 19) return (int) (stbi__err("bad codelengths"));
				if (c < 16) lencodes[n++] = (byte) (c)
				else if (c == 16)
				{
					c = (int) (stbi__zreceive(a, 2) + 3);
					memset(lencodes + n, lencodes[n - 1], c);
					n += c;
				}
				else if (c == 17)
				{
					c = (int) (stbi__zreceive(a, 3) + 3);
					memset(lencodes + n, 0, c);
					n += c;
				}
				else
				{
					;
					c = (int) (stbi__zreceive(a, 7) + 11);
					memset(lencodes + n, 0, c);
					n += c;
				}
			}

			if (n != hlit + hdist) return (int) (stbi__err("bad codelengths"));
			if (stbi__zbuild_huffman(a.z_length, lencodes, hlit) == 0) return (int) (0);
			if (stbi__zbuild_huffman(a.z_distance, lencodes + hlit, hdist) == 0) return (int) (0);
			return (int) (1);
		}

		private static int stbi__parse_uncompressed_block(stbi__zbuf a)
		{
			Pointer<byte> header = new Pointer<byte>(4);
			int len;
			int nlen;
			int k;
			if (a.num_bits & 7) stbi__zreceive(a, a.num_bits & 7);
			k = (int) (0);
			{
				header[k++] = (byte) ((a.code_buffer & 255));
				a.code_buffer >>= 8;
				a.num_bits -= 8;
			}

			header[k++] = (byte) (stbi__zget8(a));
			len = (int) (header[1]*256 + header[0]);
			nlen = (int) (header[3]*256 + header[2]);
			if (nlen != (len ^ 65535)) return (int) (stbi__err("zlib corrupt"));
			if (a.zbuffer + len > a.zbuffer_end) return (int) (stbi__err("read past buffer"));
			if (a.zout + len > a.zout_end) if (stbi__zexpand(a, a.zout, len) == 0) return (int) (0);
			memcpy(a.zout, a.zbuffer, len);
			a.zbuffer += len;
			a.zout += len;
			return (int) (1);
		}

		private static int stbi__parse_zlib_header(stbi__zbuf a)
		{
			int cmf = (int) (stbi__zget8(a));
			int cm = (int) (cmf & 15);
			int flg = (int) (stbi__zget8(a));
			if ((cmf*256 + flg)%31 != 0) return (int) (stbi__err("bad zlib header"));
			if (flg & 32) return (int) (stbi__err("no preset dict"));
			if (cm != 8) return (int) (stbi__err("bad compression"));
			return (int) (1);
		}

		private static void stbi__init_zdefaults()
		{
			int i;
			for (i = (int) (0); i <= 143; ++i) stbi__zdefault_length[i] = (byte) (8);
			for (i <= 255;; ++i) stbi__zdefault_length[i] = (byte) (9);
			for (i <= 279;; ++i) stbi__zdefault_length[i] = (byte) (7);
			for (i <= 287;; ++i) stbi__zdefault_length[i] = (byte) (8);
			for (i = (int) (0); i <= 31; ++i) stbi__zdefault_distance[i] = (byte) (5);
		}

		private static int stbi__parse_zlib(stbi__zbuf a, int parse_header)
		{
			int final;
			int type;
			if ((parse_header) != 0) if (stbi__parse_zlib_header(a) == 0) return (int) (0);
			a.num_bits = (int) (0);
			a.code_buffer = (uint) (0);
			do
			{
				{
					final = (int) (stbi__zreceive(a, 1));
					type = (int) (stbi__zreceive(a, 2));
					if (type == 0)
					{
						if (stbi__parse_uncompressed_block(a) == 0) return (int) (0);
					}
					else if (type == 3)
					{
						return (int) (0);
					}
					else
					{
						if (type == 1)
						{
							if (stbi__zdefault_distance[31] == 0) stbi__init_zdefaults();
							if (stbi__zbuild_huffman(a.z_length, stbi__zdefault_length, 288) == 0) return (int) (0);
							if (stbi__zbuild_huffman(a.z_distance, stbi__zdefault_distance, 32) == 0) return (int) (0);
						}
						else
						{
							if (stbi__compute_huffman_codes(a) == 0) return (int) (0);
						}
						if (stbi__parse_huffman_block(a) == 0) return (int) (0);
					}
				}
			} while (!final);
			return (int) (1);
		}

		private static int stbi__do_zlib(stbi__zbuf a, Pointer<sbyte> obuf, int olen, int exp, int parse_header)
		{
			a.zout_start = obuf;
			a.zout = obuf;
			a.zout_end = obuf + olen;
			a.z_expandable = (int) (exp);
			return (int) (stbi__parse_zlib(a, parse_header));
		}

		private static Pointer<sbyte> stbi_zlib_decode_malloc_guesssize(Pointer<sbyte> buffer, int len, int initial_size,
			Pointer<int> outlen)
		{
			stbi__zbuf a = new stbi__zbuf();
			Pointer<sbyte> p = stbi__malloc(initial_size);
			if (p == (null /*0*/)) return (null /*0*/);
			a.zbuffer = buffer;
			a.zbuffer_end = buffer + len;
			if ((stbi__do_zlib(a, p, initial_size, 1, 1)) != 0)
			{
				if ((outlen) != null) outlen.CurrentValue = (int) ((a.zout - a.zout_start));
				return a.zout_start;
			}
			else
			{
				free(a.zout_start);
				return (null /*0*/);
			}

		}

		private static Pointer<sbyte> stbi_zlib_decode_malloc(Pointer<sbyte> buffer, int len, Pointer<int> outlen)
		{
			return stbi_zlib_decode_malloc_guesssize(buffer, len, 16384, outlen);
		}

		private static Pointer<sbyte> stbi_zlib_decode_malloc_guesssize_headerflag(Pointer<sbyte> buffer, int len,
			int initial_size, Pointer<int> outlen, int parse_header)
		{
			stbi__zbuf a = new stbi__zbuf();
			Pointer<sbyte> p = stbi__malloc(initial_size);
			if (p == (null /*0*/)) return (null /*0*/);
			a.zbuffer = buffer;
			a.zbuffer_end = buffer + len;
			if ((stbi__do_zlib(a, p, initial_size, 1, parse_header)) != 0)
			{
				if ((outlen) != null) outlen.CurrentValue = (int) ((a.zout - a.zout_start));
				return a.zout_start;
			}
			else
			{
				free(a.zout_start);
				return (null /*0*/);
			}

		}

		private static int stbi_zlib_decode_buffer(Pointer<sbyte> obuffer, int olen, Pointer<sbyte> ibuffer, int ilen)
		{
			stbi__zbuf a = new stbi__zbuf();
			a.zbuffer = ibuffer;
			a.zbuffer_end = ibuffer + ilen;
			if ((stbi__do_zlib(a, obuffer, olen, 0, 1)) != 0) return (int) ((a.zout - a.zout_start))
			else return (int) (-1);
		}

		private static Pointer<sbyte> stbi_zlib_decode_noheader_malloc(Pointer<sbyte> buffer, int len, Pointer<int> outlen)
		{
			stbi__zbuf a = new stbi__zbuf();
			Pointer<sbyte> p = stbi__malloc(16384);
			if (p == (null /*0*/)) return (null /*0*/);
			a.zbuffer = buffer;
			a.zbuffer_end = buffer + len;
			if ((stbi__do_zlib(a, p, 16384, 1, 0)) != 0)
			{
				if ((outlen) != null) outlen.CurrentValue = (int) ((a.zout - a.zout_start));
				return a.zout_start;
			}
			else
			{
				free(a.zout_start);
				return (null /*0*/);
			}

		}

		private static int stbi_zlib_decode_noheader_buffer(Pointer<sbyte> obuffer, int olen, Pointer<sbyte> ibuffer, int ilen)
		{
			stbi__zbuf a = new stbi__zbuf();
			a.zbuffer = ibuffer;
			a.zbuffer_end = ibuffer + ilen;
			if ((stbi__do_zlib(a, obuffer, olen, 0, 0)) != 0) return (int) ((a.zout - a.zout_start))
			else return (int) (-1);
		}

		private static stbi__pngchunk stbi__get_chunk_header(stbi__context s)
		{
			stbi__pngchunk c = new stbi__pngchunk();
			c.length = (uint) (stbi__get32be(s));
			c.type = (uint) (stbi__get32be(s));
			return (stbi__pngchunk) (c);
		}

		private static int stbi__check_png_header(stbi__context s)
		{
			Pointer<byte> png_sig = new Pointer<byte>(new byte[] {137, 80, 78, 71, 13, 10, 26, 10});
			int i;
			for (i = (int) (0); i < 8; ++i) if (stbi__get8(s) != png_sig[i]) return (int) (stbi__err("bad png sig"));
			return (int) (1);
		}

		private static int stbi__paeth(int a, int b, int c)
		{
			int p = (int) (a + b - c);
			int pa = (int) (abs(p - a));
			int pb = (int) (abs(p - b));
			int pc = (int) (abs(p - c));
			if (pa <= pb && pa <= pc) return (int) (a);
			if (pb <= pc) return (int) (b);
			return (int) (c);
		}

		private static int stbi__create_png_image_raw(stbi__png a, Pointer<byte> raw, uint raw_len, int out_n, uint x, uint y,
			int depth, int color)
		{
			int bytes = (int) ((depth == 16 > 0 ? 2 : 1));
			stbi__context s = a.s;
			uint i;
			uint j;
			uint stride = (uint) (x*out_n*bytes);
			uint img_len;
			uint img_width_bytes;
			int k;
			int img_n = (int) (s.img_n);
			int output_bytes = (int) (out_n*bytes);
			int filter_bytes = (int) (img_n*bytes);
			int width = (int) (x);
			a.out =
			stbi__malloc(x*y*output_bytes);
			if (a.out==
			0)
			return (int) (stbi__err("outofmem"));
			img_width_bytes = (uint) ((((img_n*x*depth) + 7) >> 3));
			img_len = (uint) ((img_width_bytes + 1)*y);
			if (s.img_x == x && s.img_y == y)
			{
				if (raw_len != img_len) return (int) (stbi__err("not enough pixels"));
			}
			else
			{
				if (raw_len < img_len) return (int) (stbi__err("not enough pixels"));
			}

			for (j = (uint) (0); j < y; ++j)
			{
				Pointer<byte> cur = a.out
				+stride*j;
				Pointer<byte> prior = cur - stride;
				int filter = (int) (raw.GetAndMove());
				if (filter > 4) return (int) (stbi__err("invalid filter"));
				if (depth < 8)
				{
					;
					cur += x*out_n - img_width_bytes;
					filter_bytes = (int) (1);
					width = (int) (img_width_bytes);
				}
				if (j == 0) filter = (int) (first_row_filter[filter]);
				for (k = (int) (0); k < filter_bytes; ++k)
				{
					switch (filter)
					{
						case STBI__F_none:
							cur[k] = (byte) (raw[k]);
							break;
						case STBI__F_sub:
							cur[k] = (byte) (raw[k]);
							break;
						case STBI__F_up:
							cur[k] = (byte) ((((raw[k] + prior[k]) & 255)));
							break;
						case STBI__F_avg:
							cur[k] = (byte) ((((raw[k] + (prior[k] >> 1)) & 255)));
							break;
						case STBI__F_paeth:
							cur[k] = (byte) ((((raw[k] + stbi__paeth(0, prior[k], 0)) & 255)));
							break;
						case STBI__F_avg_first:
							cur[k] = (byte) (raw[k]);
							break;
						case STBI__F_paeth_first:
							cur[k] = (byte) (raw[k]);
							break;
					}
				}
				if (depth == 8)
				{
					if (img_n != out_n) cur[img_n] = (byte) (255);
					raw += img_n;
					cur += out_n;
					prior += out_n;
				}
				else if (depth == 16)
				{
					if (img_n != out_n)
					{
						cur[filter_bytes] = (byte) (255);
						cur[filter_bytes + 1] = (byte) (255);
					}
					raw += filter_bytes;
					cur += output_bytes;
					prior += output_bytes;
				}
				else
				{
					raw += 1;
					cur += 1;
					prior += 1;
				}
				if (depth < 8 || img_n == out_n)
				{
					int nk = (int) ((width - 1)*filter_bytes);
					switch (filter)
					{
						case STBI__F_none:
							memcpy(cur, raw, nk);
							break;
						case STBI__F_sub:
							for (k = (int) (0); k < nk; ++k) cur[k] = (byte) ((((raw[k] + cur[k - filter_bytes]) & 255)));
							break;
						case STBI__F_up:
							for (k = (int) (0); k < nk; ++k) cur[k] = (byte) ((((raw[k] + prior[k]) & 255)));
							break;
						case STBI__F_avg:
							for (k = (int) (0); k < nk; ++k)
								cur[k] = (byte) ((((raw[k] + ((prior[k] + cur[k - filter_bytes]) >> 1)) & 255)));
							break;
						case STBI__F_paeth:
							for (k = (int) (0); k < nk; ++k)
								cur[k] = (byte) ((((raw[k] + stbi__paeth(cur[k - filter_bytes], prior[k], prior[k - filter_bytes])) & 255)));
							break;
						case STBI__F_avg_first:
							for (k = (int) (0); k < nk; ++k) cur[k] = (byte) ((((raw[k] + (cur[k - filter_bytes] >> 1)) & 255)));
							break;
						case STBI__F_paeth_first:
							for (k = (int) (0); k < nk; ++k) cur[k] = (byte) ((((raw[k] + stbi__paeth(cur[k - filter_bytes], 0, 0)) & 255)));
							break;
					}
					raw += nk;
				}
				else
				{
					;
					switch (filter)
					{
						case STBI__F_none:
							for (i = (uint) (x - 1);
								i >= 1;
								--i , cur[filter_bytes] = (byte) (255) , raw += filter_bytes , cur += output_bytes , prior += output_bytes)
								for (k = (int) (0); k < filter_bytes; ++k) cur[k] = (byte) (raw[k]);
							break;
						case STBI__F_sub:
							for (i = (uint) (x - 1);
								i >= 1;
								--i , cur[filter_bytes] = (byte) (255) , raw += filter_bytes , cur += output_bytes , prior += output_bytes)
								for (k = (int) (0); k < filter_bytes; ++k) cur[k] = (byte) ((((raw[k] + cur[k - output_bytes]) & 255)));
							break;
						case STBI__F_up:
							for (i = (uint) (x - 1);
								i >= 1;
								--i , cur[filter_bytes] = (byte) (255) , raw += filter_bytes , cur += output_bytes , prior += output_bytes)
								for (k = (int) (0); k < filter_bytes; ++k) cur[k] = (byte) ((((raw[k] + prior[k]) & 255)));
							break;
						case STBI__F_avg:
							for (i = (uint) (x - 1);
								i >= 1;
								--i , cur[filter_bytes] = (byte) (255) , raw += filter_bytes , cur += output_bytes , prior += output_bytes)
								for (k = (int) (0); k < filter_bytes; ++k)
									cur[k] = (byte) ((((raw[k] + ((prior[k] + cur[k - output_bytes]) >> 1)) & 255)));
							break;
						case STBI__F_paeth:
							for (i = (uint) (x - 1);
								i >= 1;
								--i , cur[filter_bytes] = (byte) (255) , raw += filter_bytes , cur += output_bytes , prior += output_bytes)
								for (k = (int) (0); k < filter_bytes; ++k)
									cur[k] = (byte) ((((raw[k] + stbi__paeth(cur[k - output_bytes], prior[k], prior[k - output_bytes])) & 255)));
							break;
						case STBI__F_avg_first:
							for (i = (uint) (x - 1);
								i >= 1;
								--i , cur[filter_bytes] = (byte) (255) , raw += filter_bytes , cur += output_bytes , prior += output_bytes)
								for (k = (int) (0); k < filter_bytes; ++k) cur[k] = (byte) ((((raw[k] + (cur[k - output_bytes] >> 1)) & 255)));
							break;
						case STBI__F_paeth_first:
							for (i = (uint) (x - 1);
								i >= 1;
								--i , cur[filter_bytes] = (byte) (255) , raw += filter_bytes , cur += output_bytes , prior += output_bytes)
								for (k = (int) (0); k < filter_bytes; ++k)
									cur[k] = (byte) ((((raw[k] + stbi__paeth(cur[k - output_bytes], 0, 0)) & 255)));
							break;
					}
					if (depth == 16)
					{
						cur = a.out
						+stride*j;
						for (i = (uint) (0); i < x; ++i , cur += output_bytes)
						{
							cur[filter_bytes + 1] = (byte) (255);
						}
					}
				}
			}

			if (depth < 8)
			{
				for (j = (uint) (0); j < y; ++j)
				{
					Pointer<byte> cur = a.out
					+stride*j;
					Pointer<byte> in =
					a.out
					+stride*j + x*out_n - img_width_bytes;
					byte scale = (byte) ((color == 0) > 0 ? stbi__depth_scale_table[depth] : 1);
					if (depth == 4)
					{
						for (k = (int) (x*img_n); k >= 2; k -= 2 , ++_in_)
						{
							cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 4)));
							cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue) & 15));
						}
						if (k > 0) cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 4)));
					}
					else if (depth == 2)
					{
						for (k = (int) (x*img_n); k >= 4; k -= 4 , ++_in_)
						{
							cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 6)));
							cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 4) & 3));
							cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 2) & 3));
							cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue) & 3));
						}
						if (k > 0) cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 6)));
						if (k > 1) cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 4) & 3));
						if (k > 2) cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 2) & 3));
					}
					else if (depth == 1)
					{
						for (k = (int) (x*img_n); k >= 8; k -= 8 , ++_in_)
						{
							cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 7)));
							cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 6) & 1));
							cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 5) & 1));
							cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 4) & 1));
							cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 3) & 1));
							cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 2) & 1));
							cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 1) & 1));
							cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue) & 1));
						}
						if (k > 0) cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 7)));
						if (k > 1) cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 6) & 1));
						if (k > 2) cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 5) & 1));
						if (k > 3) cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 4) & 1));
						if (k > 4) cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 3) & 1));
						if (k > 5) cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 2) & 1));
						if (k > 6) cur.GetAndMove() = (byte) (scale*((_in_.CurrentValue >> 1) & 1));
					}
					if (img_n != out_n)
					{
						int q;
						cur = a.out
						+stride*j;
						if (img_n == 1)
						{
							for (q = (int) (x - 1); q >= 0; --q)
							{
								cur[q*2 + 1] = (byte) (255);
								cur[q*2 + 0] = (byte) (cur[q]);
							}
						}
						else
						{
							;
							for (q = (int) (x - 1); q >= 0; --q)
							{
								cur[q*4 + 3] = (byte) (255);
								cur[q*4 + 2] = (byte) (cur[q*3 + 2]);
								cur[q*4 + 1] = (byte) (cur[q*3 + 1]);
								cur[q*4 + 0] = (byte) (cur[q*3 + 0]);
							}
						}
					}
				}
			}
			else if (depth == 16)
			{
				Pointer<byte> cur = a.out;
				Pointer<ushort> cur16 = cur;
				for (i = (uint) (0); i < x*y*out_n; ++i , cur16++ , cur += 2)
				{
					cur16.CurrentValue = (ushort) ((cur[0] << 8) | cur[1]);
				}
			}

			return (int) (1);
		}

		private static int stbi__create_png_image(stbi__png a, Pointer<byte> image_data, uint image_data_len, int out_n,
			int depth, int color, int interlaced)
		{
			Pointer<byte> final;
			int p;
			if (interlaced == 0)
				return (int) (stbi__create_png_image_raw(a, image_data, image_data_len, out_n, a.s.img_x, a.s.img_y, depth, color));
			final = stbi__malloc(a.s.img_x*a.s.img_y*out_n);
			for (p = (int) (0); p < 7; ++p)
			{
				Pointer<int> xorig = new Pointer<int>(new int[] {0, 4, 0, 2, 0, 1, 0});
				Pointer<int> yorig = new Pointer<int>(new int[] {0, 0, 4, 0, 2, 0, 1});
				Pointer<int> xspc = new Pointer<int>(new int[] {8, 8, 4, 4, 2, 2, 1});
				Pointer<int> yspc = new Pointer<int>(new int[] {8, 8, 8, 4, 4, 2, 2});
				int i;
				int j;
				int x;
				int y;
				x = (int) ((a.s.img_x - xorig[p] + xspc[p] - 1)/xspc[p]);
				y = (int) ((a.s.img_y - yorig[p] + yspc[p] - 1)/yspc[p]);
				if ((x) != 0 && (y) != 0)
				{
					uint img_len = (uint) (((((a.s.img_n*x*depth) + 7) >> 3) + 1)*y);
					if (stbi__create_png_image_raw(a, image_data, image_data_len, out_n, x, y, depth, color) == 0)
					{
						free(final);
						return (int) (0);
					}
					for (j = (int) (0); j < y; ++j)
					{
						for (i = (int) (0); i < x; ++i)
						{
							int out_y = (int) (j*yspc[p] + yorig[p]);
							int out_x = (int) (i*xspc[p] + xorig[p]);
							memcpy(final + out_y*a.s.img_x*out_n + out_x*out_n, a.out + (j*x + i)*out_n,
							out_n)
							;
						}
					}
					free(a.out);
					image_data += img_len;
					image_data_len -= img_len;
				}
			}

			a.out =
			final;
			return (int) (1);
		}

		private static int stbi__compute_transparency(stbi__png z, Pointer<byte> tc, int out_n)
		{
			stbi__context s = z.s;
			uint i;
			uint pixel_count = (uint) (s.img_x*s.img_y);
			Pointer<byte> p = z.out;
			if (out_n == 2)
			{
				for (i = (uint) (0); i < pixel_count; ++i)
				{
					p[1] = (byte) ((p[0] == tc[0] > 0 ? 0 : 255));
					p += 2;
				}
			}
			else
			{
				for (i = (uint) (0); i < pixel_count; ++i)
				{
					if (p[0] == tc[0] && p[1] == tc[1] && p[2] == tc[2]) p[3] = (byte) (0);
					p += 4;
				}
			}

			return (int) (1);
		}

		private static int stbi__compute_transparency16(stbi__png z, Pointer<ushort> tc, int out_n)
		{
			stbi__context s = z.s;
			uint i;
			uint pixel_count = (uint) (s.img_x*s.img_y);
			Pointer<ushort> p = z._out_;
			if (out_n == 2)
			{
				for (i = (uint) (0); i < pixel_count; ++i)
				{
					p[1] = (ushort) ((p[0] == tc[0] > 0 ? 0 : 65535));
					p += 2;
				}
			}
			else
			{
				for (i = (uint) (0); i < pixel_count; ++i)
				{
					if (p[0] == tc[0] && p[1] == tc[1] && p[2] == tc[2]) p[3] = (ushort) (0);
					p += 4;
				}
			}

			return (int) (1);
		}

		private static int stbi__expand_png_palette(stbi__png a, Pointer<byte> palette, int len, int pal_img_n)
		{
			uint i;
			uint pixel_count = (uint) (a.s.img_x*a.s.img_y);
			Pointer<byte> p;
			Pointer<byte> temp_out;
			Pointer<byte> orig = a.out;
			p = stbi__malloc(pixel_count*pal_img_n);
			if (p == (null /*0*/)) return (int) (stbi__err("outofmem"));
			temp_out = p;
			if (pal_img_n == 3)
			{
				for (i = (uint) (0); i < pixel_count; ++i)
				{
					int n = (int) (orig[i]*4);
					p[0] = (byte) (palette[n]);
					p[1] = (byte) (palette[n + 1]);
					p[2] = (byte) (palette[n + 2]);
					p += 3;
				}
			}
			else
			{
				for (i = (uint) (0); i < pixel_count; ++i)
				{
					int n = (int) (orig[i]*4);
					p[0] = (byte) (palette[n]);
					p[1] = (byte) (palette[n + 1]);
					p[2] = (byte) (palette[n + 2]);
					p[3] = (byte) (palette[n + 3]);
					p += 4;
				}
			}

			free(a.out);
			a.out =
			temp_out;
			(len);
			return (int) (1);
		}

		private static int stbi__reduce_png(stbi__png p)
		{
			int i;
			int img_len = (int) (p.s.img_x*p.s.img_y*p.s.img_out_n);
			Pointer<byte> reduced;
			Pointer<ushort> orig = p.out;
			if (p.depth != 16) return (int) (1);
			reduced = stbi__malloc(img_len);
			if (p == (null /*0*/)) return (int) (stbi__err("outofmem"));
			for (i = (int) (0); i < img_len; ++i) reduced[i] = (byte) (((orig[i] >> 8) & 255));
			p.out =
			reduced;
			free(orig);
			return (int) (1);
		}

		private static void stbi_set_unpremultiply_on_load(int flag_true_if_should_unpremultiply)
		{
			stbi__unpremultiply_on_load = (int) (flag_true_if_should_unpremultiply);
		}

		private static void stbi_convert_iphone_png_to_rgb(int flag_true_if_should_convert)
		{
			stbi__de_iphone_flag = (int) (flag_true_if_should_convert);
		}

		private static void stbi__de_iphone(stbi__png z)
		{
			stbi__context s = z.s;
			uint i;
			uint pixel_count = (uint) (s.img_x*s.img_y);
			Pointer<byte> p = z.out;
			if (s.img_out_n == 3)
			{
				for (i = (uint) (0); i < pixel_count; ++i)
				{
					byte t = (byte) (p[0]);
					p[0] = (byte) (p[2]);
					p[2] = (byte) (t);
					p += 3;
				}
			}
			else
			{
				;
				if ((stbi__unpremultiply_on_load) != 0)
				{
					for (i = (uint) (0); i < pixel_count; ++i)
					{
						byte a = (byte) (p[3]);
						byte t = (byte) (p[0]);
						if ((a) != 0)
						{
							p[0] = (byte) (p[2]*255/a);
							p[1] = (byte) (p[1]*255/a);
							p[2] = (byte) (t*255/a);
						}
						else
						{
							p[0] = (byte) (p[2]);
							p[2] = (byte) (t);
						}
						p += 4;
					}
				}
				else
				{
					for (i = (uint) (0); i < pixel_count; ++i)
					{
						byte t = (byte) (p[0]);
						p[0] = (byte) (p[2]);
						p[2] = (byte) (t);
						p += 4;
					}
				}
			}

		}

		private static int stbi__parse_png_file(stbi__png z, int scan, int req_comp)
		{
			Pointer<byte> palette = new Pointer<byte>(1024);
			byte pal_img_n = (byte) (0);
			byte has_trans = (byte) (0);
			Pointer<byte> tc = new Pointer<byte>(3);
			Pointer<ushort> tc16 = new Pointer<ushort>(3);
			uint ioff = (uint) (0);
			uint idata_limit = (uint) (0);
			uint i;
			uint pal_len = (uint) (0);
			int first = (int) (1);
			int k;
			int interlace = (int) (0);
			int color = (int) (0);
			int is_iphone = (int) (0);
			stbi__context s = z.s;
			z.expanded = (null /*0*/);
			z.idata = (null /*0*/);
			z.out =
			(null /*0*/);
			if (stbi__check_png_header(s) == 0) return (int) (0);
			if (scan == STBI__SCAN_type) return (int) (1);
			for (;;)
			{
				stbi__pngchunk c = (stbi__pngchunk) (stbi__get_chunk_header(s));
				switch (c.type)
				{
					case ((() << 24) + (() << 16 )
						+(() << 8)
						+()):
						is_iphone = (int) (1);
						stbi__skip(s, c.length);
						break;
					case ((() << 24) + (() << 16 )
						+(() << 8)
						+()):
					{
						int comp;
						int filter;
						if (first == 0) return (int) (stbi__err("multiple IHDR"));
						first = (int) (0);
						if (c.length != 13) return (int) (stbi__err("bad IHDR len"));
						s.img_x = (uint) (stbi__get32be(s));
						if (s.img_x > (1 << 24)) return (int) (stbi__err("too large"));
						s.img_y = (uint) (stbi__get32be(s));
						if (s.img_y > (1 << 24)) return (int) (stbi__err("too large"));
						z.depth = (int) (stbi__get8(s));
						if (z.depth != 1 && z.depth != 2 && z.depth != 4 && z.depth != 8 && z.depth != 16)
							return (int) (stbi__err("1/2/4/8/16-bit only"));
						color = (int) (stbi__get8(s));
						if (color > 6) return (int) (stbi__err("bad ctype"));
						if (color == 3 && z.depth == 16) return (int) (stbi__err("bad ctype"));
						if (color == 3) pal_img_n = (byte) (3)
						else if (color & 1) return (int) (stbi__err("bad ctype"));
						comp = (int) (stbi__get8(s));
						if ((comp) != 0) return (int) (stbi__err("bad comp method"));
						filter = (int) (stbi__get8(s));
						if ((filter) != 0) return (int) (stbi__err("bad filter method"));
						interlace = (int) (stbi__get8(s));
						if (interlace > 1) return (int) (stbi__err("bad interlace method"));
						if (s.img_x == 0 || s.img_y == 0) return (int) (stbi__err("0-pixel image"));
						if (pal_img_n == 0)
						{
							s.img_n = (int) ((color & 2 > 0 ? 3 : 1) + (color & 4 > 0 ? 1 : 0));
							if ((1 << 30)/s.img_x/s.img_n < s.img_y) return (int) (stbi__err("too large"));
							if (scan == STBI__SCAN_header) return (int) (1);
						}
						else
						{
							s.img_n = (int) (1);
							if ((1 << 30)/s.img_x/4 < s.img_y) return (int) (stbi__err("too large"));
						}
						break;
					}
					case ((() << 24) + (() << 16 )
						+(() << 8)
						+()):
					{
						if ((first) != 0) return (int) (stbi__err("first not IHDR"));
						if (c.length > 256*3) return (int) (stbi__err("invalid PLTE"));
						pal_len = (uint) (c.length/3);
						if (pal_len*3 != c.length) return (int) (stbi__err("invalid PLTE"));
						for (i = (uint) (0); i < pal_len; ++i)
						{
							palette[i*4 + 0] = (byte) (stbi__get8(s));
							palette[i*4 + 1] = (byte) (stbi__get8(s));
							palette[i*4 + 2] = (byte) (stbi__get8(s));
							palette[i*4 + 3] = (byte) (255);
						}
						break;
					}
					case ((() << 24) + (() << 16 )
						+(() << 8)
						+()):
					{
						if ((first) != 0) return (int) (stbi__err("first not IHDR"));
						if ((z.idata) != null) return (int) (stbi__err("tRNS after IDAT"));
						if ((pal_img_n) != 0)
						{
							if (scan == STBI__SCAN_header)
							{
								s.img_n = (int) (4);
								return (int) (1);
							}
							if (pal_len == 0) return (int) (stbi__err("tRNS before PLTE"));
							if (c.length > pal_len) return (int) (stbi__err("bad tRNS len"));
							pal_img_n = (byte) (4);
							for (i = (uint) (0); i < c.length; ++i) palette[i*4 + 3] = (byte) (stbi__get8(s));
						}
						else
						{
							if ((s.img_n & 1) == 0) return (int) (stbi__err("tRNS with alpha"));
							if (c.length != s.img_n*2) return (int) (stbi__err("bad tRNS len"));
							has_trans = (byte) (1);
							if (z.depth == 16)
							{
								for (k = (int) (0); k < s.img_n; ++k) tc16[k] = (ushort) (stbi__get16be(s));
							}
							else
							{
								for (k = (int) (0); k < s.img_n; ++k)
									tc[k] = (byte) ((stbi__get16be(s) & 255)*stbi__depth_scale_table[z.depth]);
							}
						}
						break;
					}
					case ((() << 24) + (() << 16 )
						+(() << 8)
						+()):
					{
						if ((first) != 0) return (int) (stbi__err("first not IHDR"));
						if ((pal_img_n) != 0 && pal_len == 0) return (int) (stbi__err("no PLTE"));
						if (scan == STBI__SCAN_header)
						{
							s.img_n = (int) (pal_img_n);
							return (int) (1);
						}
						if ((ioff + c.length) < ioff) return (int) (0);
						if (ioff + c.length > idata_limit)
						{
							uint idata_limit_old = (uint) (idata_limit);
							Pointer<byte> p;
							if (idata_limit == 0) idata_limit = (uint) (c.length > 4096 > 0 ? c.length : 4096);
							idata_limit *= 2;
							(idata_limit_old);
							p = realloc(z.idata, idata_limit);
							if (p == (null /*0*/)) return (int) (stbi__err("outofmem"));
							z.idata = p;
						}
						if (stbi__getn(s, z.idata + ioff, c.length) == 0) return (int) (stbi__err("outofdata"));
						ioff += c.length;
						break;
					}
					case ((() << 24) + (() << 16 )
						+(() << 8)
						+()):
					{
						uint raw_len;
						uint bpl;
						if ((first) != 0) return (int) (stbi__err("first not IHDR"));
						if (scan != STBI__SCAN_load) return (int) (1);
						if (z.idata == (null /*0*/)) return (int) (stbi__err("no IDAT"));
						bpl = (uint) ((s.img_x*z.depth + 7)/8);
						raw_len = (uint) (bpl*s.img_y*s.img_n + s.img_y);
						z.expanded = stbi_zlib_decode_malloc_guesssize_headerflag(z.idata, ioff, raw_len, raw_len, !is_iphone);
						if (z.expanded == (null /*0*/)) return (int) (0);
						free(z.idata);
						z.idata = (null /*0*/);
						if (((req_comp == s.img_n + 1 && req_comp != 3 && pal_img_n == 0)) != 0 || (has_trans) != 0)
							s.img_out_n = (int) (s.img_n + 1)
						else s.img_out_n = (int) (s.img_n);
						if (stbi__create_png_image(z, z.expanded, raw_len, s.img_out_n, z.depth, color, interlace) == 0) return (int) (0);
						if ((has_trans) != 0)
						{
							if (z.depth == 16)
							{
								if (stbi__compute_transparency16(z, tc16, s.img_out_n) == 0) return (int) (0);
							}
							else
							{
								if (stbi__compute_transparency(z, tc, s.img_out_n) == 0) return (int) (0);
							}
						}
						if ((is_iphone) != 0 && (stbi__de_iphone_flag) != 0 && s.img_out_n > 2) stbi__de_iphone(z);
						if ((pal_img_n) != 0)
						{
							s.img_n = (int) (pal_img_n);
							s.img_out_n = (int) (pal_img_n);
							if (req_comp >= 3) s.img_out_n = (int) (req_comp);
							if (stbi__expand_png_palette(z, palette, pal_len, s.img_out_n) == 0) return (int) (0);
						}
						free(z.expanded);
						z.expanded = (null /*0*/);
						return (int) (1);
					}
						if ((first) != 0) return (int) (stbi__err("first not IHDR"));
						if ((c.type & (1 << 29)) == 0)
						{
							Pointer<sbyte> invalid_chunk = "XXXX PNG chunk not known";
							invalid_chunk[0] = (sbyte) ((((c.type >> 24) & 255)));
							invalid_chunk[1] = (sbyte) ((((c.type >> 16) & 255)));
							invalid_chunk[2] = (sbyte) ((((c.type >> 8) & 255)));
							invalid_chunk[3] = (sbyte) ((((c.type >> 0) & 255)));
							return (int) (stbi__err(invalid_chunk));
						}
						stbi__skip(s, c.length);
						break;
				}
				stbi__get32be(s);
			}

		}

		private static Pointer<byte> stbi__do_png(stbi__png p, Pointer<int> x, Pointer<int> y, Pointer<int> n, int req_comp)
		{
			Pointer<byte> result = (null /*0*/);
			if (req_comp < 0 || req_comp > 4) return (null /*(stbi__err("bad req_comp") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
			if ((stbi__parse_png_file(p, STBI__SCAN_load, req_comp)) != 0)
			{
				if (p.depth == 16)
				{
					if (stbi__reduce_png(p) == 0)
					{
						return result;
					}
				}
				result = p.out;
				p.out =
				(null /*0*/);
				if ((req_comp) != 0 && req_comp != p.s.img_out_n)
				{
					result = stbi__convert_format(result, p.s.img_out_n, req_comp, p.s.img_x, p.s.img_y);
					p.s.img_out_n = (int) (req_comp);
					if (result == (null /*0*/)) return result;
				}
				x.CurrentValue = (int) (p.s.img_x);
				y.CurrentValue = (int) (p.s.img_y);
				if ((n) != null) n.CurrentValue = (int) (p.s.img_n);
			}

			free(p.out);
			p.out =
			(null /*0*/);
			free(p.expanded);
			p.expanded = (null /*0*/);
			free(p.idata);
			p.idata = (null /*0*/);
			return result;
		}

		private static Pointer<byte> stbi__png_load(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp,
			int req_comp)
		{
			stbi__png p = new stbi__png();
			p.s = s;
			return stbi__do_png(p, x, y, comp, req_comp);
		}

		private static int stbi__png_test(stbi__context s)
		{
			int r;
			r = (int) (stbi__check_png_header(s));
			stbi__rewind(s);
			return (int) (r);
		}

		private static int stbi__png_info_raw(stbi__png p, Pointer<int> x, Pointer<int> y, Pointer<int> comp)
		{
			if (stbi__parse_png_file(p, STBI__SCAN_header, 0) == 0)
			{
				stbi__rewind(p.s);
				return (int) (0);
			}

			if ((x) != null) x.CurrentValue = (int) (p.s.img_x);
			if ((y) != null) y.CurrentValue = (int) (p.s.img_y);
			if ((comp) != null) comp.CurrentValue = (int) (p.s.img_n);
			return (int) (1);
		}

		private static int stbi__png_info(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp)
		{
			stbi__png p = new stbi__png();
			p.s = s;
			return (int) (stbi__png_info_raw(p, x, y, comp));
		}

		private static int stbi__bmp_test_raw(stbi__context s)
		{
			int r;
			int sz;
			if (stbi__get8(s) !=) return (int) (0);
			if (stbi__get8(s) !=) return (int) (0);
			stbi__get32le(s);
			stbi__get16le(s);
			stbi__get16le(s);
			stbi__get32le(s);
			sz = (int) (stbi__get32le(s));
			r = (int) ((sz == 12 || sz == 40 || sz == 56 || sz == 108 || sz == 124));
			return (int) (r);
		}

		private static int stbi__bmp_test(stbi__context s)
		{
			int r = (int) (stbi__bmp_test_raw(s));
			stbi__rewind(s);
			return (int) (r);
		}

		private static int stbi__high_bit(uint z)
		{
			int n = (int) (0);
			if (z == 0) return (int) (-1);
			if (z >= 65536) n += 16 ,
			z >>= 16;
			if (z >= 256) n += 8 ,
			z >>= 8;
			if (z >= 16) n += 4 ,
			z >>= 4;
			if (z >= 4) n += 2 ,
			z >>= 2;
			if (z >= 2) n += 1 ,
			z >>= 1;
			return (int) (n);
		}

		private static int stbi__bitcount(uint a)
		{
			a = (uint) ((a & 1431655765) + ((a >> 1) & 1431655765));
			a = (uint) ((a & 858993459) + ((a >> 2) & 858993459));
			a = (uint) ((a + (a >> 4)) & 252645135 ? 1 : 0);
			a = (uint) ((a + (a >> 8)));
			a = (uint) ((a + (a >> 16)));
			return (int) (a & 255);
		}

		private static int stbi__shiftsigned(int v, int shift, int bits)
		{
			int result;
			int z = (int) (0);
			if (shift < 0) v <<= -shift
			else v >>= shift;
			result = (int) (v);
			z = (int) (bits);
			{
				result += v >> z;
				z += bits;
			}

			return (int) (result);
		}

		private static object stbi__bmp_parse_header(stbi__context s, stbi__bmp_data info)
		{
			int hsz;
			if (stbi__get8(s) != || stbi__get8(s) !=) return (object) ((null /*(stbi__err("not BMP") > 0?(null /*0*/):
			(null /*0*/))
			*/))
			;
			stbi__get32le(s);
			stbi__get16le(s);
			stbi__get16le(s);
			info.offset = (int) (stbi__get32le(s));
			info.hsz = (int) (hsz = (int) (stbi__get32le(s)));
			info.mr = (uint) (info.mg = (uint) (info.mb = (uint) (info.ma = (uint) (0))));
			if (hsz != 12 && hsz != 40 && hsz != 56 && hsz != 108 && hsz != 124)
				return (object) ((null /*(stbi__err("unknown BMP") > 0?(null /*0*/):
			(null /*0*/))
			*/))
			;
			if (hsz == 12)
			{
				s.img_x = (uint) (stbi__get16le(s));
				s.img_y = (uint) (stbi__get16le(s));
			}
			else
			{
				s.img_x = (uint) (stbi__get32le(s));
				s.img_y = (uint) (stbi__get32le(s));
			}

			if (stbi__get16le(s) != 1) return (object) ((null /*(stbi__err("bad BMP") > 0?(null /*0*/):
			(null /*0*/))
			*/))
			;
			info.bpp = (int) (stbi__get16le(s));
			if (info.bpp == 1) return (object) ((null /*(stbi__err("monochrome") > 0?(null /*0*/):
			(null /*0*/))
			*/))
			;
			if (hsz != 12)
			{
				int compress = (int) (stbi__get32le(s));
				if (compress == 1 || compress == 2) return (object) ((null /*(stbi__err("BMP RLE") > 0?(null /*0*/):
				(null /*0*/))
				*/))
				;
				stbi__get32le(s);
				stbi__get32le(s);
				stbi__get32le(s);
				stbi__get32le(s);
				stbi__get32le(s);
				if (hsz == 40 || hsz == 56)
				{
					if (hsz == 56)
					{
						stbi__get32le(s);
						stbi__get32le(s);
						stbi__get32le(s);
						stbi__get32le(s);
					}
					if (info.bpp == 16 || info.bpp == 32)
					{
						if (compress == 0)
						{
							if (info.bpp == 32)
							{
								info.mr = (uint) (255 << 16);
								info.mg = (uint) (255 << 8);
								info.mb = (uint) (255 << 0);
								info.ma = (uint) (255 << 24);
								info.all_a = (uint) (0);
							}
							else
							{
								info.mr = (uint) (31 << 10);
								info.mg = (uint) (31 << 5);
								info.mb = (uint) (31 << 0);
							}
						}
						else if (compress == 3)
						{
							info.mr = (uint) (stbi__get32le(s));
							info.mg = (uint) (stbi__get32le(s));
							info.mb = (uint) (stbi__get32le(s));
							if (info.mr == info.mg && info.mg == info.mb)
							{
								return (object) ((null /*(stbi__err("bad BMP") > 0?(null /*0*/):
								(null /*0*/))
								*/))
								;
							}
						}
						else return (object) ((null /*(stbi__err("bad BMP") > 0?(null /*0*/):
						(null /*0*/))
						*/))
						;
					}
				}
				else
				{
					int i;
					if (hsz != 108 && hsz != 124) return (object) ((null /*(stbi__err("bad BMP") > 0?(null /*0*/):
					(null /*0*/))
					*/))
					;
					info.mr = (uint) (stbi__get32le(s));
					info.mg = (uint) (stbi__get32le(s));
					info.mb = (uint) (stbi__get32le(s));
					info.ma = (uint) (stbi__get32le(s));
					stbi__get32le(s);
					for (i = (int) (0); i < 12; ++i) stbi__get32le(s);
					if (hsz == 124)
					{
						stbi__get32le(s);
						stbi__get32le(s);
						stbi__get32le(s);
						stbi__get32le(s);
					}
				}
			}

			return (object) (null /*1*/);
		}

		private static Pointer<byte> stbi__bmp_load(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp,
			int req_comp)
		{
			Pointer<byte> out;
			uint mr = (uint) (0);
			uint mg = (uint) (0);
			uint mb = (uint) (0);
			uint ma = (uint) (0);
			uint all_a;
			Pointer<Pointer<byte>> pal = new Pointer<Pointer<byte>>(256);
			int psize = (int) (0);
			int i;
			int j;
			int width;
			int flip_vertically;
			int pad;
			int target;
			stbi__bmp_data info = new stbi__bmp_data();
			info.all_a = (uint) (255);
			if (stbi__bmp_parse_header(s, info) == (null /*0*/)) return (null /*0*/);
			flip_vertically = (int) ((s.img_y) > 0 ? 1 : 0);
			s.img_y = (uint) (abs(s.img_y));
			mr = (uint) (info.mr);
			mg = (uint) (info.mg);
			mb = (uint) (info.mb);
			ma = (uint) (info.ma);
			all_a = (uint) (info.all_a);
			if (info.hsz == 12)
			{
				if (info.bpp < 24) psize = (int) ((info.offset - 14 - 24)/3);
			}
			else
			{
				if (info.bpp < 16) psize = (int) ((info.offset - 14 - info.hsz) >> 2);
			}

			s.img_n = (int) (ma > 0 ? 4 : 3);
			if ((req_comp) != 0 && req_comp >= 3) target = (int) (req_comp)
			else target = (int) (s.img_n);
			_out_ = stbi__malloc(target*s.img_x*s.img_y);
			if (_out_ == 0) return (null /*(stbi__err("outofmem") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
			if (info.bpp < 16)
			{
				int z = (int) (0);
				if (psize == 0 || psize > 256)
				{
					free(_out_);
					return (null /*(stbi__err("invalid") > 0?(null /*0*/):
					(null /*0*/))
					*/)
					;
				}
				for (i = (int) (0); i < psize; ++i)
				{
					pal[i][2] = (byte) (stbi__get8(s));
					pal[i][1] = (byte) (stbi__get8(s));
					pal[i][0] = (byte) (stbi__get8(s));
					if (info.hsz != 12) stbi__get8(s);
					pal[i][3] = (byte) (255);
				}
				stbi__skip(s, info.offset - 14 - info.hsz - psize*(info.hsz == 12 > 0 ? 3 : 4));
				if (info.bpp == 4) width = (int) ((s.img_x + 1) >> 1)
				else if (info.bpp == 8) width = (int) (s.img_x)
				else
				{
					free(_out_);
					return (null /*(stbi__err("bad bpp") > 0?(null /*0*/):
					(null /*0*/))
					*/)
					;
				}
				pad = (int) ((-width) & 3 ? 1 : 0);
				for (j = (int) (0); j < s.img_y; ++j)
				{
					for (i = (int) (0); i < s.img_x; i += 2)
					{
						int v = (int) (stbi__get8(s));
						int v2 = (int) (0);
						if (info.bpp == 4)
						{
							v2 = (int) (v & 15 ? 1 : 0);
							v >>= 4;
						}
						_out_[z++] = (byte) (pal[v][0]);
						_out_[z++] = (byte) (pal[v][1]);
						_out_[z++] = (byte) (pal[v][2]);
						if (target == 4) _out_[z++] = (byte) (255);
						if (i + 1 == s.img_x) break;
						v = (int) ((info.bpp == 8) > 0 ? stbi__get8(s) : v2);
						_out_[z++] = (byte) (pal[v][0]);
						_out_[z++] = (byte) (pal[v][1]);
						_out_[z++] = (byte) (pal[v][2]);
						if (target == 4) _out_[z++] = (byte) (255);
					}
					stbi__skip(s, pad);
				}
			}
			else
			{
				int rshift = (int) (0);
				int gshift = (int) (0);
				int bshift = (int) (0);
				int ashift = (int) (0);
				int rcount = (int) (0);
				int gcount = (int) (0);
				int bcount = (int) (0);
				int acount = (int) (0);
				int z = (int) (0);
				int easy = (int) (0);
				stbi__skip(s, info.offset - 14 - info.hsz);
				if (info.bpp == 24) width = (int) (3*s.img_x)
				else if (info.bpp == 16) width = (int) (2*s.img_x)
				else width = (int) (0);
				pad = (int) ((-width) & 3 ? 1 : 0);
				if (info.bpp == 24)
				{
					easy = (int) (1);
				}
				else if (info.bpp == 32)
				{
					if (mb == 255 && mg == 65280 && mr == 16711680 && ma == -16777216) easy = (int) (2);
				}
				if (easy == 0)
				{
					if (mr == 0 || mg == 0 || mb == 0)
					{
						free(_out_);
						return (null /*(stbi__err("bad masks") > 0?(null /*0*/):
						(null /*0*/))
						*/)
						;
					}
					rshift = (int) (stbi__high_bit(mr) - 7);
					rcount = (int) (stbi__bitcount(mr));
					gshift = (int) (stbi__high_bit(mg) - 7);
					gcount = (int) (stbi__bitcount(mg));
					bshift = (int) (stbi__high_bit(mb) - 7);
					bcount = (int) (stbi__bitcount(mb));
					ashift = (int) (stbi__high_bit(ma) - 7);
					acount = (int) (stbi__bitcount(ma));
				}
				for (j = (int) (0); j < s.img_y; ++j)
				{
					if ((easy) != 0)
					{
						for (i = (int) (0); i < s.img_x; ++i)
						{
							byte a;
							_out_[z + 2] = (byte) (stbi__get8(s));
							_out_[z + 1] = (byte) (stbi__get8(s));
							_out_[z + 0] = (byte) (stbi__get8(s));
							z += 3;
							a = (byte) ((easy == 2 > 0 ? stbi__get8(s) : 255));
							all_a |= a;
							if (target == 4) _out_[z++] = (byte) (a);
						}
					}
					else
					{
						int bpp = (int) (info.bpp);
						for (i = (int) (0); i < s.img_x; ++i)
						{
							uint v = (uint) ((bpp == 16 > 0 ? stbi__get16le(s) : stbi__get32le(s)));
							int a;
							_out_[z++] = (byte) ((((stbi__shiftsigned(v & mr, rshift, rcount)) & 255)));
							_out_[z++] = (byte) ((((stbi__shiftsigned(v & mg, gshift, gcount)) & 255)));
							_out_[z++] = (byte) ((((stbi__shiftsigned(v & mb, bshift, bcount)) & 255)));
							a = (int) ((ma > 0 ? stbi__shiftsigned(v & ma, ashift, acount) : 255));
							all_a |= a;
							if (target == 4) _out_[z++] = (byte) ((((a) & 255)));
						}
					}
					stbi__skip(s, pad);
				}
			}

			if (target == 4 && all_a == 0) for (i = (int) (4*s.img_x*s.img_y - 1); i >= 0; i -= 4) _out_[i] = (byte) (255);
			if ((flip_vertically) != 0)
			{
				byte t;
				for (j = (int) (0); j < s.img_y >> 1; ++j)
				{
					Pointer<byte> p1 = _out_ + j*s.img_x*target;
					Pointer<byte> p2 = _out_ + (s.img_y - 1 - j)*s.img_x*target;
					for (i = (int) (0); i < s.img_x*target; ++i)
					{
						t = (byte) (p1[i]) ,
						p1[i] = (byte) (p2[i]) ,
						p2[i] = (byte) (t);
					}
				}
			}

			if ((req_comp) != 0 && req_comp != target)
			{
				_out_ = stbi__convert_format(_out_, target, req_comp, s.img_x, s.img_y);
				if (_out_ == (null /*0*/)) return _out_;
			}

			x.CurrentValue = (int) (s.img_x);
			y.CurrentValue = (int) (s.img_y);
			if ((comp) != null) comp.CurrentValue = (int) (s.img_n);
			return _out_;
		}

		private static int stbi__tga_get_comp(int bits_per_pixel, int is_grey, Pointer<int> is_rgb16)
		{
			if ((is_rgb16) != null) is_rgb16.CurrentValue = (int) (0);
			switch (bits_per_pixel)
			{
				case 8:
					return (int) (STBI_grey);
				case 16:
					if ((is_grey) != 0) return (int) (STBI_grey_alpha);
				case 15:
					if ((is_rgb16) != null) is_rgb16.CurrentValue = (int) (1);
					return (int) (STBI_rgb);
				case 24:
				case 32:
					return (int) (bits_per_pixel/8);
					return (int) (0);
			}

		}

		private static int stbi__tga_info(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp)
		{
			int tga_w;
			int tga_h;
			int tga_comp;
			int tga_image_type;
			int tga_bits_per_pixel;
			int tga_colormap_bpp;
			int sz;
			int tga_colormap_type;
			stbi__get8(s);
			tga_colormap_type = (int) (stbi__get8(s));
			if (tga_colormap_type > 1)
			{
				stbi__rewind(s);
				return (int) (0);
			}

			tga_image_type = (int) (stbi__get8(s));
			if (tga_colormap_type == 1)
			{
				if (tga_image_type != 1 && tga_image_type != 9)
				{
					stbi__rewind(s);
					return (int) (0);
				}
				stbi__skip(s, 4);
				sz = (int) (stbi__get8(s));
				if (((sz != 8)) != 0 && ((sz != 15)) != 0 && ((sz != 16)) != 0 && ((sz != 24)) != 0 && ((sz != 32)) != 0)
				{
					stbi__rewind(s);
					return (int) (0);
				}
				stbi__skip(s, 4);
				tga_colormap_bpp = (int) (sz);
			}
			else
			{
				if (((tga_image_type != 2)) != 0 && ((tga_image_type != 3)) != 0 && ((tga_image_type != 10)) != 0 &&
				    ((tga_image_type != 11)) != 0)
				{
					stbi__rewind(s);
					return (int) (0);
				}
				stbi__skip(s, 9);
				tga_colormap_bpp = (int) (0);
			}

			tga_w = (int) (stbi__get16le(s));
			if (tga_w < 1)
			{
				stbi__rewind(s);
				return (int) (0);
			}

			tga_h = (int) (stbi__get16le(s));
			if (tga_h < 1)
			{
				stbi__rewind(s);
				return (int) (0);
			}

			tga_bits_per_pixel = (int) (stbi__get8(s));
			stbi__get8(s);
			if (tga_colormap_bpp != 0)
			{
				if (((tga_bits_per_pixel != 8)) != 0 && ((tga_bits_per_pixel != 16)) != 0)
				{
					stbi__rewind(s);
					return (int) (0);
				}
				tga_comp = (int) (stbi__tga_get_comp(tga_colormap_bpp, 0, (null /*0*/)));
			}
			else
			{
				tga_comp =
					(int)
						(stbi__tga_get_comp(tga_bits_per_pixel, ((tga_image_type == 3)) != 0 || ((tga_image_type == 11)) != 0,
							(null /*0*/)));
			}

			if (tga_comp == 0)
			{
				stbi__rewind(s);
				return (int) (0);
			}

			if ((x) != null) x.CurrentValue = (int) (tga_w);
			if ((y) != null) y.CurrentValue = (int) (tga_h);
			if ((comp) != null) comp.CurrentValue = (int) (tga_comp);
			return (int) (1);
		}

		private static int stbi__tga_test(stbi__context s)
		{
			int res = (int) (0);
			int sz;
			int tga_color_type;
			stbi__get8(s);
			tga_color_type = (int) (stbi__get8(s));
			if (tga_color_type > 1) goto errorEnd;
			sz = (int) (stbi__get8(s));
			if (tga_color_type == 1)
			{
				if (sz != 1 && sz != 9) goto errorEnd;
				stbi__skip(s, 4);
				sz = (int) (stbi__get8(s));
				if (((sz != 8)) != 0 && ((sz != 15)) != 0 && ((sz != 16)) != 0 && ((sz != 24)) != 0 && ((sz != 32)) != 0)
					goto errorEnd;
				stbi__skip(s, 4);
			}
			else
			{
				if (((sz != 2)) != 0 && ((sz != 3)) != 0 && ((sz != 10)) != 0 && ((sz != 11)) != 0) goto errorEnd;
				stbi__skip(s, 9);
			}

			if (stbi__get16le(s) < 1) goto errorEnd;
			if (stbi__get16le(s) < 1) goto errorEnd;
			sz = (int) (stbi__get8(s));
			if (((tga_color_type == 1)) != 0 && ((sz != 8)) != 0 && ((sz != 16)) != 0) goto errorEnd;
			if (((sz != 8)) != 0 && ((sz != 15)) != 0 && ((sz != 16)) != 0 && ((sz != 24)) != 0 && ((sz != 32)) != 0)
				goto errorEnd;
			res = (int) (1);
			errorEnd:
			;
			stbi__rewind(s);
			return (int) (res);
		}

		private static void stbi__tga_read_rgb16(stbi__context s, Pointer<byte> _out_)
		{
			ushort px = (ushort) (stbi__get16le(s));
			ushort fiveBitMask = (ushort) (31);
			int r = (int) ((px >> 10) & fiveBitMask);
			int g = (int) ((px >> 5) & fiveBitMask);
			int b = (int) (px & fiveBitMask);
			_out_[0] = (byte) ((r*255)/31);
			_out_[1] = (byte) ((g*255)/31);
			_out_[2] = (byte) ((b*255)/31);
		}

		private static Pointer<byte> stbi__tga_load(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp,
			int req_comp)
		{
			int tga_offset = (int) (stbi__get8(s));
			int tga_indexed = (int) (stbi__get8(s));
			int tga_image_type = (int) (stbi__get8(s));
			int tga_is_RLE = (int) (0);
			int tga_palette_start = (int) (stbi__get16le(s));
			int tga_palette_len = (int) (stbi__get16le(s));
			int tga_palette_bits = (int) (stbi__get8(s));
			int tga_x_origin = (int) (stbi__get16le(s));
			int tga_y_origin = (int) (stbi__get16le(s));
			int tga_width = (int) (stbi__get16le(s));
			int tga_height = (int) (stbi__get16le(s));
			int tga_bits_per_pixel = (int) (stbi__get8(s));
			int tga_comp;
			int tga_rgb16 = (int) (0);
			int tga_inverted = (int) (stbi__get8(s));
			Pointer<byte> tga_data;
			Pointer<byte> tga_palette = (null /*0*/);
			int i;
			int j;
			Pointer<byte> raw_data = new Pointer<byte>(4);
			int RLE_count = (int) (0);
			int RLE_repeating = (int) (0);
			int read_next_pixel = (int) (1);
			if (tga_image_type >= 8)
			{
				tga_image_type -= 8;
				tga_is_RLE = (int) (1);
			}

			tga_inverted = (int) (1 - ((tga_inverted >> 5) & 1));
			if ((tga_indexed) != 0) tga_comp = (int) (stbi__tga_get_comp(tga_palette_bits, 0, tga_rgb16))
			else tga_comp = (int) (stbi__tga_get_comp(tga_bits_per_pixel, (tga_image_type == 3), tga_rgb16));
			if (tga_comp == 0) return (null /*(stbi__err("bad format") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
			x.CurrentValue = (int) (tga_width);
			y.CurrentValue = (int) (tga_height);
			if ((comp) != null) comp.CurrentValue = (int) (tga_comp);
			tga_data = stbi__malloc(tga_width*tga_height*tga_comp);
			if (tga_data == 0) return (null /*(stbi__err("outofmem") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
			stbi__skip(s, tga_offset);
			if (tga_indexed == 0 && tga_is_RLE == 0 && tga_rgb16 == 0)
			{
				for (i = (int) (0); i < tga_height; ++i)
				{
					int row = (int) (tga_inverted > 0 ? tga_height - i - 1 : i);
					Pointer<byte> tga_row = tga_data + row*tga_width*tga_comp;
					stbi__getn(s, tga_row, tga_width*tga_comp);
				}
			}
			else
			{
				if ((tga_indexed) != 0)
				{
					stbi__skip(s, tga_palette_start);
					tga_palette = stbi__malloc(tga_palette_len*tga_comp);
					if (tga_palette == 0)
					{
						free(tga_data);
						return (null /*(stbi__err("outofmem") > 0?(null /*0*/):
						(null /*0*/))
						*/)
						;
					}
					if ((tga_rgb16) != 0)
					{
						Pointer<byte> pal_entry = tga_palette;
						;
						for (i = (int) (0); i < tga_palette_len; ++i)
						{
							stbi__tga_read_rgb16(s, pal_entry);
							pal_entry += tga_comp;
						}
					}
					else if (stbi__getn(s, tga_palette, tga_palette_len*tga_comp) == 0)
					{
						free(tga_data);
						free(tga_palette);
						return (null /*(stbi__err("bad palette") > 0?(null /*0*/):
						(null /*0*/))
						*/)
						;
					}
				}
				for (i = (int) (0); i < tga_width*tga_height; ++i)
				{
					if ((tga_is_RLE) != 0)
					{
						if (RLE_count == 0)
						{
							int RLE_cmd = (int) (stbi__get8(s));
							RLE_count = (int) (1 + (RLE_cmd & 127));
							RLE_repeating = (int) (RLE_cmd >> 7);
							read_next_pixel = (int) (1);
						}
						else if (RLE_repeating == 0)
						{
							read_next_pixel = (int) (1);
						}
					}
					else
					{
						read_next_pixel = (int) (1);
					}
					if ((read_next_pixel) != 0)
					{
						if ((tga_indexed) != 0)
						{
							int pal_idx = (int) ((tga_bits_per_pixel == 8) > 0 ? stbi__get8(s) : stbi__get16le(s));
							if (pal_idx >= tga_palette_len)
							{
								pal_idx = (int) (0);
							}
							pal_idx *= tga_comp;
							for (j = (int) (0); j < tga_comp; ++j)
							{
								raw_data[j] = (byte) (tga_palette[pal_idx + j]);
							}
						}
						else if ((tga_rgb16) != 0)
						{
							;
							stbi__tga_read_rgb16(s, raw_data);
						}
						else
						{
							for (j = (int) (0); j < tga_comp; ++j)
							{
								raw_data[j] = (byte) (stbi__get8(s));
							}
						}
						read_next_pixel = (int) (0);
					}
					for (j = (int) (0); j < tga_comp; ++j) tga_data[i*tga_comp + j] = (byte) (raw_data[j]);
					--RLE_count;
				}
				if ((tga_inverted) != 0)
				{
					for (j = (int) (0); j*2 < tga_height; ++j)
					{
						int index1 = (int) (j*tga_width*tga_comp);
						int index2 = (int) ((tga_height - 1 - j)*tga_width*tga_comp);
						for (i = (int) (tga_width*tga_comp); i > 0; --i)
						{
							byte temp = (byte) (tga_data[index1]);
							tga_data[index1] = (byte) (tga_data[index2]);
							tga_data[index2] = (byte) (temp);
							++index1;
							++index2;
						}
					}
				}
				if (tga_palette != (null /*0*/))
				{
					free(tga_palette);
				}
			}

			if (tga_comp >= 3 && tga_rgb16 == 0)
			{
				Pointer<byte> tga_pixel = tga_data;
				for (i = (int) (0); i < tga_width*tga_height; ++i)
				{
					byte temp = (byte) (tga_pixel[0]);
					tga_pixel[0] = (byte) (tga_pixel[2]);
					tga_pixel[2] = (byte) (temp);
					tga_pixel += tga_comp;
				}
			}

			if ((req_comp) != 0 && req_comp != tga_comp)
				tga_data = stbi__convert_format(tga_data, tga_comp, req_comp, tga_width, tga_height);
			tga_palette_start =
				(int) (tga_palette_len = (int) (tga_palette_bits = (int) (tga_x_origin = (int) (tga_y_origin = (int) (0)))));
			return tga_data;
		}

		private static int stbi__psd_test(stbi__context s)
		{
			int r = (int) ((stbi__get32be(s) == 943870035));
			stbi__rewind(s);
			return (int) (r);
		}

		private static Pointer<byte> stbi__psd_load(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp,
			int req_comp)
		{
			int pixelCount;
			int channelCount;
			int compression;
			int channel;
			int i;
			int count;
			int len;
			int bitdepth;
			int w;
			int h;
			Pointer<byte> out;
			if (stbi__get32be(s) != 943870035) return (null /*(stbi__err("not PSD") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
			if (stbi__get16be(s) != 1) return (null /*(stbi__err("wrong version") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
			stbi__skip(s, 6);
			channelCount = (int) (stbi__get16be(s));
			if (channelCount < 0 || channelCount > 16) return (null /*(stbi__err("wrong channel count") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
			h = (int) (stbi__get32be(s));
			w = (int) (stbi__get32be(s));
			bitdepth = (int) (stbi__get16be(s));
			if (bitdepth != 8 && bitdepth != 16) return (null /*(stbi__err("unsupported bit depth") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
			if (stbi__get16be(s) != 3) return (null /*(stbi__err("wrong color format") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
			stbi__skip(s, stbi__get32be(s));
			stbi__skip(s, stbi__get32be(s));
			stbi__skip(s, stbi__get32be(s));
			compression = (int) (stbi__get16be(s));
			if (compression > 1) return (null /*(stbi__err("bad compression") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
			_out_ = stbi__malloc(4*w*h);
			if (_out_ == 0) return (null /*(stbi__err("outofmem") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
			pixelCount = (int) (w*h);
			if ((compression) != 0)
			{
				stbi__skip(s, h*channelCount*2);
				for (channel = (int) (0); channel < 4; channel++)
				{
					Pointer<byte> p;
					p = _out_ + channel;
					if (channel >= channelCount)
					{
						for (i = (int) (0); i < pixelCount; i++ , p += 4) p.CurrentValue = (byte) ((channel == 3 > 0 ? 255 : 0));
					}
					else
					{
						count = (int) (0);
						{
							len = (int) (stbi__get8(s));
							if (len == 128)
							{
							}
							else if (len < 128)
							{
								len++;
								count += len;
								{
									p.CurrentValue = (byte) (stbi__get8(s));
									p += 4;
									len--;
								}
							}
							else if (len > 128)
							{
								byte val;
								len ^= 255;
								len += 2;
								val = (byte) (stbi__get8(s));
								count += len;
								{
									p.CurrentValue = (byte) (val);
									p += 4;
									len--;
								}
							}
						}
					}
				}
			}
			else
			{
				for (channel = (int) (0); channel < 4; channel++)
				{
					Pointer<byte> p;
					p = _out_ + channel;
					if (channel >= channelCount)
					{
						byte val = (byte) (channel == 3 > 0 ? 255 : 0);
						for (i = (int) (0); i < pixelCount; i++ , p += 4) p.CurrentValue = (byte) (val);
					}
					else
					{
						if (bitdepth == 16)
						{
							for (i = (int) (0); i < pixelCount; i++ , p += 4) p.CurrentValue = (byte) ((stbi__get16be(s) >> 8));
						}
						else
						{
							for (i = (int) (0); i < pixelCount; i++ , p += 4) p.CurrentValue = (byte) (stbi__get8(s));
						}
					}
				}
			}

			if (channelCount >= 4)
			{
				for (i = (int) (0); i < w*h; ++i)
				{
					Pointer<byte> pixel = _out_ + 4*i;
					if (pixel[3] != 0 && pixel[3] != 255)
					{
						float a = (float) (pixel[3]/255);
						float ra = (float) (1/a);
						float inv_a = (float) (255*(1 - ra));
						pixel[0] = (byte) ((pixel[0]*ra + inv_a));
						pixel[1] = (byte) ((pixel[1]*ra + inv_a));
						pixel[2] = (byte) ((pixel[2]*ra + inv_a));
					}
				}
			}

			if ((req_comp) != 0 && req_comp != 4)
			{
				_out_ = stbi__convert_format(_out_, 4, req_comp, w, h);
				if (_out_ == (null /*0*/)) return _out_;
			}

			if ((comp) != null) comp.CurrentValue = (int) (4);
			y.CurrentValue = (int) (h);
			x.CurrentValue = (int) (w);
			return _out_;
		}

		private static int stbi__pic_is4(stbi__context s, Pointer<sbyte> str)
		{
			int i;
			for (i = (int) (0); i < 4; ++i) if (stbi__get8(s) != str[i]) return (int) (0);
			return (int) (1);
		}

		private static int stbi__pic_test_core(stbi__context s)
		{
			int i;
			if (stbi__pic_is4(s, "S\200\3664") == 0) return (int) (0);
			for (i = (int) (0); i < 84; ++i) stbi__get8(s);
			if (stbi__pic_is4(s, "PICT") == 0) return (int) (0);
			return (int) (1);
		}

		private static Pointer<byte> stbi__readval(stbi__context s, int channel, Pointer<byte> dest)
		{
			int mask = (int) (128);
			int i;
			for (i = (int) (0); i < 4; ++i , mask >>= 1)
			{
				if (channel & mask)
				{
					if ((stbi__at_eof(s)) != 0) return (null /*(stbi__err("bad file") > 0?(null /*0*/):
					(null /*0*/))
					*/)
					;
					dest[i] = (byte) (stbi__get8(s));
				}
			}

			return dest;
		}

		private static void stbi__copyval(int channel, Pointer<byte> dest, Pointer<byte> src)
		{
			int mask = (int) (128);
			int i;
			for (i = (int) (0); i < 4; ++i , mask >>= 1) if (channel & mask) dest[i] = (byte) (src[i]);
		}

		private static Pointer<byte> stbi__pic_load_core(stbi__context s, int width, int height, Pointer<int> comp,
			Pointer<byte> result)
		{
			int act_comp = (int) (0);
			int num_packets = (int) (0);
			int y;
			int chained;
			stbi__pic_packet packets = new stbi__pic_packet(10);
			do
			{
				{
					stbi__pic_packet packet = new stbi__pic_packet();
					if (num_packets == (packets).Size/(packets[0]).Size) return (null /*(stbi__err("bad format") > 0?(null /*0*/):
					(null /*0*/))
					*/)
					;
					packet = packets[num_packets++];
					chained = (int) (stbi__get8(s));
					packet.size = (byte) (stbi__get8(s));
					packet.type = (byte) (stbi__get8(s));
					packet.channel = (byte) (stbi__get8(s));
					act_comp |= packet.channel;
					if ((stbi__at_eof(s)) != 0) return (null /*(stbi__err("bad file") > 0?(null /*0*/):
					(null /*0*/))
					*/)
					;
					if (packet.size != 8) return (null /*(stbi__err("bad format") > 0?(null /*0*/):
					(null /*0*/))
					*/)
					;
				}
			} while (chained);
			comp.CurrentValue = (int) ((act_comp & 16 > 0 ? 4 : 3));
			for (y = (int) (0); y < height; ++y)
			{
				int packet_idx;
				for (packet_idx = (int) (0); packet_idx < num_packets; ++packet_idx)
				{
					stbi__pic_packet packet = packets[packet_idx];
					Pointer<byte> dest = result + y*width*4;
					switch (packet.type)
					{
							return (null /*(stbi__err("bad format") > 0?(null /*0*/):
							(null /*0*/))
							*/)
							;
						case 0:
						{
							int x;
							for (x = (int) (0); x < width; ++x , dest += 4) if (stbi__readval(s, packet.channel, dest) == 0) return 0;
							break;
						}
						case 1:
						{
							int left = (int) (width);
							int i;
							{
								byte count;
								Pointer<byte> value = new Pointer<byte>(4);
								count = (byte) (stbi__get8(s));
								if ((stbi__at_eof(s)) != 0) return (null /*(stbi__err("bad file") > 0?(null /*0*/):
								(null /*0*/))
								*/)
								;
								if (count > left) count = (byte) (left);
								if (stbi__readval(s, packet.channel, value) == 0) return 0;
								for (i = (int) (0); i < count; ++i , dest += 4) stbi__copyval(packet.channel, dest, value);
								left -= count;
							}
						}
							break;
						case 2:
						{
							int left = (int) (width);
							{
								int count = (int) (stbi__get8(s));
								int i;
								if ((stbi__at_eof(s)) != 0) return (null /*(stbi__err("bad file") > 0?(null /*0*/):
								(null /*0*/))
								*/)
								;
								if (count >= 128)
								{
									Pointer<byte> value = new Pointer<byte>(4);
									if (count == 128) count = (int) (stbi__get16be(s))
									else count -= 127;
									if (count > left) return (null /*(stbi__err("bad file") > 0?(null /*0*/):
									(null /*0*/))
									*/)
									;
									if (stbi__readval(s, packet.channel, value) == 0) return 0;
									for (i = (int) (0); i < count; ++i , dest += 4) stbi__copyval(packet.channel, dest, value);
								}
								else
								{
									++count;
									if (count > left) return (null /*(stbi__err("bad file") > 0?(null /*0*/):
									(null /*0*/))
									*/)
									;
									for (i = (int) (0); i < count; ++i , dest += 4) if (stbi__readval(s, packet.channel, dest) == 0) return 0;
								}
								left -= count;
							}
							break;
						}
					}
				}
			}

			return result;
		}

		private static Pointer<byte> stbi__pic_load(stbi__context s, Pointer<int> px, Pointer<int> py, Pointer<int> comp,
			int req_comp)
		{
			Pointer<byte> result;
			int i;
			int x;
			int y;
			for (i = (int) (0); i < 92; ++i) stbi__get8(s);
			x = (int) (stbi__get16be(s));
			y = (int) (stbi__get16be(s));
			if ((stbi__at_eof(s)) != 0) return (null /*(stbi__err("bad file") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
			if ((1 << 28)/x < y) return (null /*(stbi__err("too large") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
			stbi__get32be(s);
			stbi__get16be(s);
			stbi__get16be(s);
			result = stbi__malloc(x*y*4);
			memset(result, 255, x*y*4);
			if (stbi__pic_load_core(s, x, y, comp, result) == 0)
			{
				free(result);
				result = 0;
			}

			px.CurrentValue = (int) (x);
			py.CurrentValue = (int) (y);
			if (req_comp == 0) req_comp = (int) (comp.CurrentValue);
			result = stbi__convert_format(result, 4, req_comp, x, y);
			return result;
		}

		private static int stbi__pic_test(stbi__context s)
		{
			int r = (int) (stbi__pic_test_core(s));
			stbi__rewind(s);
			return (int) (r);
		}

		private static int stbi__gif_test_raw(stbi__context s)
		{
			int sz;
			if (stbi__get8(s) != || stbi__get8(s) != || stbi__get8(s) != || stbi__get8(s) !=) return (int) (0);
			sz = (int) (stbi__get8(s));
			if (sz != && sz !=) return (int) (0);
			if (stbi__get8(s) !=) return (int) (0);
			return (int) (1);
		}

		private static int stbi__gif_test(stbi__context s)
		{
			int r = (int) (stbi__gif_test_raw(s));
			stbi__rewind(s);
			return (int) (r);
		}

		private static void stbi__gif_parse_colortable(stbi__context s, Pointer<Pointer<byte>> pal, int num_entries,
			int transp)
		{
			int i;
			for (i = (int) (0); i < num_entries; ++i)
			{
				pal[i][2] = (byte) (stbi__get8(s));
				pal[i][1] = (byte) (stbi__get8(s));
				pal[i][0] = (byte) (stbi__get8(s));
				pal[i][3] = (byte) (transp == i > 0 ? 0 : 255);
			}

		}

		private static int stbi__gif_header(stbi__context s, stbi__gif g, Pointer<int> comp, int is_info)
		{
			byte version;
			if (stbi__get8(s) != || stbi__get8(s) != || stbi__get8(s) != || stbi__get8(s) !=)
				return (int) (stbi__err("not GIF"));
			version = (byte) (stbi__get8(s));
			if (version != && version !=) return (int) (stbi__err("not GIF"));
			if (stbi__get8(s) !=) return (int) (stbi__err("not GIF"));
			stbi__g_failure_reason = "";
			g.w = (int) (stbi__get16le(s));
			g.h = (int) (stbi__get16le(s));
			g.flags = (int) (stbi__get8(s));
			g.bgindex = (int) (stbi__get8(s));
			g.ratio = (int) (stbi__get8(s));
			g.transparent = (int) (-1);
			if (comp != 0) comp.CurrentValue = (int) (4);
			if ((is_info) != 0) return (int) (1);
			if (g.flags & 128) stbi__gif_parse_colortable(s, g.pal, 2 << (g.flags & 7), -1);
			return (int) (1);
		}

		private static int stbi__gif_info_raw(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp)
		{
			stbi__gif g = stbi__malloc(.Size)
			;
			if (stbi__gif_header(s, g, comp, 1) == 0)
			{
				free(g);
				stbi__rewind(s);
				return (int) (0);
			}

			if ((x) != null) x.CurrentValue = (int) (g.w);
			if ((y) != null) y.CurrentValue = (int) (g.h);
			free(g);
			return (int) (1);
		}

		private static void stbi__out_gif_code(stbi__gif g, ushort code)
		{
			Pointer<byte> p;
			Pointer<byte> c;
			if (g.codes[code].prefix >= 0) stbi__out_gif_code(g, g.codes[code].prefix);
			if (g.cur_y >= g.max_y) return;
			p = g.out[
			g.cur_x + g.cur_y]
			;
			c = g.color_table[g.codes[code].suffix*4];
			if (c[3] >= 128)
			{
				p[0] = (byte) (c[2]);
				p[1] = (byte) (c[1]);
				p[2] = (byte) (c[0]);
				p[3] = (byte) (c[3]);
			}

			g.cur_x += 4;
			if (g.cur_x >= g.max_x)
			{
				g.cur_x = (int) (g.start_x);
				g.cur_y += g.step;
				{
					g.step = (int) ((1 << g.parse)*g.line_size);
					g.cur_y = (int) (g.start_y + (g.step >> 1));
					--g.parse;
				}
			}

		}

		private static Pointer<byte> stbi__process_gif_raster(stbi__context s, stbi__gif g)
		{
			byte lzw_cs;
			int len;
			int init_code;
			uint first;
			int codesize;
			int codemask;
			int avail;
			int oldcode;
			int bits;
			int valid_bits;
			int clear;
			stbi__gif_lzw p = new stbi__gif_lzw();
			lzw_cs = (byte) (stbi__get8(s));
			if (lzw_cs > 12) return (null /*0*/);
			clear = (int) (1 << lzw_cs);
			first = (uint) (1);
			codesize = (int) (lzw_cs + 1);
			codemask = (int) ((1 << codesize) - 1);
			bits = (int) (0);
			valid_bits = (int) (0);
			for (init_code = (int) (0); init_code < clear; init_code++)
			{
				g.codes[init_code].prefix = (short) (-1);
				g.codes[init_code].first = (byte) (init_code);
				g.codes[init_code].suffix = (byte) (init_code);
			}

			avail = (int) (clear + 2);
			oldcode = (int) (-1);
			len = (int) (0);
			for (;;)
			{
				if (valid_bits < codesize)
				{
					if (len == 0)
					{
						len = (int) (stbi__get8(s));
						if (len == 0) return g.out;
					}
					--len;
					bits |= stbi__get8(s) << valid_bits;
					valid_bits += 8;
				}
				else
				{
					int code = (int) (bits & codemask);
					bits >>= codesize;
					valid_bits -= codesize;
					if (code == clear)
					{
						codesize = (int) (lzw_cs + 1);
						codemask = (int) ((1 << codesize) - 1);
						avail = (int) (clear + 2);
						oldcode = (int) (-1);
						first = (uint) (0);
					}
					else if (code == clear + 1)
					{
						stbi__skip(s, len);
						stbi__skip(s, len);
						return g.out;
					}
					else if (code <= avail)
					{
						if ((first) != 0) return (null /*(stbi__err("no clear code") > 0?(null /*0*/):
						(null /*0*/))
						*/)
						;
						if (oldcode >= 0)
						{
							p = g.codes[avail++];
							if (avail > 4096) return (null /*(stbi__err("too many codes") > 0?(null /*0*/):
							(null /*0*/))
							*/)
							;
							p.prefix = (short) (oldcode);
							p.first = (byte) (g.codes[oldcode].first);
							p.suffix = (byte) ((code == avail) > 0 ? p.first : g.codes[code].first);
						}
						else if (code == avail) return (null /*(stbi__err("illegal code in raster") > 0?(null /*0*/):
						(null /*0*/))
						*/)
						;
						stbi__out_gif_code(g, code);
						if ((avail & codemask) == 0 && avail <= 4095)
						{
							codesize++;
							codemask = (int) ((1 << codesize) - 1);
						}
						oldcode = (int) (code);
					}
					else
					{
						return (null /*(stbi__err("illegal code in raster") > 0?(null /*0*/):
						(null /*0*/))
						*/)
						;
					}
				}
			}

		}

		private static void stbi__fill_gif_background(stbi__gif g, int x0, int y0, int x1, int y1)
		{
			int x;
			int y;
			Pointer<byte> c = g.pal[g.bgindex];
			for (y = (int) (y0); y < y1; y += 4*g.w)
			{
				for (x = (int) (x0); x < x1; x += 4)
				{
					Pointer<byte> p = g.out[
					y + x]
					;
					p[0] = (byte) (c[2]);
					p[1] = (byte) (c[1]);
					p[2] = (byte) (c[0]);
					p[3] = (byte) (0);
				}
			}

		}

		private static Pointer<byte> stbi__gif_load_next(stbi__context s, stbi__gif g, Pointer<int> comp, int req_comp)
		{
			int i;
			Pointer<byte> prev_out = 0;
			if (g.out ==
			0 && stbi__gif_header(s, g, comp, 0) == 0)
			return 0;
			prev_out = g.out;
			g.out =
			stbi__malloc(4*g.w*g.h);
			if (g.out ==
			0)
			return (null /*(stbi__err("outofmem") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
			switch ((g.eflags & 28) >> 2)
			{
				case 0:
					stbi__fill_gif_background(g, 0, 0, 4*g.w, 4*g.w*g.h);
					break;
				case 1:
					if ((prev_out) != null) memcpy(g.out, prev_out, 4*g.w*g.h);
					g.old_out = prev_out;
					break;
				case 2:
					if ((prev_out) != null) memcpy(g.out, prev_out, 4*g.w*g.h);
					stbi__fill_gif_background(g, g.start_x, g.start_y, g.max_x, g.max_y);
					break;
				case 3:
					if ((g.old_out) != null)
					{
						for (i = (int) (g.start_y); i < g.max_y; i += 4*g.w) memcpy(g.out[i + g.start_x],
						g.old_out[i + g.start_x],
						g.max_x - g.start_x)
						;
					}
					break;
			}

			for (;;)
			{
				switch (stbi__get8(s))
				{
					case 44:
					{
						int prev_trans = (int) (-1);
						int x;
						int y;
						int w;
						int h;
						Pointer<byte> o;
						x = (int) (stbi__get16le(s));
						y = (int) (stbi__get16le(s));
						w = (int) (stbi__get16le(s));
						h = (int) (stbi__get16le(s));
						if ((((x + w) > (g.w))) != 0 || (((y + h) > (g.h))) != 0)
							return (null /*(stbi__err("bad Image Descriptor") > 0?(null /*0*/):
						(null /*0*/))
						*/)
						;
						g.line_size = (int) (g.w*4);
						g.start_x = (int) (x*4);
						g.start_y = (int) (y*g.line_size);
						g.max_x = (int) (g.start_x + w*4);
						g.max_y = (int) (g.start_y + h*g.line_size);
						g.cur_x = (int) (g.start_x);
						g.cur_y = (int) (g.start_y);
						g.lflags = (int) (stbi__get8(s));
						if (g.lflags & 64)
						{
							g.step = (int) (8*g.line_size);
							g.parse = (int) (3);
						}
						else
						{
							g.step = (int) (g.line_size);
							g.parse = (int) (0);
						}
						if (g.lflags & 128)
						{
							stbi__gif_parse_colortable(s, g.lpal, 2 << (g.lflags & 7), g.eflags & 1 > 0 ? g.transparent : -1);
							g.color_table = g.lpal;
						}
						else if (g.flags & 128)
						{
							if (g.transparent >= 0 && ((g.eflags & 1)) != 0)
							{
								prev_trans = (int) (g.pal[g.transparent][3]);
								g.pal[g.transparent][3] = (byte) (0);
							}
							g.color_table = g.pal;
						}
						else return (null /*(stbi__err("missing color table") > 0?(null /*0*/):
						(null /*0*/))
						*/)
						;
						o = stbi__process_gif_raster(s, g);
						if (o == (null /*0*/)) return (null /*0*/);
						if (prev_trans != -1) g.pal[g.transparent][3] = (byte) (prev_trans);
						return o;
					}
					case 33:
					{
						int len;
						if (stbi__get8(s) == 249)
						{
							len = (int) (stbi__get8(s));
							if (len == 4)
							{
								g.eflags = (int) (stbi__get8(s));
								g.delay = (int) (stbi__get16le(s));
								g.transparent = (int) (stbi__get8(s));
							}
							else
							{
								stbi__skip(s, len);
								break;
							}
						}
						stbi__skip(s, len);
						break;
					}
					case 59:
						return s;
						return (null /*(stbi__err("unknown code") > 0?(null /*0*/):
						(null /*0*/))
						*/)
						;
				}
			}

			(req_comp);
		}

		private static Pointer<byte> stbi__gif_load(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp,
			int req_comp)
		{
			Pointer<byte> u = 0;
			stbi__gif g = stbi__malloc(.Size)
			;
			memset(g, 0, (g).Size);
			u = stbi__gif_load_next(s, g, comp, req_comp);
			if (u == s) u = 0;
			if ((u) != null)
			{
				x.CurrentValue = (int) (g.w);
				y.CurrentValue = (int) (g.h);
				if ((req_comp) != 0 && req_comp != 4) u = stbi__convert_format(u, 4, req_comp, g.w, g.h);
			}
			else if ((g.out) != null) free(g.out);
			free(g);
			return u;
		}

		private static int stbi__gif_info(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp)
		{
			return (int) (stbi__gif_info_raw(s, x, y, comp));
		}

		private static int stbi__bmp_info(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp)
		{
			object p;
			stbi__bmp_data info = new stbi__bmp_data();
			info.all_a = (uint) (255);
			p = (object) (stbi__bmp_parse_header(s, info));
			stbi__rewind(s);
			if (p == (null /*0*/)) return (int) (0);
			x.CurrentValue = (int) (s.img_x);
			y.CurrentValue = (int) (s.img_y);
			comp.CurrentValue = (int) (info.ma > 0 ? 4 : 3);
			return (int) (1);
		}

		private static int stbi__psd_info(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp)
		{
			int channelCount;
			if (stbi__get32be(s) != 943870035)
			{
				stbi__rewind(s);
				return (int) (0);
			}

			if (stbi__get16be(s) != 1)
			{
				stbi__rewind(s);
				return (int) (0);
			}

			stbi__skip(s, 6);
			channelCount = (int) (stbi__get16be(s));
			if (channelCount < 0 || channelCount > 16)
			{
				stbi__rewind(s);
				return (int) (0);
			}

			y.CurrentValue = (int) (stbi__get32be(s));
			x.CurrentValue = (int) (stbi__get32be(s));
			if (stbi__get16be(s) != 8)
			{
				stbi__rewind(s);
				return (int) (0);
			}

			if (stbi__get16be(s) != 3)
			{
				stbi__rewind(s);
				return (int) (0);
			}

			comp.CurrentValue = (int) (4);
			return (int) (1);
		}

		private static int stbi__pic_info(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp)
		{
			int act_comp = (int) (0);
			int num_packets = (int) (0);
			int chained;
			stbi__pic_packet packets = new stbi__pic_packet(10);
			if (stbi__pic_is4(s, "S\200\3664") == 0)
			{
				stbi__rewind(s);
				return (int) (0);
			}

			stbi__skip(s, 88);
			x.CurrentValue = (int) (stbi__get16be(s));
			y.CurrentValue = (int) (stbi__get16be(s));
			if ((stbi__at_eof(s)) != 0)
			{
				stbi__rewind(s);
				return (int) (0);
			}

			if ((x.CurrentValue) != 0 && (1 << 28)/(x.CurrentValue) < (y.CurrentValue))
			{
				stbi__rewind(s);
				return (int) (0);
			}

			stbi__skip(s, 8);
			do
			{
				{
					stbi__pic_packet packet = new stbi__pic_packet();
					if (num_packets == (packets).Size/(packets[0]).Size) return (int) (0);
					packet = packets[num_packets++];
					chained = (int) (stbi__get8(s));
					packet.size = (byte) (stbi__get8(s));
					packet.type = (byte) (stbi__get8(s));
					packet.channel = (byte) (stbi__get8(s));
					act_comp |= packet.channel;
					if ((stbi__at_eof(s)) != 0)
					{
						stbi__rewind(s);
						return (int) (0);
					}
					if (packet.size != 8)
					{
						stbi__rewind(s);
						return (int) (0);
					}
				}
			} while (chained);
			comp.CurrentValue = (int) ((act_comp & 16 > 0 ? 4 : 3));
			return (int) (1);
		}

		private static int stbi__pnm_test(stbi__context s)
		{
			sbyte p;
			sbyte t;
			p = (sbyte) (stbi__get8(s));
			t = (sbyte) (stbi__get8(s));
			if (p != || ((t != && t !=)) != 0)
			{
				stbi__rewind(s);
				return (int) (0);
			}

			return (int) (1);
		}

		private static Pointer<byte> stbi__pnm_load(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp,
			int req_comp)
		{
			Pointer<byte> out;
			if (stbi__pnm_info(s, s.img_x, s.img_y, s.img_n) == 0) return 0;
			x.CurrentValue = (int) (s.img_x);
			y.CurrentValue = (int) (s.img_y);
			comp.CurrentValue = (int) (s.img_n);
			_out_ = stbi__malloc(s.img_n*s.img_x*s.img_y);
			if (_out_ == 0) return (null /*(stbi__err("outofmem") > 0?(null /*0*/):
			(null /*0*/))
			*/)
			;
			stbi__getn(s, _out_, s.img_n*s.img_x*s.img_y);
			if ((req_comp) != 0 && req_comp != s.img_n)
			{
				_out_ = stbi__convert_format(_out_, s.img_n, req_comp, s.img_x, s.img_y);
				if (_out_ == (null /*0*/)) return _out_;
			}

			return _out_;
		}

		private static int stbi__pnm_isspace(sbyte c)
		{
			return (int) (c == || c == || c == || c == || c == || c == ? 1 : 0);
		}

		private static void stbi__pnm_skip_whitespace(stbi__context s, Pointer<sbyte> c)
		{
			for (;;)
			{
				c.CurrentValue = (sbyte) (stbi__get8(s));
				if ((stbi__at_eof(s)) != 0 || c.CurrentValue !=) break;
				c.CurrentValue = (sbyte) (stbi__get8(s));
			}

		}

		private static int stbi__pnm_isdigit(sbyte c)
		{
			return (int) (c >= && c <= ? 1 : 0);
		}

		private static int stbi__pnm_getinteger(stbi__context s, Pointer<sbyte> c)
		{
			int value = (int) (0);
			{
				value = (int) (value*10 + (c.CurrentValue -));
				c.CurrentValue = (sbyte) (stbi__get8(s));
			}

			return (int) (value);
		}

		private static int stbi__pnm_info(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp)
		{
			int maxv;
			sbyte c;
			sbyte p;
			sbyte t;
			stbi__rewind(s);
			p = (sbyte) (stbi__get8(s));
			t = (sbyte) (stbi__get8(s));
			if (p != || ((t != && t !=)) != 0)
			{
				stbi__rewind(s);
				return (int) (0);
			}

			comp.CurrentValue = (int) ((t ==) > 0 ? 3 : 1);
			c = (sbyte) (stbi__get8(s));
			stbi__pnm_skip_whitespace(s, c);
			x.CurrentValue = (int) (stbi__pnm_getinteger(s, c));
			stbi__pnm_skip_whitespace(s, c);
			y.CurrentValue = (int) (stbi__pnm_getinteger(s, c));
			stbi__pnm_skip_whitespace(s, c);
			maxv = (int) (stbi__pnm_getinteger(s, c));
			if (maxv > 255) return (int) (stbi__err("max value > 255"))
			else return (int) (1);
		}

		private static int stbi__info_main(stbi__context s, Pointer<int> x, Pointer<int> y, Pointer<int> comp)
		{
			if ((stbi__jpeg_info(s, x, y, comp)) != 0) return (int) (1);
			if ((stbi__png_info(s, x, y, comp)) != 0) return (int) (1);
			if ((stbi__gif_info(s, x, y, comp)) != 0) return (int) (1);
			if ((stbi__bmp_info(s, x, y, comp)) != 0) return (int) (1);
			if ((stbi__psd_info(s, x, y, comp)) != 0) return (int) (1);
			if ((stbi__pic_info(s, x, y, comp)) != 0) return (int) (1);
			if ((stbi__pnm_info(s, x, y, comp)) != 0) return (int) (1);
			if ((stbi__tga_info(s, x, y, comp)) != 0) return (int) (1);
			return (int) (stbi__err("unknown image type"));
		}

		private static int stbi_info_from_memory(Pointer<byte> buffer, int len, Pointer<int> x, Pointer<int> y,
			Pointer<int> comp)
		{
			stbi__context s = new stbi__context();
			stbi__start_mem(s, buffer, len);
			return (int) (stbi__info_main(s, x, y, comp));
		}

		private static int stbi_info_from_callbacks(stbi_io_callbacks c, object user, Pointer<int> x, Pointer<int> y,
			Pointer<int> comp)
		{
			stbi__context s = new stbi__context();
			stbi__start_callbacks(s, c, user);
			return (int) (stbi__info_main(s, x, y, comp));
		}

	}
}