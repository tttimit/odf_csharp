def create_csharp_dict_string():
    f = open('read_inserted_data.txt')
    data = ''

    line = f.readline()
    while line:
        key = line[:line.index('=')]
        value = line[line.index('=')+1:]
        if '\n' in value:
            value = value[:-1]
    ##    print("{}={}".format(key, value))
        data += '{{\"{}\", \"{}\"}},'.format(key, value)
        line = f.readline()

    f.close()

    print(data[:-1])



def get_types():
    f = open('read_type.txt')
    line = f.readline()
    dict = {}
    while line:
        value = line[line.rindex('.'):]
        print('value={}'.format(value))
        if '\n' in value:
            value = value[:-1]
        if value in dict:
            dict[value] += 1
        else:
            dict[value] = 1
        line = f.readline()

    print(dict)

get_types()
